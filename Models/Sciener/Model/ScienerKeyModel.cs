using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    #region "內容"

    /// <summary>
    /// Sciener 鑰匙內容
    /// </summary>
    public class ScienerKeyDetailModel {

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
        [JsonPropertyName("keyStatus")]
        public string KeyStatus { get; set; } = "";

        /// <summary>
        /// 結束時間 (毫秒)
        /// </summary>
        [JsonPropertyName("endDate")]
        public long EndDate { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("noKeyPwd")]
        public string NoKeyPwd { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("keyId")]
        public long KeyID { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockMac")]
        public string LockMac { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("deletePwd")]
        public string DeletePwd { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("featureValue")]
        public string FeatureValue { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockId")]
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("electricQuantity")]
        public int ElectricQuantity { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockData")]
        public string LockData { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("keyboardPwdVersion")]
        public int KeyboardPwdVersion { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("remoteEnable")]
        public int RemoteEnable { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("wirelessKeypadFeatureValue")]
        public string WirelessKeypadFeatureValue { get; set; } = "";

        /// <summary>
        /// 門鎖版本
        /// </summary>
        [JsonPropertyName("lockVersion")]
        public ScienerLockVersionByListModel LockVersion { get; set; } = new ScienerLockVersionByListModel();

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("userType")]
        public string UserType { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockName")]
        public string LockName { get; set; } = "";

        /// <summary>
        /// 開始時間 (毫秒)
        /// </summary>
        [JsonPropertyName("startDate")]
        public long StartDate { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("remarks")]
        public string Remarks { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("keyRight")]
        public int KeyRight { get; set; } = 0;
    }

    #endregion




    #region "清單"

    /// <summary>
    /// Sciener 鑰匙清單
    /// </summary>
    public class ScienerKeyListModel {

        /// <summary>
        /// 總數
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;

        /// <summary>
        /// 總頁數
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; } = 0;

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
        /// 清單
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerKeyDetailModel> List { get; set; } = new List<ScienerKeyDetailModel>();
    }

    #endregion

}