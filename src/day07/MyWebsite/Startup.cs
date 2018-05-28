using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MyWebsite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Map("/first", mapApp =>
            // {
            //     mapApp.Run(async context =>
            //     {
            //         await context.Response.WriteAsync("First. \r\n");
            //     });
            // });

            // app.Map("/second", mapApp =>
            // {
            //     mapApp.Run(async context =>
            //     {
            //         await context.Response.WriteAsync("Second. \r\n");
            //     });
            // });

            // var defaultRouteHandler = new RouteHandler(context =>
            // {
            //     var routeValues = context.GetRouteData().Values;
            //     return context.Response.WriteAsync($"Route values: {string.Join(", ", routeValues)}");
            // });

            // var routeBuilder = new RouteBuilder(app, defaultRouteHandler);
            // routeBuilder.MapRoute("default", "{first:regex(^(default|home)$)}/{second?}");

            // routeBuilder.MapGet("user/{name}", context =>
            // {
            //     var name = context.GetRouteValue("name");
            //     return context.Response.WriteAsync($"Get user. name: {name}");
            // });

            // routeBuilder.MapPost("user/{name}", context =>
            // {
            //     var name = context.GetRouteValue("name");
            //     return context.Response.WriteAsync($"Create user. name: {name}");
            // });

            // var routes = routeBuilder.Build();
            // app.UseRouter(routes);

            // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "about",
                    template: "about",
                    defaults: new { controller = "Home", action = "About" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                // 跟上面设置的 default 效果一样
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller}/{action}/{id?}",
                //    defaults: new { controller = "Home", action = "Index" }
                //);
            });
        }
    }
}
