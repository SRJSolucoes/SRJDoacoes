using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Domain.DTOs.VendaDTO;

namespace Service.Interfaces
{
     public interface IVendaService
    {
        Task<VendaDTOReference> Get(Guid id);
        Task<IEnumerable<VendaDTOReference>> GetAll();
        Task<IEnumerable<VendaDTOReference>> GetAllInactives();
        Task<VendaDTOCreateReturn> Post(VendaDTOCreate venda);
        Task<VendaDTOUpdateReturn> Put(VendaDTOUpdate venda);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteAdmin(Guid id);
        Task<IEnumerable<VendaDTOReference>> GetAll(Guid Idcaixa);
        Task<IEnumerable<VendaDTOReference>> GetAllParametro(Guid Idparametro);
    }
}
