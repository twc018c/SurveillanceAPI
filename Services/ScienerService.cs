using Surveillance.Interfaces;
using Surveillance.Models;
using Surveillance.Schafold;
using System;
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
        /// 取得令牌
        /// </summary>
        /// <returns>ScienerTokenModel</returns>
        public async Task<ScienerTokenModel> GetToken() {
            var Model = new ScienerTokenModel();

            var Client = HttpClientFactory.CreateClient();
            Client.Timeout = TimeSpan.FromSeconds(10);
            Client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");
            Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var MFDC = new MultipartFormDataContent();
            MFDC.Add(new StringContent("client_id"), Global.ScienerID);
            MFDC.Add(new StringContent("client_secret"), Global.ScienerSecret);
            MFDC.Add(new StringContent("username"), Global.ScienerUsername);
            MFDC.Add(new StringContent("password"), Global.ScienerPassword);

            var Response = await Client.PostAsync("https://api.sciener.com/oauth2/token", MFDC);

            if (Response.IsSuccessStatusCode) {
                string JSON = await Response.Content.ReadAsStringAsync();
            }

            return Model;
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