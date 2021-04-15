using AcessoWebApi.Infrastructure.Security;
using Domain.Entidades;
using Domain.Enum;
using Domain.Enum.Core;
using Domain.Interfaces;
using Domain.Models;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryBaseCrud<T> : IRepositoryCrud<T> where T : EntidadeBase
    {
        private readonly Func<string, ISession> _sessionCRUD;

        private readonly ICurrentUserAccessor _currentUserAccessor;

        public RepositoryBaseCrud(Func<string, ISession> _sessionCRUD,
                                  ICurrentUserAccessor _currentUserAccessor)
        {
            if (!_sessionCRUD("CRUD").IsOpen)
            {
              _sessionCRUD("CRUD").SessionFactory.OpenSession();
            }

            this._sessionCRUD = _sessionCRUD;
            this._currentUserAccessor = _currentUserAccessor;
        }

        public async Task<T> InsertAsync(T item)
        {
            using (var transaction = _sessionCRUD("CRUD").BeginTransaction())
            {
                try
                {
                    item.Datadealteracao = null;
                    item.Datadeinativacao = null;
                    item.Usuariodealteracao = null;
                    item.Usuariodeinativacao = null;
                    if (item.Ativo == '\0')
                    {
                        item.Ativo = 'A';
                    }

                    item.Datadeinclusao = DateTime.UtcNow;
                    item.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario;
                    if (item.Fkparceiro == Guid.Empty)
                    {
                        item.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro;
                    }

                    await _sessionCRUD("CRUD").SaveAsync(item);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted) transaction.Rollback();
                    throw ex;
                }
                return item;
            }
        }

        public async Task<T> UpdateAsync(T item, Guid id)
        {
            using (var transaction = _sessionCRUD("CRUD").BeginTransaction())
            {
                try
                {
                    var _itemCadastrado = await _sessionCRUD("CRUD").GetAsync<T>(id);
                    if (_itemCadastrado == null)
                        return null;
                    else
                    {

                        item.Datadeinclusao = _itemCadastrado.Datadeinclusao;
                        item.Usuariodeinclusao = _itemCadastrado.Usuariodeinclusao;
                        item.Fkparceiro = _itemCadastrado.Fkparceiro;
                        item.Ativo = _itemCadastrado.Ativo;

                        item.Datadealteracao = DateTime.UtcNow;
                        if (item.Usuariodealteracao == null)
                            item.Usuariodealteracao = _currentUserAccessor.GetCurrentUser().Idusuario;

                        await _sessionCRUD("CRUD").MergeAsync(item);
                        await _sessionCRUD("CRUD").FlushAsync();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted) transaction.Rollback();
                    throw ex;
                }
                return item;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var transaction = _sessionCRUD("CRUD").BeginTransaction())
            {
                try
                {
                    var result = await _sessionCRUD("CRUD").GetAsync<T>(id);
                    if (result == null)
                        return false;
                    else
                    {

                        result.Ativo = 'I';
                        result.Datadeinativacao = DateTime.UtcNow;
                        result.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                        await _sessionCRUD("CRUD").UpdateAsync(result);

                        transaction.Commit();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted) transaction.Rollback();

                    throw ex;
                }
            }
        }

        public async Task<bool> DeleteAdminAsync(Guid id)
        {
            using (var transaction = _sessionCRUD("CRUD").BeginTransaction())
            {
                try
                {
                    var result = await _sessionCRUD("CRUD").GetAsync<T>(id);
                    if (result == null)
                        return false;
                    else
                    {

                        await _sessionCRUD("CRUD").DeleteAsync(result);

                        transaction.Commit();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    if (!transaction.WasCommitted) transaction.Rollback();

                    throw ex;
                }
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {

            var result = await _sessionCRUD("CRUD").GetAsync<T>(id);
            if (result == null)
                return false;
            else
                return result.Ativo != 'A';
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var result = await _sessionCRUD("CRUD").GetAsync<T>(id);
                if (result != null)
                    return result.Ativo.Equals('A') ? result : null;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                var _idparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro;
                return await (from e in _sessionCRUD("CRUD").Query<T>() select e).Where(e => e.Fkparceiro.Equals(_idparceiro) && e.Ativo.Equals('A')).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetInatives()
        {
            var Idparceiro = _currentUserAccessor.GetCurrentParcID();
            return await _sessionCRUD("CRUD").Query<T>().Where(u => u.Fkparceiro.Equals(Idparceiro) && u.Ativo.Equals('I')).ToListAsync();
        }

        public IQueryable<T> QuerySelect()
        {
            try
            {
                var _idparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro;
                return _sessionCRUD("CRUD").Query<T>().Where(e => e.Fkparceiro.Equals(_idparceiro) && e.Ativo.Equals('A'));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (_sessionCRUD("CRUD").Transaction.WasCommitted) _sessionCRUD("CRUD").Transaction.Dispose();
            if (_sessionCRUD("CRUD").Transaction.WasCommitted) _sessionCRUD("CRUD").Transaction.Dispose();
        }
    }
}
