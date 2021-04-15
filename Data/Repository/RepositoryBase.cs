﻿using AcessoWebApi.Infrastructure.Security;
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
    public class RepositoryBase<T> : IRepository<T> where T : EntidadeBase
    {
        private readonly ISession _session;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public RepositoryBase(ISession _session, ICurrentUserAccessor _currentUserAccessor)
        {
            if (!_session.IsOpen)
            {
                _session.SessionFactory.OpenSession();
            }

            this._session = _session;
            this._currentUserAccessor = _currentUserAccessor;
        }

        public async Task<T> InsertAsync(T item)
        {
            using (var transaction = _session.BeginTransaction())
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

                    await _session.SaveAsync(item);
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
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var _itemCadastrado = await _session.GetAsync<T>(id);
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

                        await _session.MergeAsync(item);
                        await _session.FlushAsync();
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
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var result = await _session.GetAsync<T>(id);
                    if (result == null)
                        return false;
                    else
                    {

                        result.Ativo = 'I';
                        result.Datadeinativacao = DateTime.UtcNow;
                        result.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                        await _session.UpdateAsync(result);

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
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    var result = await _session.GetAsync<T>(id);
                    if (result == null)
                        return false;
                    else
                    {

                        await _session.DeleteAsync(result);

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

            var result = await _session.GetAsync<T>(id);
            if (result == null)
                return false;
            else
                return result.Ativo != 'A';
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var result = await _session.GetAsync<T>(id);
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
                return await (from e in _session.Query<T>() select e).Where(e => e.Fkparceiro.Equals(_idparceiro) && e.Ativo.Equals('A')).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetInatives()
        {
            var Idparceiro = _currentUserAccessor.GetCurrentParcID();
            return await _session.Query<T>().Where(u => u.Fkparceiro.Equals(Idparceiro) && u.Ativo.Equals('I')).ToListAsync();
        }

        public IQueryable<T> QuerySelect()
        {
            try
            {
                var _idparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro;
                return _session.Query<T>().Where(e => e.Fkparceiro.Equals(_idparceiro) && e.Ativo.Equals('A'));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (_session.Transaction.WasCommitted) _session.Transaction.Dispose();
        }
    }
}
