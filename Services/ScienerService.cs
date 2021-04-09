using Surveillance.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;


namespace Surveillance.Services {

    /// <summary>
    /// Sciener
    /// </summary>
    /// <remarks>
    /// Cloud API V3
    /// https://open.sciener.com/doc/api
    /// </remarks>
    public class ScienerService : IScienerService {

        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.114 Safari/537.36";

        private readonly IHttpClientFactory HttpClientFactory;


        /// <summary>
        /// 建構
        /// </summary>
        public ScienerService(IHttpClientFactory _HttpClientFactory) {
            HttpClientFactory = _HttpClientFactory;
        }


        #region "令牌"

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Get() {
            var Request = new HttpRequestMessage(HttpMethod.Post, "https://api.sciener.com/oauth2/token");
            Request.Headers.Add("ContentType", "application/x-www-form-urlencoded");
            Request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = HttpClientFactory.CreateClient();

            var response = await client.SendAsync(Request);
        }

        #endregion




        #region "用戶"

        #endregion




        #region "鎖"

        #endregion




        #region "鑰匙"

        #endregion




        #region "鍵盤密碼"

        #endregion




        #region "IC"

        #endregion




        #region "鎖紀錄"

        #endregion

    }
}