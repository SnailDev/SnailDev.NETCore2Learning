using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyWebsite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("First Middleware in. \r\n");
            //     await next.Invoke();
            //     await context.Response.WriteAsync("First Middleware out. \r\n");
            // });

             //app.UseMiddleware<FirstMiddleware>();
             app.UseFirstMiddleware();

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Second Middleware in. \r\n");

            //     // 水管阻塞，封包不往后送
            //     var condition = false;
            //     if (condition)
            //     {
            //         await next.Invoke();
            //     }
            //     await context.Response.WriteAsync("Second Middleware out. \r\n");
            // });

            app.Map("/second", mapApp =>
            {
                mapApp.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Second Middleware in. \r\n");
                    await next.Invoke();
                    await context.Response.WriteAsync("Second Middleware out. \r\n");
                });
                mapApp.Run(async context =>
                {
                    await context.Response.WriteAsync("Second. \r\n");
                });
            });


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Third Middleware in. \r\n");
                await next.Invoke();
                await context.Response.WriteAsync("Third Middleware out. \r\n");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World! \r\n");
            });
        }
    }
}
