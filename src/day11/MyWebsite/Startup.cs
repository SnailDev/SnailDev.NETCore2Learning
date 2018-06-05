using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyWebsite.Wappers;

namespace MyWebsite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 将 Session 存在 ASP.NET Core 内存中
            services.AddDistributedMemoryCache();
            services.AddSession();
            // services.AddSession(options =>
            // {
            //     options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //     options.Cookie.Name = "mywebsite";
            //     options.IdleTimeout = TimeSpan.FromMinutes(5);
            // });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISessionWapper, SessionWapper>();

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

            // app.Run(async (context) =>
            // {
            //     string message;

            //     if (!context.Request.Cookies.TryGetValue("Sample", out message))
            //     {
            //         message = "Save data to cookies.";
            //     }
            //     context.Response.Cookies.Append("Sample", "This is Cookies.");
            //     // 刪除 Cookies 数据
            //     //context.Response.Cookies.Delete("Sample");

            //     await context.Response.WriteAsync($"{message}");
            // });

            // SessionMiddleware 加入 Pipeline
            app.UseSession();

            // app.Run(async (context) =>
            // {
            //     context.Session.SetString("Sample", "This is Session.");
            //     string message = context.Session.GetString("Sample");
            //     await context.Response.WriteAsync($"{message}");
            // });

            app.UseMvcWithDefaultRoute();
        }
    }
}
