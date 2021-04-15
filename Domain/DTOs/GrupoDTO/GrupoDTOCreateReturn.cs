using System;
using System.Collections.Generic; 

namespace Domain.DTOs.GrupoDTO {

    public class GrupoDTOCreateReturn
    {
        public Guid Idgrupo { get; set; }
        public String Nome { get; set; }
        public DateTime DatadeInclusao { get; set; }
    }
}
