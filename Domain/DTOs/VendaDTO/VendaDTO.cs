using System;
using System.Collections.Generic;
using Domain.DTOs.CaixaDTO;
using Domain.DTOs.ParametroDTO;

namespace Domain.DTOs.VendaDTO {

    public class VendaDTO
    {
        public Guid Idvenda { get; set; }
        public ISet<CaixaDTOReference> Caixa { get; set; }
        public ISet<ParametroDTOReference> Parametro { get; set; }
        public String Cpf { get; set; }
        public String Nome { get; set; }
        public DateTime Datahota { get; set; }
        public Decimal Valortotaldadoacao { get; set; }
        public Decimal Valorretidoloja { get; set; }
        public Char Enviodigital { get; set; }
        public DateTime Datadeenvio { get; set; }
        public Char Enviofinanceiro { get; set; }
        public DateTime Datadeenviofinanceiro { get; set; }
        public Char Consolidado { get; set; }
        public DateTime Datadeconsolidacao { get; set; }
        public Char Reciboemitido { get; set; }
    }
}
