using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillTracker.Application;
using BillTracker.Application.Shared;
using BillTracker.Application.Shared.Attributes;
using BillTracker.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BillTracker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddEntityFrameworkNpgsql().AddDbContext<BillTrackerContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


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
            //AppService;
            /* 
                var assemblies = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies()
                    .Where(a => a.FullName.StartsWith("BS"));

                assemblies.ToList().ForEach(a => {
                    var allServices = System.Reflection.Assembly.Load(a.Name).GetTypes().Where(t => t.Namespace != null && t.Name.EndsWith("Service"));
                    var hh = "";
                }); 
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
