using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.ControleDTO;

namespace Service.Interfaces
{
     public interface IControleService
    {
        Task<ControleDTOReference> Get(Guid id);
        Task<IEnumerable<ControleDTOReference>> GetAll();
        Task<IEnumerable<ControleDTOReference>> GetAllInactives();
        Task<ControleDTOCreateReturn> Post(ControleDTOCreate controle);
        Task<ControleDTOUpdateReturn> Put(ControleDTOUpdate controle);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
        Task<IEnumerable<ControleDTOReference>> GetAll(Guid Idvenda);
    }
}
