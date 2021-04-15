using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.LojaDTO;

namespace Service.Interfaces
{
     public interface ILojaService
    {
        Task<LojaDTOReference> Get(Guid id);
        Task<IEnumerable<LojaDTOReference>> GetAll();
        Task<IEnumerable<LojaDTOReference>> GetAllInactives();
        Task<LojaDTOCreateReturn> Post(LojaDTOCreate loja);
        Task<LojaDTOUpdateReturn> Put(LojaDTOUpdate loja);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
        Task<IEnumerable<LojaDTOReference>> GetAll(Guid Idgrupo);
    }
}
