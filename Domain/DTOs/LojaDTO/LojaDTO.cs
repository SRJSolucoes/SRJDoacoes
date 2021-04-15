using System;
using System.Collections.Generic;
using Domain.DTOs.GrupoDTO;

namespace Domain.DTOs.LojaDTO {

    public class LojaDTO
    {
        public Guid Idloja { get; set; }
        public ISet<GrupoDTOReference> Grupo { get; set; }
        public String Nome { get; set; }
        public String Responsavel { get; set; }
    }
}
