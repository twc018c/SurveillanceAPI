using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Surveillance {

    /// <summary>
    /// 祘Α
    /// </summary>
    public class Program {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Args">把计</param>
        public static void Main(string[] _Args) {
            CreateHostBuilder(_Args).Build().Run();
        }


        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="_Args">把计</param>
        /// <returns>IWebHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] _Args) =>
            Host.CreateDefaultBuilder(_Args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
