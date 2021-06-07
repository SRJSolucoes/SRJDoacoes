using Data.Mapping;
using NHibernate;
namespace Data.FluentySession
{
    public static class SessionFactCRUD
    {
        private static IFluentySessionFactory frameworkSessionFactoryCRUD;

        public static ISessionFactory GetSessionFact()
        {
            if (frameworkSessionFactoryCRUD == null)
            {
                var connectionStringMySQL = "Server =srjdoacoes.cyzeslms577w.us-east-2.rds.amazonaws.com; Port=3306; Database=SRJDoacoes; Uid=O2Siadmin; Pwd =123O2Siadmin123";
                frameworkSessionFactoryCRUD = new FluentySessionFactory<O2sicontroleMap>(connectionStringMySQL, "mysql");
            }
            return frameworkSessionFactoryCRUD.CreateSessionFactory();
        }

    }
}
