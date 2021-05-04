using Surveillance.ViewModels;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 儀錶板
    /// </summary>
    public interface IDashboardService {
        Task<DashboardHomeViewModel> GetHome();
    }
}