using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 網關清單
    /// </summary>
    public class ScienerGatewayListModel {

        /// <summary>
        /// 清單
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerGatewayModel> List { get; set; } = new List<ScienerGatewayModel>();

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
    /// Sciener 網關
    /// </summary>
    public class ScienerGatewayModel {

        /// <summary>
        /// 網關編號
        /// </summary>
        [JsonPropertyName("gatewayId")]
        public int GatewayID { get; set; } = 0;

        /// <summary>
        /// 網關MAC地址
        /// </summary>
        [JsonPropertyName("gatewayMac")]
        public string GatewayMAC { get; set; } = "";

        /// <summary>
        /// 網關版本號
        /// </summary>
        [JsonPropertyName("gatewayVersion")]
        public int GatewayVersion { get; set; } = 0;

        /// <summary>
        /// 連接網關的網路名稱
        /// </summary>
        [JsonPropertyName("networkName")]
        public string NetworkName { get; set; } = "";

        /// <summary>
        /// 網關管理的鎖數量
        /// </summary>
        [JsonPropertyName("lockNum")]
        public int LockNum { get; set; } = 0;

        /// <summary>
        /// 是否在線
        /// </summary>
        [JsonPropertyName("isOnline")]
        public int IsOnline { get; set; } = 0;
    }
}