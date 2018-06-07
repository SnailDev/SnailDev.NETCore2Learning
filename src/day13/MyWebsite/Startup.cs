using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace MyWebsite
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    // options.SerializerSettings.ContractResolver 
                    //     = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.NullValueHandling
                       = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Api.xml");
                c.IncludeXmlComments(filePath);
                c.SwaggerDoc(
                    // name: 关系到 SwaggerDocument 的 URL 位置。
                    name: "v1",
                    // info: 是用于 SwaggerDocument 版本信息的提示(內容非必填)。
                    info: new Info
                    {
                        Title = "RESTful API",
                        Version = "1.0.0",
                        Description = "This is ASP.NET Core RESTful API Sample.",
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "SnailDev",
                            Url = "http://www.cnblogs.com/snaildev/"
                        },
                        License = new License
                        {
                            Name = "CC BY-NC-SA 4.0",
                            Url = "https://creativecommons.org/licenses/by-nc-sa/4.0/"
                        }
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    // url: 需配合 SwaggerDoc 的 name。 "/swagger/{SwaggerDoc name}/swagger.json"
                    url: "/swagger/v1/swagger.json",
                    // name: 用于 Swagger UI 右上角选择不同版本的 SwaggerDocument 提示名称使用。
                    name: "RESTful API v1.0.0"
                );
            });

            app.UseMvc();
        }
    }
}
