using Microsoft.Extensions.DependencyInjection;
using Surveillance.Enums;
using Surveillance.Interfaces;
using Surveillance.Library;
using Surveillance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Services {

    /// <summary>
    /// 爬蟲
    /// </summary>
    public class CrawlerService : ICrawlerService {

        private readonly IServiceProvider ServiceProvider;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_ServiceProvider">依賴性注入</param>
        public CrawlerService(IServiceProvider _ServiceProvider) {
            ServiceProvider = _ServiceProvider;
        }


        /// <summary>
        /// 執行門鎖清單爬蟲
        /// </summary>
        /// <returns>Tuple</returns>
        public async Task<(int CountAdd, int CountDelete, int CountUpdate)> ExecuteLockList() {
            const int PageNow = 1;
            const int PageShow = 10000;

            int CountAdd = 0;
            int CountDelete = 0;
            int CountUpdate = 0;

            // 取得倉儲及服務
            var DoorRepository = ServiceProvider.GetService<IDoorRepository>();
            var EventLogRepository = ServiceProvider.GetService<IEventLogRepository>();
            var ScienerService = ServiceProvider.GetService<IScienerService>();

            // 取得門鎖清單
            var WrapperLocal = await DoorRepository.GetList(new DoorListEntry() {
                PageNow = PageNow,
                PageShow = PageShow
            });

            // 取得Sciener門鎖清單
            var WrapperRemote = await ScienerService.GetLockList(new ScienerLockListEntry() {
                LockAlias = "",
                Type = SCIENER_DEVICE_TYPE.LOCK,
                PageNo = PageNow,
                PageSize = PageShow
            });

            var ListRemote = WrapperRemote.List
                                          .OrderBy(x => x.LockID)
                                          .ToList();

            var ListLocal = WrapperLocal.List
                                        .OrderBy(x => x.ID)
                                        .ToList();

            // 編號清單
            var ListRemoteID = WrapperRemote.List.Select(x => x.LockID).ToList();
            var ListLocalID = WrapperLocal.List.Select(x => x.ID).OrderBy(x => x).ToList();

            // 判斷遠端數量
            if (WrapperRemote.Total <= 0) {
                return (CountAdd, CountDelete, CountUpdate);
            }

            // 判斷本地端數量
            if (WrapperLocal.Count <= 0) {
                var Target = new List<DoorModel>();

                ListRemote.ForEach(r => {
                    // 模型轉換
                    Target.Add(ConvertModel(r));
                });

                // 新增門鎖
                await DoorRepository.Set(Target);

                return (CountAdd, CountDelete, CountUpdate);
            }

            var ListAdd = new List<DoorModel>();
            var ListDelete = new List<int>();
            var ListUpdate = new List<DoorUpdateEntry>();

            // =============================================================
            // 互相比對遠端與本地端的編號
            // =============================================================

            // 比較清單差異
            var Tuple = Tool.Compare(ListRemoteID, ListLocalID);

            // 1. 多餘 (新增本地端)
            ListRemote.Where(r => Tuple.XnotY.Contains(r.LockID))
                      .ToList()
                      .ForEach(r => {
                          // 模型轉換
                          ListAdd.Add(ConvertModel(r));
                      });

            // 2. 缺少 (刪除本地端)
            ListDelete = ListLocal.Where(l => Tuple.YnotX.Contains(l.ID))
                                  .Select(l => l.ID)
                                  .ToList();

            // 3. 重複 (更新本地端，最理想狀態)
            ListRemote.Where(r => Tuple.Intersect.Contains(r.LockID))
                      .ToList()
                      .ForEach(r => {
                          // 模型轉換
                          ListUpdate.Add(ConvertEntry(r));
                      });

            // 新增門鎖
            await DoorRepository.Set(ListAdd);

            // 刪除門鎖
            await DoorRepository.Delete(ListDelete);

            // 修改門鎖
            await DoorRepository.Update(ListUpdate);

            // ISSUE - 暫不刪除
            // 刪除事件紀錄 (依門鎖)
            //await EventLogRepository.DeleteByDoorList(ListDelete);

            CountAdd = ListAdd.Count();
            CountDelete = ListDelete.Count();
            CountUpdate = ListUpdate.Count();

            return (CountAdd, CountDelete, CountUpdate);
        }


        /// <summary>
        /// 執行門鎖狀態爬蟲
        /// </summary>
        /// <returns>Task</returns>
        public async Task ExecuteLockState() {

        }


        /// <summary>
        /// 模型轉換
        /// </summary>
        /// <param name="_SLM">模型</param>
        /// <returns>DoorModel</returns>
        private DoorModel ConvertModel(ScienerLockModel _SLM) {
            return new DoorModel() {
                ID = _SLM.LockID,
                Name = _SLM.LockName,
                Note = _SLM.LockAlias,
                Status = SCIENER_LOCK_STATE.UNKNOW,
                Battery = _SLM.ElectricQuantity,
                BatteryTime = Tool.UnixTimeStampToDateTime(_SLM.ElectricQuantityUpdateDate / 1000),
                IsRemote = 1
            };
        }


        /// <summary>
        /// 模型轉換
        /// </summary>
        /// <param name="_SLM">模型</param>
        /// <returns>DoorUpdateEntry</returns>
        private DoorUpdateEntry ConvertEntry(ScienerLockModel _SLM) {
            return new DoorUpdateEntry() {
                ID = _SLM.LockID,
                Name = _SLM.LockName,
                Note = _SLM.LockAlias,
                Battery = _SLM.ElectricQuantity,
                BatteryTime = Tool.UnixTimeStampToDateTime(_SLM.ElectricQuantityUpdateDate / 1000)
            };
        }
    }
}