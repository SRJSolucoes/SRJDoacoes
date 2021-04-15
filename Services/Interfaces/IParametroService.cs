using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.ParametroDTO;

namespace Service.Interfaces
{
     public interface IParametroService
    {
        Task<ParametroDTOReference> Get(Guid id);
        Task<IEnumerable<ParametroDTOReference>> GetAll();
        Task<IEnumerable<ParametroDTOReference>> GetAllInactives();
        Task<ParametroDTOCreateReturn> Post(ParametroDTOCreate parametro);
        Task<ParametroDTOUpdateReturn> Put(ParametroDTOUpdate parametro);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
        Task<IEnumerable<ParametroDTOReference>> GetAll(Guid Idgrupo);
    }
}
