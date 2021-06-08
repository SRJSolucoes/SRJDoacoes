﻿using AutoMapper;
using Cross.Cutting.DependencyInjection;
using Cross.Cutting.Mapping;
using Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcessoWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Injeção de Dependência
            ConfigureRepository.ConfigureDependenceRepository(services);
            ConfigureService.ConfigureDependenceInjection(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntitiToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfiguration = new SigningConfigurations();
            services.AddSingleton(signingConfiguration);

            // Authentication
            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfiguration.Key;
                paramsValidation.ValidAudience = tokenConfiguration.Audience;
                paramsValidation.ValidIssuer = tokenConfiguration.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Admin", new AuthorizationPolicyBuilder()
                                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                .RequireAuthenticatedUser()
                                .RequireRole("Admin").Build());

                auth.AddPolicy("UserAdmin", new AuthorizationPolicyBuilder()
                                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                .RequireAuthenticatedUser()
                                .RequireRole("UserAdmin", "Admin").Build());

                auth.AddPolicy("User", new AuthorizationPolicyBuilder()
                              .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                              .RequireAuthenticatedUser()
                              .RequireRole("UserAdmin", "Admin", "User").Build());
            });

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "SRJ - Serviço de Doações",
                    Version = "1.0.0",
                    Description = "SRJ Micro Services Version 1.0.0 ",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "SRJ Soluções",
                        Email = "contato@srjsolucoes.com.br"
                    }
                });

                c.AddSecurityDefinition("User", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "User" }
                            }, new List<string>() }
                    });
            });

            // Instalar no IIS
            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.SetIsOriginAllowed(origin => true)
                //.AllowCredentials()
                );

            });

            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "SRJ Soluções");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^S", "swagger");
            app.UseRewriter(option);

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();
            app.UseEndpoints(endpoint => { endpoint.MapControllers(); });
        }
    }
}
