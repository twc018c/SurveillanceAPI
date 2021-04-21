﻿using Surveillance.Enums;
using Surveillance.Interfaces;
using Surveillance.Library;
using Surveillance.Models;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
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


        /// <summary>
        /// 檢查API代碼
        /// </summary>
        /// <param name="_JSON">JSON</param>
        /// <returns>bool</returns>
        public static bool CheckAPICode(string _JSON = "") {
            bool Flag = true;

            try {
                var Temp = JsonSerializer.Deserialize<Dictionary<string, object>>(_JSON);
                var ObjErrCode = Temp.Where(x => x.Key == "errcode").FirstOrDefault().Value;

                if (ObjErrCode != null) {
                    int.TryParse(ObjErrCode.ToString(), out int ErrCode);

                    if (ErrCode != (int)SCIENER_CODE.SUCCESS) {
                        Flag = false;
                    }

                    Console.WriteLine($"Sciener API Response Error #{ErrCode}");
                }
            } catch (Exception Exception) {
                Console.WriteLine($"Sciener API Response Crash. {Exception.Message}");
            }

            return Flag;
        }




        #region "令牌"

        /// <summary>
        /// 取得令牌
        /// </summary>
        /// <returns>ScienerTokenModel</returns>
        public async Task<ScienerTokenModel> GetToken() {
            var Model = new ScienerTokenModel();

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("client_id", Global.ScienerID);
            Dictionary.Add("client_secret", Global.ScienerSecret);
            Dictionary.Add("username", Global.ScienerUsername);
            Dictionary.Add("password", Global.ScienerPassword.ToMD5()); // 密碼以MD5處理

            var Client = HttpClientFactory.CreateClient();
            Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            Client.Timeout = TimeSpan.FromSeconds(10);

            var Request = new HttpRequestMessage() {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.sciener.com/oauth2/token"),
                Content = new FormUrlEncodedContent(Dictionary.ToList())
            };

            var Response = await Client.SendAsync(Request);

            if (Response.IsSuccessStatusCode) {
                string JSON = await Response.Content.ReadAsStringAsync();

                // 檢查API代碼
                bool Flag = CheckAPICode(JSON);

                if (Flag == true) {
                    Model = JsonSerializer.Deserialize<ScienerTokenModel>(JSON);
                }
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