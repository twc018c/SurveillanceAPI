using Surveillance.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    #region "時間"

    /// <summary>
    /// Sciener 門鎖時間
    /// </summary>
    public class ScienerLockDateModel {

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        [JsonPropertyName("date")]
        public long Date { get; set; } = 0;
    }

    #endregion




    #region "電量"

    /// <summary>
    /// Sciener 門鎖電量
    /// </summary>
    public class ScienerLockElectricQuantityModel {

        /// <summary>
        /// 電量
        /// </summary>
        [JsonPropertyName("electricQuantity")]
        public int ElectricQuantity { get; set; } = 0;
    }

    #endregion




    #region "狀態"

    /// <summary>
    /// Sciener 門鎖狀態
    /// </summary>
    public class ScienerLockStateModel {

        /// <summary>
        /// 狀態
        /// </summary>
        [JsonPropertyName("state")]
        public SCIENER_LOCK_STATE State { get; set; } = SCIENER_LOCK_STATE.UNKNOW;

        /// <summary>
        /// 感測器狀態
        /// </summary>
        [JsonPropertyName("sensorState")]
        public int SensorState { get; set; } = 0;
    }


    /// <summary>
    /// Sciener 開鎖
    /// </summary>
    public class ScienerLockOpenModel {

        /// <summary>
        /// 代碼
        /// </summary>
        [JsonPropertyName("errcode")]
        public SCIENER_CODE Errcode { get; set; } = SCIENER_CODE.SUCCESS;

        /// <summary>
        /// 訊息
        /// </summary>
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
    }


    /// <summary>
    /// Sciener 閉鎖
    /// </summary>
    public class ScienerLockCloseModel {

        /// <summary>
        /// 代碼
        /// </summary>
        [JsonPropertyName("errcode")]
        public SCIENER_CODE Errcode { get; set; } = SCIENER_CODE.SUCCESS;

        /// <summary>
        /// 訊息
        /// </summary>
        [JsonPropertyName("errmsg")]
        public string Errmsg { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
    }

    #endregion




    #region "內容"

    /// <summary>
    /// Sciener 門鎖內容
    /// </summary>
    public class ScienerLockDetailModel {

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        [JsonPropertyName("date")]
        public long Date { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockAlias")]
        public string LockAlias { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockSound")]
        public int LockSound { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("modelNum")]
        public string ModelNum { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockMac")]
        public string LockMac { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("privacyLock")]
        public int PrivacyLock { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("deletePwd")]
        public string deletePwd { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("adminPwd")]
        public string adminPwd { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("autoLockTime")]
        public int AutoLockTime { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockKey")]
        public string LockKey { get; set; } = "";

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

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("resetButton")]
        public int ResetButton { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("firmwareRevision")]
        public string FirmwareRevision { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("tamperAlert")]
        public int TamperAlert { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("specialValue")]
        public int SpecialValue { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("noKeyPwd")]
        public string NoKeyPwd { get; set; } = "";

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
        [JsonPropertyName("electricQuantity")]
        public int ElectricQuantity { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockFlagPos")]
        public int LockFlagPos { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockUpdateDate")]
        public long LockUpdateDate { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("keyboardPwdVersion")]
        public int KeyboardPwdVersion { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("aesKeyStr")]
        public string AESKeyStr { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("hardwareRevision")]
        public string HrdwareRevision { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lockVersion")]
        public ScienerLockVersionByDetailModel LockVersion { get; set; } = new ScienerLockVersionByDetailModel();
    }

    #endregion




    #region "清單"

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
        public ScienerLockVersionByListModel LockVersion { get; set; } = new ScienerLockVersionByListModel();

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

    #endregion




    #region "版本"

    /// <summary>
    /// Sciener 門鎖版本 (List專用)
    /// </summary>
    public class ScienerLockVersionByListModel {

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


    /// <summary>
    /// Sciener 門鎖版本 (Detail專用)
    /// </summary>
    public class ScienerLockVersionByDetailModel {

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
        [JsonPropertyName("scene")]
        public int Scene { get; set; } = 0;
    }

    #endregion




    #region "紀錄"

    /// <summary>
    /// Sciener 門鎖紀錄
    /// </summary>
    public class ScienerLockRecordModel {

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int PageNo { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerLockRecordListModel> List { get; set; } = new List<ScienerLockRecordListModel>();
    }


    /// <summary>
    /// Sciener 門鎖紀錄
    /// </summary>
    public class ScienerLockRecordListModel {

        /// <summary>
        /// 鎖編號
        /// </summary>
        [JsonPropertyName("lockId")]
        public int LockId { get; set; } = 0;

        /// <summary>
        /// 記錄上傳到服務器的時間
        /// </summary>
        [JsonPropertyName("serverDate")]
        public long ServerDate { get; set; } = 0;

        /// <summary>
        /// ?
        /// </summary>
        [JsonPropertyName("hotelUsername")]
        public string HotelUsername { get; set; } = "";

        /// <summary>
        /// 記錄類型
        /// </summary>
        [JsonPropertyName("recordType")]
        public SCIENER_LOCK_RECORD_TYPE RecordType { get; set; } = SCIENER_LOCK_RECORD_TYPE.A;

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonPropertyName("success")]
        public int Success { get; set; } = 0;

        /// <summary>
        /// 鍵盤密碼的密碼，或者IC卡號或者手環地​​址
        /// </summary>
        [JsonPropertyName("keyboardPwd")]
        public string KeyboardPwd { get; set; } = "";

        /// <summary>
        /// 操作人用戶名
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; } = "";

        /// <summary>
        /// 操作時鎖上的時間
        /// </summary>
        [JsonPropertyName("lockDate")]
        public long LockDate { get; set; } = 0;
    }

    #endregion

}