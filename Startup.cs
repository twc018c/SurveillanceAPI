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
    /// �Ұ�
    /// </summary>
    public class Startup {

        public IConfiguration Configuration { get; }


        /// <summary>
        /// �غc
        /// </summary>
        /// <param name="_Configuration"></param>
        public Startup(IConfiguration _Configuration) {
            Configuration = _Configuration;
        }


        /// <summary>
        /// �`�J�A��
        /// </summary>
        /// <param name="_Services">�A��</param>
        public void ConfigureServices(IServiceCollection _Services) {
            string ConnectionString = Configuration.GetConnectionString("DefaultConnection");

            // �����s��
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
        /// �]�w
        /// </summary>
        /// <remarks>
        /// Middleware
        /// </remarks>
        /// <param name="_App">���ε{��</param>
        /// <param name="_Env">����</param>
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