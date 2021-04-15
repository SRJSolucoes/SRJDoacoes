using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class CaixaMap : ClassMap<Caixa>  {
         public CaixaMap() {

            Table("CAIXA");

            Id(x => x.Idcaixa).Column("IDCAIXA").GeneratedBy.Assigned();

            Map(x => x.Codigo).Column("CODIGO").Not.Nullable();
            Map(x => x.Descrição).Column("DESCRIÇÃO");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO").Not.Nullable();
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

            References(x => x.Loja).Column( "IDLOJA").Not.ForeignKey();

            HasMany(x => x.Vendas).Cascade.All().Inverse().Not.LazyLoad();

        }
    }
}
