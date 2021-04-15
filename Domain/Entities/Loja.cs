using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;

namespace Domain.Entidades {

    public class Loja: EntidadeBase
    {
        public virtual Guid Idloja { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Grupo Grupo { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Nome { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Responsavel { get; set; }

        public virtual ISet<Caixa> Caixas  { get; set; } = new HashSet<Caixa>();

    }
}
