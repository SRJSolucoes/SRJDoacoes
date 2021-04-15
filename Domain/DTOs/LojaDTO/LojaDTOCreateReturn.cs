using System;
using System.Collections.Generic; 
using Domain.DTOs.GrupoDTO;

namespace Domain.DTOs.LojaDTO {

    public class LojaDTOCreateReturn
    {
        public Guid Idloja { get; set; }
        public ISet<GrupoDTOReference> Grupo { get; set; }
        public String Nome { get; set; }
        public DateTime DatadeInclusao { get; set; }
    }
}
