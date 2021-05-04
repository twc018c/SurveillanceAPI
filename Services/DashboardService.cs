using Surveillance.Interfaces;
using Surveillance.Schafold;
using Surveillance.ViewModels;
using System;
using System.Threading.Tasks;


namespace Surveillance.Services {

    /// <summary>
    /// 儀錶板
    /// </summary>
    public class DashboardService : IDashboardService {

        private readonly ICardRepository CardRepository;
        private readonly IDoorRepository DoorRepository;
        private readonly IUserRepository UserRepository;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_CardRepository">門卡倉儲</param>
        /// <param name="_DoorRepository">門鎖倉儲</param>
        /// <param name="_UserRepository">使用者倉儲</param>
        public DashboardService(ICardRepository _CardRepository, IDoorRepository _DoorRepository, IUserRepository _UserRepository) {
            CardRepository = _CardRepository;
            DoorRepository = _DoorRepository;
            UserRepository = _UserRepository;
        }


        /// <summary>
        /// 取得儀錶板首頁
        /// </summary>
        /// <returns>DashboardViewModel</returns>
        public async Task<DashboardHomeViewModel> GetHome() {
            var VM = new DashboardHomeViewModel();

            // 取得門卡數量
            VM.CountCard = await CardRepository.GetCount();

            // 取得門鎖數量
            VM.CountDoor = await DoorRepository.GetCount();

            // 取得使用者數量
            VM.CountUser = await UserRepository.GetCount();

            return VM;
        }
    }
}