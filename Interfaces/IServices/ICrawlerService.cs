using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 爬蟲
    /// </summary>
    public interface ICrawlerService {
        Task<(int CountAdd, int CountDelete, int CountUpdate)> ExecuteLockList();
        Task ExecuteLockState();
    }
}