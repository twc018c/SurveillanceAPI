using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Surveillance.Interfaces;
using Surveillance.Repositories;
using Surveillance.Schafold;
using System;
using System.IO;


namespace Surveillance {

    /// <summary>
    /// 啟動
    /// </summary>
    public class Startup {

        public IConfiguration Configuration { get; }


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_Configuration"></param>
        public Startup(IConfiguration _Configuration) {
            Configuration = _Configuration;
        }


        /// <summary>
        /// 注入服務
        /// </summary>
        /// <param name="_Services">服務</param>
        public void ConfigureServices(IServiceCollection _Services) {
            string ConnectionString = Configuration.GetConnectionString("DefaultConnection");

            // 跨網域存取
            _Services.AddCors(Options => {
                Options.AddPolicy("CorsPolicy", Policy =>
                    Policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowAnyOrigin()
                    );
            });

            // MySQL
            _Services.AddDbContextPool<MySQLContext>(Option => {
                Option.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString))
                       .EnableDetailedErrors()
                       .EnableSensitiveDataLogging();
            });

            // Controller
            _Services.AddControllers();

            // Repository
            _Services.AddTransient<IUserRepository, UserRepository>();

            // Swagger
            _Services.AddSwaggerGen(Option => {
                Option.SwaggerDoc("v1", new OpenApiInfo { Title = "Surveillance", Version = "v1" });
                Option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "API.xml"));
            });
        }


        /// <summary>
        /// 設定
        /// </summary>
        /// <remarks>
        /// Middleware
        /// </remarks>
        /// <param name="_App">應用程式</param>
        /// <param name="_Env">環境</param>
        public void Configure(IApplicationBuilder _App, IWebHostEnvironment _Env) {
            if (_Env.IsDevelopment()) {
                _App.UseDeveloperExceptionPage();
                _App.UseSwagger();
                _App.UseSwaggerUI(Option => Option.SwaggerEndpoint("/swagger/v1/swagger.json", "Surveillance v1"));
            }

            _App.UseRouting();
            _App.UseAuthorization();
            _App.UseEndpoints(Item => {
                Item.MapControllers();
            });
        }
    }
}