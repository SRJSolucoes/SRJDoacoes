using System;
using System.Collections.Generic; 
using Domain.DTOs.VendaDTO;

namespace Domain.DTOs.ControleDTO {

    public class ControleDTOCreateReturn
    {
        public Guid Idcontrole { get; set; }
        public ISet<VendaDTOReference> Venda { get; set; }
        public Char Consolidado { get; set; }
        public DateTime DatadeInclusao { get; set; }
    }
}
