using System.IdentityModel.Tokens.Jwt;


namespace Surveillance.Interfaces {

    /// <summary>
    /// JWT
    /// </summary>
    public interface IJWTService {
        string GenerateToken(int _Seq, string _Account);
        JwtSecurityToken GetToken();
        int ParseUserSeq();
        string ParseAccount();
    }
}