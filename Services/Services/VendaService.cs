using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.VendaDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;
using AcessoWebApi.Infrastructure.Security;

namespace Service.Services
{
     public class VendaService : IVendaService 
     {
         private IRepositoryCrud<Venda> _repository;    
         private readonly IMapper _mapper;                                   
         private readonly ICurrentUserAccessor _currentUserAccessor;

          public VendaService(IRepositoryCrud<Venda> repository, IMapper mapper, ICurrentUserAccessor currentUserAccessor) 
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

          public async Task<IEnumerable<VendaDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  foreach (Venda venda in ListEntity)
                  {
                      foreach (Controle controle in venda.Controles)
                      {
                          if (controle.Ativo == 'I') venda.Controles.Remove(controle);
                      }
                  }
                  return _mapper.Map<IEnumerable<VendaDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<VendaDTOCreateReturn> Post(VendaDTOCreate venda) 
          {
              try 
              {
                  var model = _mapper.Map<VendaModel>(venda);
                  var entity = _mapper.Map<Venda>(model);
                  entity.Controles.ToList().ForEach(x => x.Venda = entity);
                  entity.Controles.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Controles.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Controles.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Controles.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<VendaDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<VendaDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  foreach (Controle controle in entity.Controles)
                  {
                      if (controle.Ativo == 'I') entity.Controles.Remove(controle);
                  }
                  return _mapper.Map<VendaDTOReference>(entity) ?? new VendaDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<VendaDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<VendaDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<VendaDTOUpdateReturn> Put(VendaDTOUpdate venda)
          {
              try 
              {
                  var model = _mapper.Map<VendaModel>(venda);
                  var entity = _mapper.Map<Venda>(model);

                  entity.Controles.ToList().ForEach(x => x.Venda = entity);
                  entity.Controles.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Controles.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Controles.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Controles.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var _itemCadastrado = await _repository.SelectAsync(entity.Idvenda);
                  foreach (Controle controle in _itemCadastrado.Controles)
                  {
                      if (entity.Controles.FirstOrDefault(x => x.Idcontrole == controle.Idcontrole) == null)
                      {
                          controle.Ativo = 'I';
                          controle.Datadeinativacao = DateTime.UtcNow;
                          controle.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                          entity.Controles.Add(controle);
                      }
                  }

                  foreach (Controle controle in entity.Controles)
                  {
                      var _itemFilhoCadastrado = _itemCadastrado.Controles.FirstOrDefault(x => x.Idcontrole == controle.Idcontrole);
                      if (_itemFilhoCadastrado != null)
                      {
                          controle.Usuariodeinclusao = _itemFilhoCadastrado.Usuariodeinclusao;
                          controle.Datadeinclusao = _itemFilhoCadastrado.Datadeinclusao;
                      }
                  }

                  var result = await _repository.UpdateAsync(entity, entity.Idvenda);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Idvenda);

                  return _mapper.Map<VendaDTOUpdateReturn>(retornodeAlteracao);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<VendaDTOReference>> GetAll(Guid Idcaixa)
          {
             try
             {
                var ListEntity = await _repository.SelectAsync();
                var ListEntityBy = ListEntity.Select(x => x.Caixa.Idcaixa.Equals(Idcaixa));

                return _mapper.Map<IEnumerable<VendaDTOReference>>(ListEntityBy);
             }
             catch (Exception ex)
             {
                throw ex;
             }
          }

          public async Task<IEnumerable<VendaDTOReference>> GetAllParametro(Guid Idparametro)
          {
             try
             {
                var ListEntity = await _repository.SelectAsync();
                var ListEntityBy = ListEntity.Select(x => x.Parametro.Idparametro.Equals(Idparametro));

                return _mapper.Map<IEnumerable<VendaDTOReference>>(ListEntityBy);
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
