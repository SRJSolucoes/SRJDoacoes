using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.GrupoDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;
using AcessoWebApi.Infrastructure.Security;

namespace Service.Services
{
     public class GrupoService : IGrupoService 
     {
         private IRepositoryCrud<Grupo> _repository;    
         private readonly IMapper _mapper;                                   
         private readonly ICurrentUserAccessor _currentUserAccessor;

          public GrupoService(IRepositoryCrud<Grupo> repository, IMapper mapper, ICurrentUserAccessor currentUserAccessor) 
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

          public async Task<IEnumerable<GrupoDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  foreach (Grupo grupo in ListEntity)
                  {
                      foreach (Loja loja in grupo.Lojas)
                      {
                          if (loja.Ativo == 'I') grupo.Lojas.Remove(loja);
                      }
                      foreach (Parametro parametro in grupo.Parametros)
                      {
                          if (parametro.Ativo == 'I') grupo.Parametros.Remove(parametro);
                      }
                  }
                  return _mapper.Map<IEnumerable<GrupoDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<GrupoDTOCreateReturn> Post(GrupoDTOCreate grupo) 
          {
              try 
              {
                  var model = _mapper.Map<GrupoModel>(grupo);
                  var entity = _mapper.Map<Grupo>(model);
                  entity.Lojas.ToList().ForEach(x => x.Grupo = entity);
                  entity.Lojas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Lojas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Lojas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Lojas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);
                  entity.Parametros.ToList().ForEach(x => x.Grupo = entity);
                  entity.Parametros.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Parametros.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Parametros.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Parametros.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<GrupoDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<GrupoDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  foreach (Loja loja in entity.Lojas)
                  {
                      if (loja.Ativo == 'I') entity.Lojas.Remove(loja);
                  }
                  foreach (Parametro parametro in entity.Parametros)
                  {
                      if (parametro.Ativo == 'I') entity.Parametros.Remove(parametro);
                  }
                  return _mapper.Map<GrupoDTOReference>(entity) ?? new GrupoDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<GrupoDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<GrupoDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<GrupoDTOUpdateReturn> Put(GrupoDTOUpdate grupo)
          {
              try 
              {
                  var model = _mapper.Map<GrupoModel>(grupo);
                  var entity = _mapper.Map<Grupo>(model);

                  entity.Lojas.ToList().ForEach(x => x.Grupo = entity);
                  entity.Lojas.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Lojas.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Lojas.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Lojas.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);
                  entity.Parametros.ToList().ForEach(x => x.Grupo = entity);
                  entity.Parametros.ToList().ForEach(x => x.Ativo = 'A');
                  entity.Parametros.ToList().ForEach(x => x.Datadeinclusao = DateTime.UtcNow);
                  entity.Parametros.ToList().ForEach(x => x.Usuariodeinclusao = _currentUserAccessor.GetCurrentUser().Idusuario);
                  entity.Parametros.ToList().ForEach(x => x.Fkparceiro = _currentUserAccessor.GetCurrentUser().Idparceiro);

                  var _itemCadastrado = await _repository.SelectAsync(entity.Idgrupo);
                  foreach (Loja loja in _itemCadastrado.Lojas)
                  {
                      if (entity.Lojas.FirstOrDefault(x => x.Idloja == loja.Idloja) == null)
                      {
                          loja.Ativo = 'I';
                          loja.Datadeinativacao = DateTime.UtcNow;
                          loja.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                          entity.Lojas.Add(loja);
                      }
                  }
                  foreach (Parametro parametro in _itemCadastrado.Parametros)
                  {
                      if (entity.Parametros.FirstOrDefault(x => x.Idparametro == parametro.Idparametro) == null)
                      {
                          parametro.Ativo = 'I';
                          parametro.Datadeinativacao = DateTime.UtcNow;
                          parametro.Usuariodeinativacao = _currentUserAccessor.GetCurrentUser().Idusuario;

                          entity.Parametros.Add(parametro);
                      }
                  }

                  foreach (Loja loja in entity.Lojas)
                  {
                      var _itemFilhoCadastrado = _itemCadastrado.Lojas.FirstOrDefault(x => x.Idloja == loja.Idloja);
                      if (_itemFilhoCadastrado != null)
                      {
                          loja.Usuariodeinclusao = _itemFilhoCadastrado.Usuariodeinclusao;
                          loja.Datadeinclusao = _itemFilhoCadastrado.Datadeinclusao;
                      }
                  }
                  foreach (Parametro parametro in entity.Parametros)
                  {
                      var _itemFilhoCadastrado = _itemCadastrado.Parametros.FirstOrDefault(x => x.Idparametro == parametro.Idparametro);
                      if (_itemFilhoCadastrado != null)
                      {
                          parametro.Usuariodeinclusao = _itemFilhoCadastrado.Usuariodeinclusao;
                          parametro.Datadeinclusao = _itemFilhoCadastrado.Datadeinclusao;
                      }
                  }

                  var result = await _repository.UpdateAsync(entity, entity.Idgrupo);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Idgrupo);

                  return _mapper.Map<GrupoDTOUpdateReturn>(retornodeAlteracao);
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
