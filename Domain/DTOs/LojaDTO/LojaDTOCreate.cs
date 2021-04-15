using System;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;
using System.Collections.Generic;
using Domain.DTOs.GrupoDTO;

namespace Domain.DTOs.LojaDTO {

    public class LojaDTOCreate
    {
        public ISet<GrupoDTOCreate> Grupo { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Nome { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Responsavel { get; set; }
 
    }
}
