using Domain.Entidades;
using FluentNHibernate.Mapping;

namespace Data.Mapping {
     public class VendaMap : ClassMap<Venda>  {
         public VendaMap() {

            Table("VENDA");

            Id(x => x.Idvenda).Column("IDVENDA").GeneratedBy.Assigned();

            Map(x => x.Cpf).Column("CPF");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Datahota).Column("DATAHOTA").Not.Nullable();
            Map(x => x.Valortotaldadoacao).Column("VALORTOTALDADOACAO").Not.Nullable();
            Map(x => x.Valorretidoloja).Column("VALORRETIDOLOJA").Not.Nullable();
            Map(x => x.Enviodigital).Column("ENVIODIGITAL");
            Map(x => x.Datadeenvio).Column("DATADEENVIO");
            Map(x => x.Enviofinanceiro).Column("ENVIOFINANCEIRO");
            Map(x => x.Datadeenviofinanceiro).Column("DATADEENVIOFINANCEIRO");
            Map(x => x.Consolidado).Column("CONSOLIDADO");
            Map(x => x.Datadeconsolidacao).Column("DATADECONSOLIDACAO");
            Map(x => x.Reciboemitido).Column("RECIBOEMITIDO");
            Map(x => x.Ativo).Column("ATIVO");
            Map(x => x.Datadeinclusao).Column("DATADEINCLUSAO").Not.Nullable();
            Map(x => x.Datadealteracao).Column("DATADEALTERACAO");
            Map(x => x.Datadeinativacao).Column("DATADEINATIVACAO");
            Map(x => x.Usuariodeinclusao).Column("USUARIODEINCLUSAO").Not.Nullable();
            Map(x => x.Usuariodealteracao).Column("USUARIODEALTERACAO");
            Map(x => x.Usuariodeinativacao).Column("USUARIODEINATIVACAO");
            Map(x => x.Fkparceiro).Column("FKPARCEIRO").Not.Nullable();

            References(x => x.Caixa).Column( "IDCAIXA").Not.ForeignKey();

            References(x => x.Parametro).Column( "IDPARAMETRO").Not.ForeignKey();

            HasMany(x => x.Controles).Cascade.All().Inverse().Not.LazyLoad();

        }
    }
}
