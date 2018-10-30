using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Model;
using Stock.WebApi.DTOs;
using Tnf.Configuration;

namespace Stock.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTnfAspNetCore();
            services.AddTnfNotifications();
            services.AddStockDomain();
            services.AddStockMessaging();
            services.AddStockSqlServerEntityFramework(Configuration);

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseTnfAspNetCore(config =>
            {
                config.MultiTenancy(mc => mc.IsEnabled = true);

                config.ConfigureStockMessaging(Configuration);
            });

            app.UseMvc();
        }
    }
}
