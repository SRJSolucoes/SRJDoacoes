using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.GrupoDTO;

namespace Service.Interfaces
{
     public interface IGrupoService
    {
        Task<GrupoDTOReference> Get(Guid id);
        Task<IEnumerable<GrupoDTOReference>> GetAll();
        Task<IEnumerable<GrupoDTOReference>> GetAllInactives();
        Task<GrupoDTOCreateReturn> Post(GrupoDTOCreate grupo);
        Task<GrupoDTOUpdateReturn> Put(GrupoDTOUpdate grupo);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
    }
}
