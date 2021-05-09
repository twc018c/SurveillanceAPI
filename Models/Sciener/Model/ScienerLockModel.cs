using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener ����ɶ�
    /// </summary>
    public class ScienerLockDateModel {

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        [JsonPropertyName("date")]
        public long Date { get; set; } = 0;
    }


    /// <summary>
    /// Sciener ���ꤺ�e
    /// </summary>
    public class ScienerLockDetailModel {

        /// <summary>
        /// �ثe�ɶ� (�@��)
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


    /// <summary>
    /// Sciener ����M��
    /// </summary>
    public class ScienerLockListModel {

        /// <summary>
        /// �M��
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerLockModel> List { get; set; } = new List<ScienerLockModel>();

        /// <summary>
        /// ���X
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int PageNo { get; set; } = 0;

        /// <summary>
        /// �C���ƶq
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// �`����
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; } = 0;

        /// <summary>
        /// �`��
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;
    }


    /// <summary>
    /// Sciener ����
    /// </summary>
    public class ScienerLockModel {

        /// <summary>
        /// �ثe�ɶ� (�@��)
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


    /// <summary>
    /// Sciener ���ꪩ�� (List�M��)
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
    /// Sciener ���ꪩ�� (Detail�M��)
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
}