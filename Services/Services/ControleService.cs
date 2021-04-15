using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.ControleDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;

namespace Service.Services
{
     public class ControleService : IControleService 
     {
         private IRepositoryCrud<Controle> _repository;    
         private readonly IMapper _mapper;                                   

          public ControleService(IRepositoryCrud<Controle> repository, IMapper mapper) 
          {
              _repository = repository;
              _mapper = mapper;
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

          public async Task<IEnumerable<ControleDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  return _mapper.Map<IEnumerable<ControleDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<ControleDTOCreateReturn> Post(ControleDTOCreate controle) 
          {
              try 
              {
                  var model = _mapper.Map<ControleModel>(controle);
                  var entity = _mapper.Map<Controle>(model);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<ControleDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<ControleDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  return _mapper.Map<ControleDTOReference>(entity) ?? new ControleDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<ControleDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<ControleDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<ControleDTOUpdateReturn> Put(ControleDTOUpdate controle)
          {
              try 
              {
                  var model = _mapper.Map<ControleModel>(controle);
                  var entity = _mapper.Map<Controle>(model);




                  var result = await _repository.UpdateAsync(entity, entity.Idcontrole);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Idcontrole);

                  return _mapper.Map<ControleDTOUpdateReturn>(retornodeAlteracao);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<ControleDTOReference>> GetAll(Guid Idvenda)
          {
             try
             {
                var ListEntity = await _repository.SelectAsync();
                var ListEntityBy = ListEntity.Select(x => x.Venda.Idvenda.Equals(Idvenda));

                return _mapper.Map<IEnumerable<ControleDTOReference>>(ListEntityBy);
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
