using Microsoft.IdentityModel.Tokens;
using Surveillance.Interfaces;
using Surveillance.Schafold;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System.Text;


namespace Surveillance.Services {

    /// <summary>
    /// JWT
    /// </summary>
    public class JWTService : IJWTService {

        /// <summary>
        /// 建構
        /// </summary>
        public JWTService() {
            // NOTHING
        }


        /// <summary>
        /// 產生權杖
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <param name="_Account">帳號</param>
        /// <returns>string</returns>
        public string GenerateToken(int _Seq, string _Account = "") {
            var TokenHandler = new JwtSecurityTokenHandler();

            var Key = Encoding.UTF8.GetBytes(Global.JWTSecret);
            var SymmetricSecurityKey = new SymmetricSecurityKey(Key);

            var TokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sid, _Seq.ToString()),            // 使用者流水編號
                    new Claim(JwtRegisteredClaimNames.Sub, _Account),                   // 帳號
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   // GUID
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };

            var Token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(Token);
        }


        /// <summary>
        /// 取得權杖
        /// </summary>
        /// <returns>JwtSecurityToken</returns>
        public JwtSecurityToken GetToken() {
            JwtSecurityToken JwtSecurityToken = null;

            bool FlagA = HttpContext.Current.Request.Headers.ContainsKey("Authorization");
            bool FlagB = HttpContext.Current.Request.Headers["Authorization"][0].StartsWith("Bearer ");

            if (FlagA && FlagB) {
                string Token = HttpContext.Current.Request.Headers["Authorization"][0].Substring("Bearer ".Length);

                var Handler = new JwtSecurityTokenHandler();
                var SecurityToken = Handler.ReadToken(Token);

                JwtSecurityToken = SecurityToken as JwtSecurityToken;
            }

            return JwtSecurityToken;
        }


        /// <summary>
        /// 以權杖解析使用者流水編號
        /// </summary>
        /// <returns>int</returns>
        public int ParseUserSeq() {
            // 取得權杖
            var Token = GetToken();

            var Value = Token.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sid).Value;

            int.TryParse(Value, out int UserSeq);

            return UserSeq;
        }


        /// <summary>
        /// 以權杖解析使用者帳號
        /// </summary>
        /// <returns>string</returns>
        public string ParseAccount() {
            // 取得權杖
            var Token = GetToken();

            string Account = Token.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;

            return Account;
        }
    }
}