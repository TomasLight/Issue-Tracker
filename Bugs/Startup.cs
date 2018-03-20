﻿using System;
using DataLayer.Context;
using DataLayer.Reposotories.Api;
using DataLayer.Reposotories.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using React.AspNet;

namespace Bugs
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
            this.RegContextViaDepInject(services);
            services.AddScoped<IRepositoryFacade, RepositoryFacade>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();
            app.UseReact(config => { });
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void RegContextViaDepInject(IServiceCollection services)
        {
#if DEBUG
            services.AddDbContext<BugContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DebugConnection")));
#else
            services.AddDbContext<BugContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("ReleaseConnection")));
#endif
        }
    }
}
