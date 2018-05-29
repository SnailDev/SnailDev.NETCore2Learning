using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
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

            // var rewrite = new RewriteOptions()
            //             .AddRewrite("about.aspx", "home/about", skipRemainingRules: true)
            //             .AddRedirect("first", "home/index");

            //var rewrite = new RewriteOptions().AddRedirect("first", "home/index", 302);

            var rewrite = new RewriteOptions()
                        .AddRedirect(@"products.aspx?id=(\w+)", "prosucts/$1", 301)
                        .AddRedirect(@"api/(.*)/(.*)/(.*)", "api?p1=$1&p2=$2&p3=$3", 301);

            app.UseRewriter(rewrite);
            app.UseMvcWithDefaultRoute();
        }
    }
}
