namespace Surveillance.Interfaces {

    /// <summary>
    /// JWT
    /// </summary>
    public interface IJWTService {
        string GenerateToken(string _Account);
    }
}