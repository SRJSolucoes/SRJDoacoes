using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class GrupoMap : ClassMap<Grupo>  {
         public GrupoMap() {

            Table("GRUPO");

            Id(x => x.Idgrupo).Column("IDGRUPO").GeneratedBy.Assigned();

            Map(x => x.Nome).Column("NOME").Not.Nullable();
            Map(x => x.Responsável).Column("RESPONSÁVEL").Not.Nullable();
            Map(x => x.Logo).Column("LOGO");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO");
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

            HasMany(x => x.Lojas).Cascade.All().Inverse().Not.LazyLoad();

            HasMany(x => x.Parametros).Cascade.All().Inverse().Not.LazyLoad();

        }
    }
}
