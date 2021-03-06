using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace Surveillance.Library {

    /// <summary>
    /// 工具類別
    /// </summary>
    public static class Tool {

        /// <summary>
        /// 取得JSON設定
        /// </summary>
        /// <returns>JsonSerializerOptions</returns>
        public static JsonSerializerOptions GetJsonOption() {
            var EncoderSettings = new TextEncoderSettings();
            EncoderSettings.AllowCharacters('\u0436', '\u0430');
            EncoderSettings.AllowRange(UnicodeRanges.All);

            var Encoder = JavaScriptEncoder.Create(EncoderSettings);

            var Options = new JsonSerializerOptions {
                AllowTrailingCommas = false,
                Encoder = Encoder,
                IgnoreNullValues = false,
                IgnoreReadOnlyProperties = false,
                MaxDepth = 0,
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = null,
                WriteIndented = true
            };

            return Options;
        }


        /// <summary>
        /// 物件轉JSON
        /// </summary>
        /// <param name="_Object">物件</param>
        /// <returns>string</returns>
        public static string ConvertToJson<TValue>(this TValue _Object) {
            // 取得JSON設定
            var Options = GetJsonOption();

            var Wrapper = new Dictionary<string, object>();

            if (_Object == null) {
                Wrapper.Add("result", string.Empty);
            } else {
                Wrapper.Add("result", _Object);
            }

            string JSON = JsonSerializer.Serialize(Wrapper, Options);

            //JSON = JSON.Replace("\r", string.Empty);
            //JSON = JSON.Replace("\n", string.Empty);
            //JSON = JSON.Replace("\r\n", Environment.NewLine);
            //JSON = JSON.Replace("\"", "\"");

            return JSON;
        }


        /// <summary>
        /// 比較清單差異
        /// </summary>
        /// <param name="_ListX">清單X</param>
        /// <param name="_ListY">清單Y</param>
        /// <returns>Tuple</returns>
        public static (List<int> XnotY, List<int> YnotX, List<int> Intersect) Compare(List<int> _ListX, List<int> _ListY) {
            // 左交集 (X為主)
            var XnotY = _ListX.Except(_ListY).ToList();

            // 右交集 (Y為主)
            var YnotX = _ListY.Except(_ListX).ToList();

            // 重疊
            var Intersect = _ListX.Intersect(_ListY).ToList();

            return (XnotY, YnotX, Intersect);
        }


        /// <summary>
        /// 取得圖片尺寸
        /// </summary>
        /// <param name="_Buffer">緩衝</param>
        /// <returns>Tuple</returns>
        public static (int Width, int Height) GetImageSize(byte[] _Buffer) {
            if (_Buffer == null || _Buffer.Length == 0) {
                return (0, 0);
            }

            var Target = Image.FromStream(new MemoryStream(_Buffer));

            return (Target.Width, Target.Height);
        }


        /// <summary>
        /// 產生系統編號
        /// </summary>
        /// <returns>string</returns>
        public static string GenerateUniqueid() {
            double UnixTimestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return UnixTimestamp.ToString("#0.000"); // 取小數點後3位
        }


        /// <summary>
        /// 取得日期長整數
        /// </summary>
        /// <remarks>
        /// 毫秒精度
        /// </remarks>
        /// <returns>string</returns>
        public static long GenerateDateLong() {
            double UnixTimestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
            return (long)UnixTimestamp;
        }


        /// <summary>
        /// Unix時間轉換至當地時間
        /// </summary>
        /// <remarks>
        /// 秒精度
        /// </remarks>
        /// <param name="_UnixTimestamp">時間戳記</param>
        /// <returns>DateTime</returns>
        public static DateTime UnixTimeStampToDateTime(long _UnixTimestamp = 0) {
            DateTime DT = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DT = DT.AddSeconds((double)_UnixTimestamp).ToLocalTime();

            return DT;
        }


        /// <summary>
        /// 列舉描述
        /// </summary>
        /// <param name="_Enum">列舉</param>
        /// <returns>string</returns>
        public static string ToEnumDescription(this Enum _Enum) {
            FieldInfo FI = _Enum.GetType().GetField(_Enum.ToString());
            DescriptionAttribute[] Attr = (DescriptionAttribute[])FI.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return Attr.Length > 0 ? Attr[0].Description : _Enum.ToString();
        }
        

        /// <summary>
        /// MD5編碼
        /// </summary>
        /// <param name="_PlainText">明文</param>
        /// <returns>string</returns>
        public static string ToMD5(this string _PlainText) {
            using (var CryptoMD5 = MD5.Create()) {
                byte[] Buffer = Encoding.UTF8.GetBytes(_PlainText);

                byte[] Hash = CryptoMD5.ComputeHash(Buffer);

                var Cipher = BitConverter.ToString(Hash)
                                         .Replace("-", String.Empty)
                                         .ToUpper();

                return Cipher;
            }
        }


        /// <summary>
        /// 過濾參數
        /// </summary>
        /// <param name="_Parameter">參數</param>
        /// <returns>string</returns>
        public static string FilterParameter(string _Parameter = "") {
            if (string.IsNullOrEmpty(_Parameter)) {
                return string.Empty;
            }

            string Str = _Parameter.Trim();
            string[] SymbolArr = new string[] { "--", "\\", "'", "\"", "`", "\'" };
            foreach (var Symbol in SymbolArr) {
                Str = Str.Replace(Symbol, "");
            }

            return Str;
        }


        /// <summary>
        /// 截斷文字
        /// </summary>
        /// <param name="_Text">文字</param>
        /// <param name="_MaxLength">最大長度</param>
        /// <returns>string</returns>
        public static string SubstringMax(this string _Text, int _MaxLength = 0) {
            if (string.IsNullOrEmpty(_Text)) {
                return string.Empty;
            }

            if (_MaxLength == 0) {
                return _Text;
            }

            string Str = _Text.Trim();

            if (Str.Length > _MaxLength) {
                Str = Str.Substring(0, _MaxLength);
            }

            return Str;
        }
    }
}