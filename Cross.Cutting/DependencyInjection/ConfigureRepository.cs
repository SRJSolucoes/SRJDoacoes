using Data.FluentySession;
using Data.Implementations;
using Data.Interfaces;
using Data.Mapping;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace Cross.Cutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenceRepository(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped(typeof(IRepositoryCrud<>), typeof(RepositoryBaseCrud<>));

            serviceCollection.AddScoped<IUsuarioRepository, UsuarioImplementations>();
            serviceCollection.AddScoped<IFluentySessionFactory, FluentySessionFactory<UsuarioMap>>();


            serviceCollection.AddScoped<ISessionFactory>(factory =>
            {
                return SessionFact.GetSessionFact();
            });

            serviceCollection.AddScoped<ISessionFactoryCRUD>(factory =>
            {
                return (ISessionFactoryCRUD) SessionFact.GetSessionFactCRUD();
            });

            serviceCollection.AddScoped<ISession>(session =>
            {
              return new SessionFactory().GetCurrentSession();
            });

            serviceCollection.AddScoped<ISessionCRUD>(sessioncrud =>
            {
                return (ISessionCRUD) new SessionFactoryCRUD().GetCurrentSessionCRUD(); ; 
            });
        }
    }
}
