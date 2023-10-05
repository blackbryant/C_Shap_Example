using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace B進階觀念.Dapper範例
{
    public class Startup
    {

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IConfiguration config,
        ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }
 
        // This method gets called by the runtime. Use this method to add serices to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var logger = _loggerFactory.CreateLogger<Startup>();
            if (_env.IsDevelopment())
            {
                // 開發環境服務設定
                logger.LogInformation("Development environment");
            }
            else
            {
                // 非開發環境服務設定
                logger.LogInformation($"Environment: {_env.EnvironmentName}");
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //啟用中介軟體來提供產生的 JSON 檔和 Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseRouting();
            app.UseAuthorization();

           //需要加上路由屬性
            app.UseEndpoints(endpoints =>
            {

                //加上MapDefaultControllerRoute()
                endpoints.MapDefaultControllerRoute();
                //支援透過Attribute指定路由
                endpoints.MapControllers();
            });

        }
    }
    
}
