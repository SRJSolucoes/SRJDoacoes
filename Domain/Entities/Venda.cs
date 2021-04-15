using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Resources;

namespace Domain.Entidades {

    public class Venda: EntidadeBase
    {
        public virtual Guid Idvenda { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Caixa Caixa { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Parametro Parametro { get; set; }

        [StringLength(20, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Cpf { get; set; }

        [StringLength(50, ErrorMessageResourceName = "Campo_com_tamanho_excedido", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual String Nome { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual DateTime Datahota { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Decimal Valortotaldadoacao { get; set; }

        [Required(ErrorMessageResourceName = "Campo_obrigatorio", ErrorMessageResourceType = typeof(EntitiesResources))]
        public virtual Decimal Valorretidoloja { get; set; }

        public virtual Char Enviodigital { get; set; }

        public virtual DateTime Datadeenvio { get; set; }

        public virtual Char Enviofinanceiro { get; set; }

        public virtual DateTime Datadeenviofinanceiro { get; set; }

        public virtual Char Consolidado { get; set; }

        public virtual DateTime Datadeconsolidacao { get; set; }

        public virtual Char Reciboemitido { get; set; }

        public virtual ISet<Controle> Controles  { get; set; } = new HashSet<Controle>();

    }
}
