using System;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;
using System.Collections.Generic;
using Domain.DTOs.LojaDTO;

namespace Domain.DTOs.CaixaDTO {

    public class CaixaDTOCreate
    {
        public ISet<LojaDTOCreate> Loja { get; set; }
 
        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Codigo { get; set; }
 
        [StringLength(50, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 50 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public String Descrição { get; set; }
 
    }
}
