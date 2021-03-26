using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Surveillance.Library {
    
    /// <summary>
    /// AES
    /// </summary>
    public class AES {

        // 加密IV，固定16字元
        private string IV = "0000000000000000";

        // 加密KEY，AES-128=16字元 、AES-192=24字元 、AES-256=32字元
        private string Key = "00000000000000000000000000000000";

        // 加密長度，128或192或256
        private int Size = 256;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_IV">特徵值</param>
        /// <param name="_Key">金鑰</param>
        public AES(string _IV = "", string _Key = "") {
            if (!string.IsNullOrEmpty(_IV)) {
                this.IV = _IV;
            }

            if (!string.IsNullOrEmpty(_Key)) {
                this.Key = _Key;
            }

            switch (_Key.Length) {
                case 16:
                    this.Size = 128;
                    break;
                case 24:
                    this.Size = 192;
                    break;
                case 32:
                    this.Size = 256;
                    break;
            }
        }


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="_PlainText">明文字串</param>
        /// <returns>string</returns>
        public string Encrypt(string _PlainText = "") {
            RijndaelManaged AES = new RijndaelManaged() {
                KeySize = this.Size,
                Key = Encoding.UTF8.GetBytes(this.Key),
                IV = Encoding.UTF8.GetBytes(this.IV),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            byte[] DataByteArr = Encoding.UTF8.GetBytes(_PlainText);
            string EncryptText = string.Empty;

            ICryptoTransform CT = AES.CreateEncryptor();
            MemoryStream MS = new MemoryStream();
            CryptoStream CS = new CryptoStream(MS, CT, CryptoStreamMode.Write);
            CS.Write(DataByteArr, 0, DataByteArr.Length);
            CS.FlushFinalBlock();

            StringBuilder SB = new StringBuilder();
            foreach (var DataByte in MS.ToArray()) {
                SB.AppendFormat("{0:X2}", DataByte);
            }
            EncryptText = SB.ToString();

            return EncryptText;
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="_CipherText">密文字串</param>
        /// <returns>string</returns>
        public string Decrypt(string _CipherText = "") {
            try {
                RijndaelManaged AES = new RijndaelManaged() {
                    KeySize = this.Size,
                    Key = Encoding.UTF8.GetBytes(this.Key),
                    IV = Encoding.UTF8.GetBytes(this.IV),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };

                string DecryptText = string.Empty;

                ICryptoTransform CT = AES.CreateDecryptor();
                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, CT, CryptoStreamMode.Write);

                int Length = _CipherText.Length / 2;
                byte[] Buffer = new byte[Length];

                for (int i = 0; i < Length; i++) {
                    int Value = Convert.ToInt32(_CipherText.Substring(i * 2, 2), 16);
                    Buffer[i] = Convert.ToByte(Value);
                }

                CS.Write(Buffer, 0, Buffer.Length);
                CS.FlushFinalBlock();
                DecryptText = Encoding.GetEncoding("utf-8").GetString(MS.ToArray());
                MS.Close();

                return DecryptText;
            } catch (Exception _E) {
                return _E.Message;
            }
        }
    }
}