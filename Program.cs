using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Surveillance {

    /// <summary>
    /// �D�{��
    /// </summary>
    public class Program {

        /// <summary>
        /// �D�n�{��
        /// </summary>
        /// <param name="_Args">�Ѽ�</param>
        public static void Main(string[] _Args) {
            CreateWebHostBuilder(_Args).Build().Run();
        }


        /// <summary>
        /// �إ���B
        /// </summary>
        /// <param name="_Args">�Ѽ�</param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] _Args) {
            return WebHost.CreateDefaultBuilder(_Args)
                          .UseStartup<Startup>()
                          .ConfigureKestrel((Context, ServerOptions) => {
                              ServerOptions.Listen(IPAddress.Any, 5000);
                              /*
                              ServerOptions.Limits.MaxConcurrentConnections = 10 * 10 * 1024;
                              ServerOptions.Limits.MaxConcurrentUpgradedConnections = 10 * 1024;
                              ServerOptions.Limits.MaxRequestBodySize = 100 * 1024 * 1024; // 100MB�A�t�ιw�]30MB
                              ServerOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                              ServerOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
                              */
                          });
        }
    }
}