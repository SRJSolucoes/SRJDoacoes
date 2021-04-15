using System;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;
using System.Collections.Generic;
using Domain.DTOs.CaixaDTO;
using Domain.DTOs.ParametroDTO;

namespace Domain.DTOs.VendaDTO {

    public class VendaDTOCreate
    {
        public ISet<CaixaDTOCreate> Caixa { get; set; }
 
        public ISet<ParametroDTOCreate> Parametro { get; set; }
 
        [StringLength(20, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 20 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Cpf { get; set; }
 
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Nome { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Datahota { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(8, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 8 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Decimal Valortotaldadoacao { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(8, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 8 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Decimal Valorretidoloja { get; set; }
 
        [StringLength(1, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 1 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Char Enviodigital { get; set; }
 
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Datadeenvio { get; set; }
 
        [StringLength(1, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 1 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Char Enviofinanceiro { get; set; }
 
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Datadeenviofinanceiro { get; set; }
 
        [StringLength(1, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 1 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Char Consolidado { get; set; }
 
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Datadeconsolidacao { get; set; }
 
        [StringLength(1, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 1 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Char Reciboemitido { get; set; }
 
    }
}
