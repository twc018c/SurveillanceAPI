using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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
        /// 產生系統編號
        /// </summary>
        /// <returns>string</returns>
        public static string GenerateUniqueid() {
            double UnixTimestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return UnixTimestamp.ToString("#0.000"); // 取小數點後3位
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