using System;
using System.Collections.Generic;
using Domain.DTOs.GrupoDTO;

namespace Domain.DTOs.ParametroDTO {

    public class ParametroDTO
    {
        public Guid Idparametro { get; set; }
        public ISet<GrupoDTOReference> Grupo { get; set; }
        public String Chave { get; set; }
        public String Valor { get; set; }
        public DateTime Validode { get; set; }
        public DateTime Validoate { get; set; }
    }
}
