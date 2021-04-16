using System.ComponentModel;


namespace Surveillance.Enums {

    /// <summary>
    /// Sciener 鑰匙
    /// </summary>
    public enum SCIENER_KEY : int {
        [Description("正常使用")]
        OK = 110401,
        [Description("待接收")]
        PENDDING = 110402,
        [Description("已凍結")]
        FROZEN = 110405,
        [Description("已刪除")]
        DELETE = 110408,
        [Description("已重置")]
        RESET = 110410
    }


    /// <summary>
    /// Sciener 代碼
    /// </summary>
    public enum SCIENER_CODE : int {
        [Description("成功或是")]
        SUCCESS = 0,
        [Description("失敗或否")]
        FAIL = 1,
        [Description("參數錯誤")]
        FAIL_PARAMETER = -3,
        [Description("client_id不存在")]
        FAIL_CLIENT_ID = 10000,
        [Description("無效的client，client_id或client_secret錯")]
        FAIL_CLIENT_ID2 = 10001,
        [Description("無效的code或code已失效")]
        FAIL_CODE = 10002,
        [Description("token不存在")]
        FAIL_TOKEN = 1003,
        [Description("token無授權，token已失效或被撤銷授權")]
        FAIL_TOKEN2 = 10004,
        [Description("token權限不在範圍內")]
        FAIL_TOKEN3 = 10005,
        [Description("未審核的app，只能由特定的測試帳號授權")]
        FAIL_APP_VERIFY = 10006,
        [Description("username或password錯誤")]
        FAIL_LOGIN = 10007,
        [Description("redirect_uri無效，必須和應用信息裡保持一致")]
        FAIL_REDIRECT = 10008,
        [Description("請求的response_type類型未被支持")]
        FAIL_RESPONSE_TYPE = 10009,
        [Description("請求的grant_type類型未被支持")]
        FAIL_GRANT_TYPE = 10010,
        [Description("refresh_token無效")]
        FAIL_REFRESH_TOKEN = 10011,
        [Description("openid無效")]
        FAIL_OPENID = 20000,
        [Description("用戶不是鎖的鑰匙擁有者")]
        FAIL_KEY_USER = 20001,
        [Description("不是鎖管理員")]
        FAIL_LOCK_ADMIN = 20002,
        [Description("鑰匙id和鎖id還有用戶的對應關係錯誤")]
        FAIL_KEY_LOCK_RELATION = 20003,
        [Description("鑰匙不存在")]
        FAIL_KEY = 20004,
        [Description("備份鑰匙的密碼錯誤")]
        FAIL_KEY_BACKUP_PASSWORD = 20005,
        [Description("接收方不存在")]
        FAIL_RECEIVE = 20006,
        [Description("鍵盤密碼版本無效，有效值：1、2、3、4")]
        FAIL_KEYBOARD_PASSWORD = 20007,
        [Description("鎖名稱無效")]
        FAIL_LOCK_NAME = 20008,
        [Description("沒有該接口的權限")]
        FAIL_INTERFACE_AUTH = 30001,
        [Description("用戶名只能包含數字和字母")]
        FAIL_USERNAME = 30002,
        [Description("用戶已存在")]
        FAIL_USERNAME2 = 30003,
        [Description("要刪除的用戶的userid不合法")]
        FAIL_DELETE = 30004,
        [Description("不是定制App的用戶")]
        FAIL_APP_CUSTOMER = 30005,
        [Description("超過接口調用次數限制")]
        FAIL_INTERFACE_LIMIT = 30006,
        [Description("請求時間必需為當前時間前後五分鐘以內")]
        FAIL_TIME = 80000,
        [Description("JSON格式不正確")]
        FAIL_JSON_FORMAT = 80002,
        [Description("系統內部錯誤")]
        FAIL_SYSTEM = 90000,
        [Description("鎖附近沒有可用的網關")]
        FAIL_GATEWAY = -2012,
        [Description("沒有權限")]
        FAIL_AUTH = -2018
    }


    /// <summary>
    /// Sciener IC卡狀態
    /// </summary>
    public enum SCIENER_IC_STATUS : int {
        [Description("正常")]
        NORMAL = 1,
        [Description("已失效")]
        INVALID = 2,
        [Description("待生效")]
        PENDDING = 3,
        [Description("添加中")]
        ADDING = 4,
        [Description("添加失敗")]
        ADD_FAIL = 5,
        [Description("修改中")]
        EDITING = 6,
        [Description("修改失敗")]
        EDIT_FAIL = 7,
        [Description("刪除中")]
        DELETING = 8,
        [Description("刪除失敗")]
        DELETE_FAIL = 9
    }
}