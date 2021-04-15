using Data.FluentySession;
using Data.Implementations;
using Data.Mapping;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Renci.SshNet.Security;
using System;
using System.Collections.Generic;

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

            serviceCollection.AddScoped<Func<string, NHibernate.ISession>>(session => key =>
            {
                switch (key)
                {
                    case "Acesso":
                        return new SessionFactory().GetCurrentSession();
                    case "CRUD":
                        return new SessionFactory().GetCurrentSessionCRUD();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            serviceCollection.AddScoped<Func<string, ISessionFactory>>(factory => key =>
            {
                switch (key)
                {
                    case "Acesso":
                        return SessionFact.GetSessionFact();
                    case "CRUD":
                        return SessionFact.GetSessionFactCRUD();
                    default:
                        throw new KeyNotFoundException();
                }
            });
        }
    }
}
