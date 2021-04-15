using System;
using System.Collections.Generic; 
using Domain.DTOs.CaixaDTO;
using Domain.DTOs.ParametroDTO;

namespace Domain.DTOs.VendaDTO {

    public class VendaDTOCreateReturn
    {
        public Guid Idvenda { get; set; }
        public ISet<CaixaDTOReference> Caixa { get; set; }
        public ISet<ParametroDTOReference> Parametro { get; set; }
        public String Cpf { get; set; }
        public DateTime DatadeInclusao { get; set; }
    }
}
