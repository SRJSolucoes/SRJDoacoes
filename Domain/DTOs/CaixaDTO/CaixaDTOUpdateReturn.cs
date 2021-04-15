using System;
using System.Collections.Generic;
using Domain.DTOs.LojaDTO;

namespace Domain.DTOs.CaixaDTO {

    public class CaixaDTOUpdateReturn
    {
        public Guid Idcaixa { get; set; }
        public ISet<LojaDTOReference> Loja { get; set; }
        public String Codigo { get; set; }
        public DateTime DatadeAlteracao { get; set; }
    }
}
