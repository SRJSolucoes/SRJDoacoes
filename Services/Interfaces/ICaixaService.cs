using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.CaixaDTO;

namespace Service.Interfaces
{
     public interface ICaixaService
    {
        Task<CaixaDTOReference> Get(Guid id);
        Task<IEnumerable<CaixaDTOReference>> GetAll();
        Task<IEnumerable<CaixaDTOReference>> GetAllInactives();
        Task<CaixaDTOCreateReturn> Post(CaixaDTOCreate caixa);
        Task<CaixaDTOUpdateReturn> Put(CaixaDTOUpdate caixa);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
        Task<IEnumerable<CaixaDTOReference>> GetAll(Guid Idloja);
    }
}
