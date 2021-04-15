using System;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;
using System.Collections.Generic;

namespace Domain.DTOs.GrupoDTO {

    public class GrupoDTOUpdate
    {
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Nome { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Responsável { get; set; }
 
//        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Logo { get; set; }
 
    }
}
