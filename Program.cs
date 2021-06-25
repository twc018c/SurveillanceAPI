using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Surveillance {

    /// <summary>
    /// 祘Α
    /// </summary>
    public class Program {

        /// <summary>
        /// 璶祘
        /// </summary>
        /// <param name="_Args">把计</param>
        public static void Main(string[] _Args) {
            CreateWebHostBuilder(_Args).Build().Run();
        }


        /// <summary>
        /// ミ犁笲
        /// </summary>
        /// <param name="_Args">把计</param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] _Args) {
            return WebHost.CreateDefaultBuilder(_Args)
                          .UseStartup<Startup>()
                          .ConfigureKestrel((Context, ServerOptions) => {
                              ServerOptions.Listen(IPAddress.Any, 5000);
                              /*
                              ServerOptions.Limits.MaxConcurrentConnections = 10 * 10 * 1024;
                              ServerOptions.Limits.MaxConcurrentUpgradedConnections = 10 * 1024;
                              ServerOptions.Limits.MaxRequestBodySize = 100 * 1024 * 1024; // 100MB╰参箇砞30MB
                              ServerOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                              ServerOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(10);
                              */
                          });
        }
    }
}