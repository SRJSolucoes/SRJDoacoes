using AcessoWebApi.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using Microsoft.AspNetCore.Http;
using Domain.Interfaces;
using Domain.Security;

namespace Cross.Cutting.DependencyInjection 
{
    public static class ConfigureService 
    { 
        public static void ConfigureDependenceInjection(IServiceCollection serviceCollection) 
        { 
            serviceCollection.AddTransient<ICaixaService, CaixaService >(); 
   
            serviceCollection.AddTransient<IControleService, ControleService >(); 
   
            serviceCollection.AddTransient<IGrupoService, GrupoService >(); 
   
            serviceCollection.AddTransient<ILojaService, LojaService >(); 
   
            serviceCollection.AddTransient<IO2sicontroleService, O2sicontroleService >(); 
   
            serviceCollection.AddTransient<IParametroService, ParametroService >(); 
   
            serviceCollection.AddTransient<IVendaService, VendaService >(); 
   
            serviceCollection.AddTransient<IHttpContextAccessor, HttpContextAccessor>(); 
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IPasswordHasher, PasswordHasher>();
            serviceCollection.AddTransient<ICurrentUserAccessor, CurrentUserAccessor>();
        } 
    }      
} 
