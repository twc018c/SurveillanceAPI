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
        A = 0,
        [Description("失敗或否")]
        B = 1,
        [Description("參數錯誤")]
        C = -3,
        [Description("client_id不存在")]
        D = 10000,
        [Description("無效的client，client_id或client_secret錯")]
        E = 10001,
        [Description("無效的code或code已失效")]
        F = 10002,
        [Description("token不存在")]
        G = 1003,
        [Description("token無授權，token已失效或被撤銷授權")]
        H = 10004,
        [Description("token權限不在範圍內")]
        I = 10005,
        [Description("未審核的app，只能由特定的測試帳號授權")]
        J = 10006,
        [Description("username或password錯誤")]
        K = 10007,
        [Description("redirect_uri無效，必須和應用信息裡保持一致")]
        L = 10008,
        [Description("請求的response_type類型未被支持")]
        M = 10009,
        [Description("請求的grant_type類型未被支持")]
        N = 10010,
        [Description("refresh_token無效")]
        O = 10011,
        [Description("openid無效")]
        P = 20000,
        [Description("用戶不是鎖的鑰匙擁有者")]
        Q = 20001,
        [Description("不是鎖管理員")]
        R = 20002,
        [Description("鑰匙id和鎖id還有用戶的對應關係錯誤")]
        S = 20003,
        [Description("鑰匙不存在")]
        T = 20004,
        [Description("備份鑰匙的密碼錯誤")]
        U = 20005,
        [Description("接收方不存在")]
        V = 20006,
        [Description("鍵盤密碼版本無效，有效值：1、2、3、4")]
        W = 20007,
        [Description("鎖名稱無效")]
        X = 20008,
        [Description("沒有該接口的權限")]
        Y = 30001,
        [Description("用戶名只能包含數字和字母")]
        Z = 30002,
        [Description("用戶已存在")]
        AA = 30003,
        [Description("要刪除的用戶的userid不合法")]
        AB = 30004,
        [Description("不是定制App的用戶")]
        AC = 30005,
        [Description("超過接口調用次數限制")]
        AD = 30006,
        [Description("請求時間必需為當前時間前後五分鐘以內")]
        AE = 80000,
        [Description("JSON格式不正確")]
        AF = 80002,
        [Description("系統內部錯誤")]
        AG = 90000,
        [Description("鎖附近沒有可用的網關")]
        AH = -2012,
        [Description("沒有權限")]
        AI = -2018
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