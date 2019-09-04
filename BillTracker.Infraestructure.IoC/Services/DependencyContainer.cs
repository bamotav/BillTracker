using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BillTracker.Application;
using BillTracker.Application.Shared.Attributes;
using BillTracker.EntityFramework;
using BillTracker.Infraestructure.Interfaces;
using BillTracker.Infraestructure.Repository;
using BillTracker.Infraestructure.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace BillTracker.Web.Core.Services
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(scan =>
                          scan.FromAssemblyOf<BillTrackerApplicationModule>()
                          .AddClasses(c => c.WithAttribute<InjectionSingletonAttribute>())
                          .AsImplementedInterfaces()
                          .WithSingletonLifetime());


            services.Scan(scan =>
                          scan.FromAssemblyOf<BillTrackerApplicationModule>()
                          .AddClasses(c => c.WithAttribute<InjectionTransientLifetimeAttribute>())
                          .AsImplementedInterfaces()
                          .WithTransientLifetime());


            services.Scan(scan =>
                          scan.FromAssemblyOf<BillTrackerApplicationModule>()
                          .AddClasses(c => c.WithAttribute<InjectionScopedLifetimeAttribute>())
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillTracker API", Version = "v1" });
            });

            //Configuration AutoMapper
            services.AddAutoMapper((typeof(BillTrackerApplicationModule)).Assembly);
        }

        public static void ConfigureServices(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillTracker API V1");
            });
        }
    }

 
}
