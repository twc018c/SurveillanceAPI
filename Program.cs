using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Surveillance {

    /// <summary>
    /// 主程式
    /// </summary>
    public class Program {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Args">參數</param>
        public static void Main(string[] _Args) {
            CreateHostBuilder(_Args).Build().Run();
        }


        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="_Args">參數</param>
        /// <returns>IWebHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] _Args) =>
            Host.CreateDefaultBuilder(_Args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
