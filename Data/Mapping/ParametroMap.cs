using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class ParametroMap : ClassMap<Parametro>  {
         public ParametroMap() {

            Table("PARAMETRO");

            Id(x => x.Idparametro).Column("IDPARAMETRO").GeneratedBy.Assigned();

            Map(x => x.Chave).Column("CHAVE").Not.Nullable();
            Map(x => x.Valor).Column("VALOR").Not.Nullable();
            Map(x => x.Validode).Column("VALIDODE");
            Map(x => x.Validoate).Column("VALIDOATE");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO");
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

            References(x => x.Grupo).Column( "IDGRUPO").Not.ForeignKey();

            HasMany(x => x.Vendas).Cascade.All().Inverse().Not.LazyLoad();

        }
    }
}
