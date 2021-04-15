using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.CaixaDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;
using AcessoWebApi.Infrastructure.Security;

namespace Service.Services
{
     public class CaixaService : ICaixaService 
     {
         private IRepositoryCrud<Caixa> _repository;    
         private readonly IMapper _mapper;                                   
         private readonly ICurrentUserAccessor _currentUserAccessor;

          public CaixaService(IRepositoryCrud<Caixa> repository, IMapper mapper, ICurrentUserAccessor currentUserAccessor) 
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

          public async Task<IEnumerable<CaixaDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  foreach (Caixa caixa in ListEntity)
                  {
                      foreach (Venda venda in caixa.Vendas)
                      {
                          if (venda.Ativo == 'I') caixa.Vendas.Remove(venda);
                      }
                  }
                  return _mapper.Map<IEnumerable<CaixaDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<CaixaDTOCreateReturn> Post(CaixaDTOCreate caixa) 
          {
              try 
              {
                  var model = _mapper.Map<CaixaModel>(caixa);
                  var entity = _mapper.Map<Caixa>(model);
                  entity.Vendas.ToList().ForEach(x => x.Caixa = entity);
                  entity.Vendas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Vendas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Vendas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Vendas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<CaixaDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<CaixaDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  foreach (Venda venda in entity.Vendas)
                  {
                      if (venda.Ativo == 'I') entity.Vendas.Remove(venda);
                  }
                  return _mapper.Map<CaixaDTOReference>(entity) ?? new CaixaDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<CaixaDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<CaixaDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<CaixaDTOUpdateReturn> Put(CaixaDTOUpdate caixa)
          {
              try 
              {
                  var model = _mapper.Map<CaixaModel>(caixa);
                  var entity = _mapper.Map<Caixa>(model);

                  entity.Vendas.ToList().ForEach(x => x.Caixa = entity);
                  entity.Vendas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Vendas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Vendas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Vendas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var _itemCadastrado = await _repository.SelectAsync(entity.Idcaixa);
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

                  var result = await _repository.UpdateAsync(entity, entity.Idcaixa);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Idcaixa);

                  return _mapper.Map<CaixaDTOUpdateReturn>(retornodeAlteracao);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<CaixaDTOReference>> GetAll(Guid Idloja)
          {
             try
             {
                var ListEntity = await _repository.SelectAsync();
                var ListEntityBy = ListEntity.Select(x => x.Loja.Idloja.Equals(Idloja));

                return _mapper.Map<IEnumerable<CaixaDTOReference>>(ListEntityBy);
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
