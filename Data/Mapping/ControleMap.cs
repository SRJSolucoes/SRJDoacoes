using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class ControleMap : ClassMap<Controle>  {
         public ControleMap() {

            Table("CONTROLE");

            Id(x => x.Idcontrole).Column("IDCONTROLE").GeneratedBy.Assigned();

            Map(x => x.Consolidado).Column("CONSOLIDADO");
            Map(x => x.Dataconsolidacao).Column("DATACONSOLIDACAO");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO").Not.Nullable();
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

            References(x => x.Venda).Column( "IDVENDA").Not.ForeignKey();

        }
    }
}
