using System;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;
using System.Collections.Generic;
using Domain.DTOs.VendaDTO;

namespace Domain.DTOs.ControleDTO {

    public class ControleDTOCreate
    {
        public ISet<VendaDTOCreate> Venda { get; set; }
 
        [StringLength(1, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 1 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public Char Consolidado { get; set; }
 
        [StringLength(0, ErrorMessageResourceName = "Campo com tamanho excedido. Máximo permitido: 0 posições.", ErrorMessageResourceType = typeof(EntitiesResources))]
        public DateTime Dataconsolidacao { get; set; }
 
    }
}
