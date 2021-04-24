using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 用戶註冊
    /// </summary>
    public class ScienerUserRegisterModel {

        /// <summary>
        /// 用戶名
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; } = "";
    }


    /// <summary>
    /// Sciener 用戶清單
    /// </summary>
    public class ScienerUserListModel {

        /// <summary>
        /// 清單
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerUserModel> List { get; set; } = new List<ScienerUserModel>();

        /// <summary>
        /// 頁碼
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int PageNo { get; set; } = 0;

        /// <summary>
        /// 每頁數量
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// 總頁數
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; } = 0;

        /// <summary>
        /// 總數
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;
    }


    /// <summary>
    /// Sciener 用戶
    /// </summary>
    public class ScienerUserModel {

        /// <summary>
        /// 用戶編號
        /// </summary>
        [JsonPropertyName("userid")]
        public string UserID { get; set; } = "";

        /// <summary>
        /// 註冊時間
        /// </summary>
        [JsonPropertyName("regtime")]
        public long RegTime { get; set; } = 0;
    }
}