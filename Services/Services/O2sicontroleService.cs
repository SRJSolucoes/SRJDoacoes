using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.O2sicontroleDTO;
using Domain.Interfaces;
using Domain.Entidades;
using Domain.Models;
using Service.Interfaces;

namespace Service.Services
{
     public class O2sicontroleService : IO2sicontroleService 
     {
         private IRepositoryCrud<O2sicontrole> _repository;    
         private readonly IMapper _mapper;                                   

          public O2sicontroleService(IRepositoryCrud<O2sicontrole> repository, IMapper mapper) 
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

          public async Task<IEnumerable<O2sicontroleDTOReference>> GetAll() 
          {
              try 
              {
                  var ListEntity = await _repository.SelectAsync();
                  return _mapper.Map<IEnumerable<O2sicontroleDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<O2sicontroleDTOCreateReturn> Post(O2sicontroleDTOCreate o2sicontrole) 
          {
              try 
              {
                  var model = _mapper.Map<O2sicontroleModel>(o2sicontrole);
                  var entity = _mapper.Map<O2sicontrole>(model);

                  var result = await _repository.InsertAsync(entity);
                  return _mapper.Map<O2sicontroleDTOCreateReturn>(result);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<O2sicontroleDTOReference> Get(Guid id) 
          {
              try 
              {
                  var entity = await _repository.SelectAsync(id);
                  return _mapper.Map<O2sicontroleDTOReference>(entity) ?? new O2sicontroleDTOReference();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<IEnumerable<O2sicontroleDTOReference>> GetAllInactives() 
          {
              try 
              {
                  var ListEntity = await _repository.GetInatives();
                  return _mapper.Map<IEnumerable<O2sicontroleDTOReference>>(ListEntity);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }

          public async Task<O2sicontroleDTOUpdateReturn> Put(O2sicontroleDTOUpdate o2sicontrole)
          {
              try 
              {
                  var model = _mapper.Map<O2sicontroleModel>(o2sicontrole);
                  var entity = _mapper.Map<O2sicontrole>(model);




                  var result = await _repository.UpdateAsync(entity, entity.Ido2sicontrole);
                  var retornodeAlteracao = await _repository.SelectAsync(entity.Ido2sicontrole);

                  return _mapper.Map<O2sicontroleDTOUpdateReturn>(retornodeAlteracao);
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
