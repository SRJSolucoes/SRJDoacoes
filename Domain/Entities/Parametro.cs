using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;

namespace Domain.Entidades {

    public class Parametro: EntidadeBase
    {
        public virtual Guid Idparametro { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Grupo Grupo { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(30, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Chave { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(30, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Valor { get; set; }

        public virtual DateTime Validode { get; set; }

        public virtual DateTime Validoate { get; set; }

        public virtual ISet<Venda> Vendas  { get; set; } = new HashSet<Venda>();

    }
}
