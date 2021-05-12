using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 爬蟲
    /// </summary>
    public interface ICrawlerService {
        Task ExecuteLockList();
        Task ExecuteLockState();
    }
}