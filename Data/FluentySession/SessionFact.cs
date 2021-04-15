using Data.Interfaces;
using Data.Mapping;
using NHibernate;

namespace Data.FluentySession
{
    public static class SessionFact
    {
        private static IFluentySessionFactory frameworkSessionFactory;
        private static IFluentySessionFactory frameworkSessionFactoryCrud;

        public static ISessionFactory GetSessionFact()
        {
            if (frameworkSessionFactory == null)
            {
                var connectionStringMySQL = "Server = acesso.cyzeslms577w.us-east-2.rds.amazonaws.com; Port = 3306; Database = Acesso; Uid = O2Si; Pwd = O2SiT3cnologia";
                frameworkSessionFactory = new FluentySessionFactory<UsuarioMap>(connectionStringMySQL, "mysql");
            }
            return frameworkSessionFactory.CreateSessionFactory();
        }

        // TODO: Ta dando erro aqui quando chama um objeto do CRUD
        public static ISessionFactory GetSessionFactCRUD()
        {
            if (frameworkSessionFactoryCrud == null)
            {
                var connectionStringMySQL = "Server =srjdoacoes.cyzeslms577w.us-east-2.rds.amazonaws.com; Port=3306; Database=SRJDoacoes; Uid=O2Siadmin; Pwd =123O2Siadmin123";
                frameworkSessionFactoryCrud = new FluentySessionFactory<O2sicontroleMap>(connectionStringMySQL, "mysql");
            }
            return (ISessionFactory)frameworkSessionFactoryCrud.CreateSessionFactory();
        }

    }
}
