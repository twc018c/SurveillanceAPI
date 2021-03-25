using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Surveillance {

    /// <summary>
    /// �D�{��
    /// </summary>
    public class Program {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Args">�Ѽ�</param>
        public static void Main(string[] _Args) {
            CreateHostBuilder(_Args).Build().Run();
        }


        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="_Args">�Ѽ�</param>
        /// <returns>IWebHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] _Args) =>
            Host.CreateDefaultBuilder(_Args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
