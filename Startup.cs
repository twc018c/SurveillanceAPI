using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
using System.Threading;
using System.Threading.Tasks;


namespace Surveillance {

    /// <summary>
    /// 啟動
    /// </summary>
    public class Startup {

        public readonly IConfiguration Configuration;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_Configuration">設定</param>
        public Startup(IConfiguration _Configuration) {
            Configuration = _Configuration;

            // 讀取appsettings.json
            try {
                // 設定檔
                Global.ConnectionString = this.Configuration.GetConnectionString("DefaultConnection");
                Global.JWTSecret = Configuration.GetSection("JWT:Secret").Value;
                Global.ScienerID = Configuration.GetSection("Sciener:ID").Value;
                Global.ScienerSecret = Configuration.GetSection("Sciener:Secret").Value;
                Global.ScienerUsername = Configuration.GetSection("Sciener:Username").Value;
                Global.ScienerPassword = Configuration.GetSection("Sciener:Password").Value;
            } catch (Exception Exception) {
                // NOTHING
            }
        }


        /// <summary>
        /// 注入服務
        /// </summary>
        /// <param name="_Services">服務</param>
        public void ConfigureServices(IServiceCollection _Services) {
            // MySQL
            _Services.AddDbContextPool<DatabaseContext>(Option => {
                Option.UseMySql(Global.ConnectionString, ServerVersion.AutoDetect(Global.ConnectionString))
                      .EnableDetailedErrors()
                      .EnableSensitiveDataLogging();
            });

            // 跨網域存取
            _Services.AddCors(Option => {
                Option.AddPolicy("CorsPolicy", Policy =>
                    Policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowAnyOrigin()
                    );
            });

            // AutoMapper
            _Services.AddAutoMapper(typeof(Startup));

            // Controller
            _Services.AddControllers();
            _Services.AddMvc();

            // HTTP
            _Services.AddHttpClient();

            // Repository
            _Services.AddTransient<ICardAuthorityRepository, CardAuthorityRepository>();
            _Services.AddTransient<ICardBatchRepository, CardBatchRepository>();
            _Services.AddTransient<ICardRepository, CardRepository>();
            _Services.AddTransient<IDoorRepository, DoorRepository>();
            _Services.AddTransient<IEventLogRepository, EventLogRepository>();
            _Services.AddTransient<IUserRepository, UserRepository>();
            _Services.AddTransient<IUserLogRepository, UserLogRepository>();

            // Service
            _Services.AddTransient<IDashboardService, DashboardService>();
            _Services.AddSingleton<IJWTService, JWTService>();
            _Services.AddSingleton<IScienerService, ScienerService>();
            _Services.AddSingleton<IUIService, UIService>();

            // Swagger
            _Services.AddSwaggerGen(Option => {
                Option.ExampleFilters();
                Option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "API.xml"));
                Option.SwaggerDoc("v1", new OpenApiInfo { Title = "Surveillance", Version = "v1" });
                
                // 排序
                Option.OrderActionsBy(x => x.RelativePath);

                // 權限鎖
                Option.OperationFilter<AddResponseHeadersFilter>();

                // 標題備註 (Auth字樣)
                Option.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 標頭
                Option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Name = "Authorization",
                    Description = "請輸入權杖，例如 'Bearer {Token}'",
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
            _Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Global.JWTSecret)),
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });

            // 建立服務供應 (必須設定完所有服務才能建立)
            ProviderService.Collection = _Services.BuildServiceProvider();
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
            }

            _App.UseCors("CorsPolicy");
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

            try {
                // 取得服務
                var ScienerService = _App.ApplicationServices.GetService<IScienerService>();

                // 取得令牌
                var Model = ScienerService.GetToken().GetAwaiter().GetResult();
            } catch (Exception Exception) {
                Console.WriteLine($"Startup {Exception.Message}");
            }
        }
    }
}