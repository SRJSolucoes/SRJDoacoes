using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class O2sicontroleMap : ClassMap<O2sicontrole>  {
         public O2sicontroleMap() {

            Table("O2SICONTROLE");

            Id(x => x.Ido2sicontrole).Column("IDO2SICONTROLE").GeneratedBy.Assigned();

            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO").Not.Nullable();
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

        }
    }
}
