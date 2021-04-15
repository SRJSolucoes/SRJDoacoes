using System;
using System.Collections.Generic;

namespace Domain.DTOs.GrupoDTO {

    public class GrupoDTOUpdateReturn
    {
        public Guid Idgrupo { get; set; }
        public String Nome { get; set; }
        public DateTime DatadeAlteracao { get; set; }
    }
}
