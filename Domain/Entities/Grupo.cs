using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;

namespace Domain.Entidades {

    public class Grupo: EntidadeBase
    {
        public virtual Guid Idgrupo { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Nome { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        [StringLength(50, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Responsável { get; set; }

        public virtual String Logo { get; set; }

        public virtual ISet<Loja> Lojas  { get; set; } = new HashSet<Loja>();

        public virtual ISet<Parametro> Parametros  { get; set; } = new HashSet<Parametro>();

    }
}
