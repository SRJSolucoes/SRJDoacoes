using System;
using System.Collections.Generic;

namespace Domain.DTOs.GrupoDTO {

    public class GrupoDTO
    {
        public Guid Idgrupo { get; set; }
        public String Nome { get; set; }
        public String Responsável { get; set; }
        public String Logo { get; set; }
    }
}
