using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class LojaMap : ClassMap<Loja>  {
         public LojaMap() {

            Table("LOJA");

            Id(x => x.Idloja).Column("IDLOJA").GeneratedBy.Assigned();

            Map(x => x.Nome).Column("NOME").Not.Nullable();
            Map(x => x.Responsavel).Column("RESPONSAVEL").Not.Nullable();
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO").Not.Nullable();
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

            References(x => x.Grupo).Column( "IDGRUPO").Not.ForeignKey();

            HasMany(x => x.Caixas).Cascade.All().Inverse().Not.LazyLoad();

        }
    }
}
