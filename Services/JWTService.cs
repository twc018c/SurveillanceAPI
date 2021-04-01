using Microsoft.IdentityModel.Tokens;
using Surveillance.Interfaces;
using Surveillance.Schafold;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        /// <param name="_Account">帳號</param>
        /// <returns>string</returns>
        public string GenerateToken(string _Account = "") {
            var TokenHandler = new JwtSecurityTokenHandler();

            var Key = Encoding.UTF8.GetBytes(Global.Secret);
            var SymmetricSecurityKey = new SymmetricSecurityKey(Key);

            var TokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _Account),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // JWT ID
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };

            var Token = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(Token);
        }
    }
}