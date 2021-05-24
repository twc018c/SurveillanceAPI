using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Surveillance.Schafold {

    /// <summary>
    /// 上下文
    /// </summary>
    public static class HttpContext {

        /// <summary>
        /// 訪問上下文
        /// </summary>
        private static IHttpContextAccessor HttpContextAccessor;

        /// <summary>
        /// 目前連線階段
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current => HttpContextAccessor.HttpContext;

        /// <summary>
        /// 設定
        /// </summary>
        /// <param name="_HttpContextAccessor">依賴性注入</param>
        internal static void Configure(IHttpContextAccessor _HttpContextAccessor) {
            HttpContextAccessor = _HttpContextAccessor;
        }
    }




    /// <summary>
    /// 靜態頁面擴充
    /// </summary>
    public static class StaticHttpContextExtensions {

        /// <summary>
        /// 使用靜態上下文
        /// </summary>
        /// <param name="_App">應用程式</param>
        /// <returns>IApplicationBuilder</returns>
        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder _App) {
            var HttpContextAccessor = _App.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

            HttpContext.Configure(HttpContextAccessor);

            return _App;
        }
    }
}