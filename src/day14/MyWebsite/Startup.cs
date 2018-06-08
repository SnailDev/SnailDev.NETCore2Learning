using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyWebsite.Filters;

namespace MyWebsite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                // config.Filters.Add(new ResultFilter());
                // config.Filters.Add(new ExceptionFilter());
                // config.Filters.Add(new ResourceFilter());
                config.Filters.Add(new ActionFilter() { Name = "Global", Order = 3 });
            });

            //  services.AddMvc(config =>
            // {
            //     config.Filters.Add(new AsyncResultFilter());
            //     config.Filters.Add(new AsyncExceptionFilter());
            //     config.Filters.Add(new AsyncResourceFilter());
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });

            app.UseMvcWithDefaultRoute();
        }
    }
}
