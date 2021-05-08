using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 門鎖清單
    /// </summary>
    public class ScienerLockListModel {

        /// <summary>
        /// 清單
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerLockModel> List { get; set; } = new List<ScienerLockModel>();

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
    /// Sciener 門鎖
    /// </summary>
    public class ScienerLockModel {

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        [JsonPropertyName("date")]
        public long Date { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("specialValue")]
        public int SpecialValue { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockAlias")]
        public string LockAlias { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("noKeyPwd")]
        public string NoKeyPwd { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("electricQuantityUpdateDate")]
        public long ElectricQuantityUpdateDate { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockMac")]
        public string LockMac { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("passageMode")]
        public int PassageMode { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("timezoneRawOffset")]
        public int TimezoneRawOffset { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockId")]
        public int LockId { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("featureValue")]
        public string FeatureValue { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("electricQuantity")]
        public int ElectricQuantity { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("bindDate")]
        public long BindDate { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockData")]
        public string LockData { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("hasGateway")]
        public int HasGateway { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("keyboardPwdVersion")]
        public int KeyboardPwdVersion { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("wirelessKeypadFeatureValue")]
        public string WirelessKeypadFeatureValue { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockVersion")]
        public ScienerLockVersionModel LockVersion { get; set; } = new ScienerLockVersionModel();

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockName")]
        public string LockName { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("sector")]
        public string Sector { get; set; } = "";
    }


    /// <summary>
    /// Sciener 門鎖版本
    /// </summary>
    public class ScienerLockVersionModel {

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("showAdminKbpwdFlag")]
        public bool ShowAdminKbpwdFlag { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("protocolVersion")]
        public int ProtocolVersion { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("protocolType")]
        public int ProtocolType { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("orgId")]
        public int OrgId { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("logoUrl")]
        public string LogoUrl { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("scene")]
        public int Scene { get; set; } = 0;
    }
}