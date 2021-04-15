using System;
using System.Collections.Generic; 
using Domain.DTOs.GrupoDTO;

namespace Domain.DTOs.ParametroDTO {

    public class ParametroDTOCreateReturn
    {
        public Guid Idparametro { get; set; }
        public ISet<GrupoDTOReference> Grupo { get; set; }
        public String Chave { get; set; }
        public DateTime DatadeInclusao { get; set; }
    }
}
