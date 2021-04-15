using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.LojaDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;
using AcessoWebApi.Infrastructure.Security;

namespace Service.Services
{
     public class LojaService : ILojaService 
     {
         private IRepositoryCrud<Loja> _repository;    
         private readonly IMapper _mapper;                                   
         private readonly ICurrentUserAccessor _currentUserAccessor;

          public LojaService(IRepositoryCrud<Loja> repository, IMapper mapper, ICurrentUserAccessor currentUserAccessor) 
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

          public async Task<IEnumerable<LojaDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  foreach (Loja loja in ListEntity)
                  {
                      foreach (Caixa caixa in loja.Caixas)
                      {
                          if (caixa.Ativo == 'I') loja.Caixas.Remove(caixa);
                      }
                  }
                  return _mapper.Map<IEnumerable<LojaDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<LojaDTOCreateReturn> Post(LojaDTOCreate loja) 
          {
              try 
              {
                  var model = _mapper.Map<LojaModel>(loja);
                  var entity = _mapper.Map<Loja>(model);
                  entity.Caixas.ToList().ForEach(x => x.Loja = entity);
                  entity.Caixas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Caixas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Caixas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Caixas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<LojaDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<LojaDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  foreach (Caixa caixa in entity.Caixas)
                  {
                      if (caixa.Ativo == 'I') entity.Caixas.Remove(caixa);
                  }
                  return _mapper.Map<LojaDTOReference>(entity) ?? new LojaDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<LojaDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<LojaDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<LojaDTOUpdateReturn> Put(LojaDTOUpdate loja)
          {
              try 
              {
                  var model = _mapper.Map<LojaModel>(loja);
                  var entity = _mapper.Map<Loja>(model);

                  entity.Caixas.ToList().ForEach(x => x.Loja = entity);
                  entity.Caixas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Caixas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Caixas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Caixas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var _itemCadastrado = await _repository.SelectAsync(entity.Idloja);
                  foreach (Caixa caixa in _itemCadastrado.Caixas)
                  {
                      if (entity.Caixas.FirstOrDefault(x => x.Idcaixa == caixa.Idcaixa) == null)
                      {
                          caixa.Ativo = 'I';
                          caixa.Datadeinativacao = DateTime.UtcNow;
                          caixa.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                          entity.Caixas.Add(caixa);
                      }
                  }

                  foreach (Caixa caixa in entity.Caixas)
                  {
                      var _itemFilhoCadastrado = _itemCadastrado.Caixas.FirstOrDefault(x => x.Idcaixa == caixa.Idcaixa);
                      if (_itemFilhoCadastrado != null)
                      {
                          caixa.Usuariodeinclusao = _itemFilhoCadastrado.Usuariodeinclusao;
                          caixa.Datadeinclusao = _itemFilhoCadastrado.Datadeinclusao;
                      }
                  }

                  var result = await _repository.UpdateAsync(entity, entity.Idloja);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Idloja);

                  return _mapper.Map<LojaDTOUpdateReturn>(retornodeAlteracao);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<LojaDTOReference>> GetAll(Guid Idgrupo)
          {
             try
             {
                var ListEntity = await _repository.SelectAsync();
                var ListEntityBy = ListEntity.Select(x => x.Grupo.Idgrupo.Equals(Idgrupo));

                return _mapper.Map<IEnumerable<LojaDTOReference>>(ListEntityBy);
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
