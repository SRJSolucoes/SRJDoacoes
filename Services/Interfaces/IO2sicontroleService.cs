using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.O2sicontroleDTO;

namespace Service.Interfaces
{
     public interface IO2sicontroleService
    {
        Task<O2sicontroleDTOReference> Get(Guid id);
        Task<IEnumerable<O2sicontroleDTOReference>> GetAll();
        Task<IEnumerable<O2sicontroleDTOReference>> GetAllInactives();
        Task<O2sicontroleDTOCreateReturn> Post(O2sicontroleDTOCreate o2sicontrole);
        Task<O2sicontroleDTOUpdateReturn> Put(O2sicontroleDTOUpdate o2sicontrole);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
    }
}
