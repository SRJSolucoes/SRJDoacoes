using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.ParametroDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;
using AcessoWebApi.Infrastructure.Security;

namespace Service.Services
{
     public class ParametroService : IParametroService 
     {
         private IRepositoryCrud<Parametro> _repository;    
         private readonly IMapper _mapper;                                   
         private readonly ICurrentUserAccessor _currentUserAccessor;

          public ParametroService(IRepositoryCrud<Parametro> repository, IMapper mapper, ICurrentUserAccessor currentUserAccessor) 
          {
              _repository = repository;
              _mapper = mapper;
              _currentUserAccessor = currentUserAccessor;
          }

          public async Task<bool> Delete(Guid id) 
          {
              try 
              {
                  return await _repository.DeleteAsync(id);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<bool> DeleteAdmin(Guid id) 
          {
              try 
              {
                  return await _repository.DeleteAdminAsync(id);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<ParametroDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  foreach (Parametro parametro in ListEntity)
                  {
                      foreach (Venda venda in parametro.Vendas)
                      {
                          if (venda.Ativo == 'I') parametro.Vendas.Remove(venda);
                      }
                  }
                  return _mapper.Map<IEnumerable<ParametroDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<ParametroDTOCreateReturn> Post(ParametroDTOCreate parametro) 
          {
              try 
              {
                  var model = _mapper.Map<ParametroModel>(parametro);
                  var entity = _mapper.Map<Parametro>(model);
                  entity.Vendas.ToList().ForEach(x => x.Parametro = entity);
                  entity.Vendas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Vendas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Vendas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Vendas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<ParametroDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<ParametroDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  foreach (Venda venda in entity.Vendas)
                  {
                      if (venda.Ativo == 'I') entity.Vendas.Remove(venda);
                  }
                  return _mapper.Map<ParametroDTOReference>(entity) ?? new ParametroDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<ParametroDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<ParametroDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<ParametroDTOUpdateReturn> Put(ParametroDTOUpdate parametro)
          {
              try 
              {
                  var model = _mapper.Map<ParametroModel>(parametro);
                  var entity = _mapper.Map<Parametro>(model);

                  entity.Vendas.ToList().ForEach(x => x.Parametro = entity);
                  entity.Vendas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Vendas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Vendas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Vendas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var _itemCadastrado = await _repository.SelectAsync(entity.Idparametro);
                  foreach (Venda venda in _itemCadastrado.Vendas)
                  {
                      if (entity.Vendas.FirstOrDefault(x => x.Idvenda == venda.Idvenda) == null)
                      {
                          venda.Ativo = 'I';
                          venda.Datadeinativacao = DateTime.UtcNow;
                          venda.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                          entity.Vendas.Add(venda);
                      }
                  }

                  foreach (Venda venda in entity.Vendas)
                  {
                      var _itemFilhoCadastrado = _itemCadastrado.Vendas.FirstOrDefault(x => x.Idvenda == venda.Idvenda);
                      if (_itemFilhoCadastrado != null)
                      {
                          venda.Usuariodeinclusao = _itemFilhoCadastrado.Usuariodeinclusao;
                          venda.Datadeinclusao = _itemFilhoCadastrado.Datadeinclusao;
                      }
                  }

                  var result = await _repository.UpdateAsync(entity, entity.Idparametro);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Idparametro);

                  return _mapper.Map<ParametroDTOUpdateReturn>(retornodeAlteracao);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<ParametroDTOReference>> GetAll(Guid Idgrupo)
          {
             try
             {
                var ListEntity = await _repository.SelectAsync();
                var ListEntityBy = ListEntity.Select(x => x.Grupo.Idgrupo.Equals(Idgrupo));

                return _mapper.Map<IEnumerable<ParametroDTOReference>>(ListEntityBy);
             }
             catch (Exception ex)
             {
                throw ex;
             }
          }

          public void Dispose() 
          {
              _repository.Dispose();
          }
    }
}
