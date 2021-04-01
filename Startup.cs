using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Surveillance.Interfaces;
using Surveillance.Repositories;
using Surveillance.Schafold;
using Surveillance.Services;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;
using System.Text;


namespace Surveillance {

    /// <summary>
    /// �Ұ�
    /// </summary>
    public class Startup {

        public IConfiguration Configuration { get; }


        /// <summary>
        /// �غc
        /// </summary>
        /// <param name="_Configuration">�]�w</param>
        public Startup(IConfiguration _Configuration) {
            Configuration = _Configuration;
        }


        /// <summary>
        /// �`�J�A��
        /// </summary>
        /// <param name="_Services">�A��</param>
        public void ConfigureServices(IServiceCollection _Services) {
            // �]�w��
            Global.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            Global.Secret = Configuration.GetSection("JWT:Secret").Value;

            // MySQL
            _Services.AddDbContextPool<DatabaseContext>(Option => {
                Option.UseMySql(Global.ConnectionString, ServerVersion.AutoDetect(Global.ConnectionString))
                       .EnableDetailedErrors()
                       .EnableSensitiveDataLogging();
            });

            // �����s��
            _Services.AddCors(Options => {
                Options.AddPolicy("CorsPolicy", Policy =>
                    Policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowAnyOrigin()
                    );
            });

            // Controller
            _Services.AddControllers();
            _Services.AddMvc();

            // Repository
            _Services.AddTransient<IUserRepository, UserRepository>();

            // Service
            _Services.AddSingleton<IJWTService, JWTService>();

            // Swagger
            _Services.AddSwaggerGen(Option => {
                Option.ExampleFilters();
                Option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "API.xml"));
                Option.SwaggerDoc("v1", new OpenApiInfo { Title = "Surveillance", Version = "v1" });
                
                // �Ƨ�
                Option.OrderActionsBy(x => x.RelativePath);

                // �v����
                Option.OperationFilter<AddResponseHeadersFilter>();
                Option.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // Header
                Option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    Description = "Please insert JWT with Bearer into field",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                Option.AddSecurityRequirement(new OpenApiSecurityRequirement {{
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });

            // JWT
            _Services.AddAuthentication(Option => {
                Option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(Option => {
                Option.RequireHttpsMetadata = false;
                Option.SaveToken = true;
                Option.TokenValidationParameters = new TokenValidationParameters {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Global.Secret)),
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });

            _Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
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
            }

            _App.UseRouting();
            _App.UseAuthorization();
            _App.UseAuthentication();

            _App.UseEndpoints(Item => {
                Item.MapControllers();
            });

            _App.UseSwagger();
            _App.UseSwaggerUI(Option => {
                Option.DocExpansion(DocExpansion.None);
                Option.DocumentTitle = "Surveillance";
                Option.SwaggerEndpoint("/swagger/v1/swagger.json", "Surveillance v1");
            });
        }
    }
}