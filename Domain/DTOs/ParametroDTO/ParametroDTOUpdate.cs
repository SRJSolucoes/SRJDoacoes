using System;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;
using System.Collections.Generic;
using Domain.DTOs.GrupoDTO;

namespace Domain.DTOs.ParametroDTO {

    public class ParametroDTOUpdate
    {
        public ISet<GrupoDTOUpdate> Grupo { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(30, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 30 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Chave { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(30, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 30 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Valor { get; set; }
 
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Validode { get; set; }
 
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Validoate { get; set; }
 
    }
}
