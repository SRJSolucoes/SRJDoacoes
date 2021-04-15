using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;

namespace Domain.Entidades {

    public class Controle: EntidadeBase
    {
        public virtual Guid Idcontrole { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Venda Venda { get; set; }

        public virtual Char Consolidado { get; set; }

        public virtual DateTime Dataconsolidacao { get; set; }

    }
}
