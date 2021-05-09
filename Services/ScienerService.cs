using Surveillance.Enums;
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
        /// 產生請求
        /// </summary>
        /// <param name="_URL">網址</param>
        /// <param name="_Dictionary">字典</param>
        /// <returns>string</returns>
        public async Task<string> GenerateRequest(string _URL, Dictionary<string, string> _Dictionary) {
            string JSON = string.Empty;

            var Client = HttpClientFactory.CreateClient();
            Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            Client.Timeout = TimeSpan.FromSeconds(10);

            var Request = new HttpRequestMessage() {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_URL),
                Content = new FormUrlEncodedContent(_Dictionary.ToList())
            };

            try {
                var Response = await Client.SendAsync(Request);

                if (Response.IsSuccessStatusCode) {
                    JSON = await Response.Content.ReadAsStringAsync();
                } else {
                    Console.WriteLine($"Sciener API Request Error #{Response.StatusCode}");
                }
            } catch (Exception Exception) {
                Console.WriteLine($"Sciener API Request Crash. {Exception.Message}");
            }
            
            return JSON;
        }


        /// <summary>
        /// 檢查API代碼
        /// </summary>
        /// <param name="_JSON">JSON</param>
        /// <returns>bool</returns>
        public bool CheckAPICode(string _JSON = "") {
            bool Flag = true;

            try {
                var Temp = JsonSerializer.Deserialize<Dictionary<string, object>>(_JSON);
                var ObjErrCode = Temp.Where(x => x.Key == "errcode").FirstOrDefault().Value;

                // 判斷錯誤代碼
                if (ObjErrCode != null) {
                    int.TryParse(ObjErrCode.ToString(), out int ErrCode);

                    // 成功類型也包含在錯誤代碼的範圍
                    if (ErrCode != (int)SCIENER_CODE.SUCCESS) {
                        // 改變旗標
                        Flag = false;

                        string Str = $"Sciener API Response Error #{ErrCode}";

                        // 判斷錯誤訊息
                        var ObjErrMsg = Temp.Where(x => x.Key == "errmsg").FirstOrDefault().Value;

                        if (ObjErrMsg != null) {
                            Str = $"{Str} {ObjErrMsg.ToString()}";
                        }

                        Console.WriteLine(Str);
                    }
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

            string URL = "https://api.sciener.com/oauth2/token";

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("client_id", Global.ScienerID);
            Dictionary.Add("client_secret", Global.ScienerSecret);
            Dictionary.Add("username", Global.ScienerUsername);
            Dictionary.Add("password", Global.ScienerPassword.ToMD5()); // 密碼以MD5處理

            // 產生請求
            string JSON = await GenerateRequest(URL, Dictionary);

            // 檢查API代碼
            bool Flag = CheckAPICode(JSON);

            if (Flag == true) {
                Model = JsonSerializer.Deserialize<ScienerTokenModel>(JSON);

                // 更新令牌
                Global.ScienerAccessToken = Model.AccessToken;
            }

            return Model;
        }

        #endregion




        #region "用戶"

        /// <summary>
        /// 用戶註冊
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>ScienerUserRegisterModel</returns>
        public async Task<ScienerUserRegisterModel> RegisterUser(SicenerUserRegisterEntry _Entry) {
            var Model = new ScienerUserRegisterModel();

            if (_Entry.Date == 0) {
                _Entry.Date = Tool.GetDateLong();
            }

            string URL = "https://api.sciener.com/v3/user/register";

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("clientId", Global.ScienerID);
            Dictionary.Add("clientSecret", Global.ScienerSecret);
            Dictionary.Add("username", $"{_Entry.UserName}");
            Dictionary.Add("password", $"{_Entry.Password}");
            Dictionary.Add("date", $"{_Entry.Date}");

            // 產生請求
            string JSON = await GenerateRequest(URL, Dictionary);

            // 檢查API代碼
            bool Flag = CheckAPICode(JSON);

            if (Flag == true) {
                Model = JsonSerializer.Deserialize<ScienerUserRegisterModel>(JSON);
            }

            return Model;
        }


        /// <summary>
        /// 取得用戶清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>ScienerUserListModel</returns>
        public async Task<ScienerUserListModel> GetUserList(SicenerUserEntry _Entry) {
            var Model = new ScienerUserListModel();

            if (_Entry.Date == 0) {
                _Entry.Date = Tool.GetDateLong();
            }

            string URL = "https://api.sciener.com/v3/user/list";

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("clientId", Global.ScienerID);
            Dictionary.Add("clientSecret", Global.ScienerSecret);
            Dictionary.Add("startDate", $"{_Entry.StartDate}");
            Dictionary.Add("endDate", $"{_Entry.EndDate}");
            Dictionary.Add("pageNo", $"{_Entry.PageNo}");
            Dictionary.Add("pageSize", $"{_Entry.PageSize}");
            Dictionary.Add("date", $"{_Entry.Date}");

            // 產生請求
            string JSON = await GenerateRequest(URL, Dictionary);

            // 檢查API代碼
            bool Flag = CheckAPICode(JSON);

            if (Flag == true) {
                Model = JsonSerializer.Deserialize<ScienerUserListModel>(JSON);
            }

            return Model;
        }

        #endregion




        #region "鎖"

        /// <summary>
        /// 取得鎖時間
        /// </summary>
        /// <param name="_LockID">鎖編號</param>
        /// <returns>ScienerLockDateModel</returns>
        public async Task<ScienerLockDateModel> GetLockDate(int _LockID = 0) {
            var Model = new ScienerLockDateModel();

            string URL = "https://api.sciener.com/v3/lock/queryDate";

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("clientId", Global.ScienerID);
            Dictionary.Add("accessToken", Global.ScienerAccessToken);
            Dictionary.Add("lockId", $"{_LockID}");
            Dictionary.Add("date", $"{Tool.GetDateLong()}");

            // 產生請求
            string JSON = await GenerateRequest(URL, Dictionary);

            // 檢查API代碼
            bool Flag = CheckAPICode(JSON);

            if (Flag == true) {
                Model = JsonSerializer.Deserialize<ScienerLockDateModel>(JSON);
            }

            return Model;
        }


        /// <summary>
        /// 取得鎖內容
        /// </summary>
        /// <param name="_LockID">鎖編號</param>
        /// <returns>ScienerLockDetailModel</returns>
        public async Task<ScienerLockDetailModel> GetLockDetail(int _LockID = 0) {
            var Model = new ScienerLockDetailModel();

            string URL = "https://api.sciener.com/v3/lock/detail";

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("clientId", Global.ScienerID);
            Dictionary.Add("accessToken", Global.ScienerAccessToken);
            Dictionary.Add("lockId", $"{_LockID}");
            Dictionary.Add("date", $"{Tool.GetDateLong()}");

            // 產生請求
            string JSON = await GenerateRequest(URL, Dictionary);

            // 檢查API代碼
            bool Flag = CheckAPICode(JSON);

            if (Flag == true) {
                Model = JsonSerializer.Deserialize<ScienerLockDetailModel>(JSON);
            }

            return Model;
        }


        /// <summary>
        /// 取得鎖清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>ScienerLockListModel</returns>
        public async Task<ScienerLockListModel> GetLockList(SicenerLockListEntry _Entry) {
            var Model = new ScienerLockListModel();

            if (_Entry.Date == 0) {
                _Entry.Date = Tool.GetDateLong();
            }

            string URL = "https://api.sciener.com/v3/lock/list";

            var Dictionary = new Dictionary<string, string>();
            Dictionary.Add("clientId", Global.ScienerID);
            Dictionary.Add("accessToken", Global.ScienerAccessToken);
            Dictionary.Add("lockAlias", $"{_Entry.LockAlias}");
            Dictionary.Add("type", $"{_Entry.Type}");
            Dictionary.Add("pageNo", $"{_Entry.PageNo}");
            Dictionary.Add("pageSize", $"{_Entry.PageSize}");
            Dictionary.Add("date", $"{_Entry.Date}");

            // 產生請求
            string JSON = await GenerateRequest(URL, Dictionary);

            // 檢查API代碼
            bool Flag = CheckAPICode(JSON);

            if (Flag == true) {
                Model = JsonSerializer.Deserialize<ScienerLockListModel>(JSON);
            }

            return Model;
        }

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