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
        /// <returns>Task</returns>
        public async Task ExecuteLockList() {
            const int PageNow = 1;
            const int PageShow = 10000;

            // 取得倉儲及服務
            var DoorRepository = ServiceProvider.GetService<IDoorRepository>();
            var ScienerService = ServiceProvider.GetService<IScienerService>();

            // 取得門鎖清單
            var WrapperLocal = await DoorRepository.GetList(new DoorEntry() {
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
                return;
            }

            // 判斷本地端數量
            if (WrapperLocal.Count <= 0) {
                var Target = new List<DoorModel>();

                ListRemote.ForEach(r => {
                    Target.Add(ConvertRemoteToLocal(r));
                });

                // 新增門鎖
                await DoorRepository.Set(Target);

                return;
            }

            // 比對編號
            // 1. 缺少的
            // 2. 多餘的
            // 3. 重複

            // 比較清單差異
            var Tuple = Tool.Compare(ListRemoteID, ListLocalID);

            var ListAdd = new List<DoorModel>();

            ListRemote.Where(r => Tuple.XnotY.Contains(r.LockID))
                      .ToList()
                      .ForEach(r => {
                            ListAdd.Add(ConvertRemoteToLocal(r));
                      });

            var ListDelete = ListLocal.Where(l => Tuple.YnotX.Contains(l.ID))
                                      .Select(l => l.ID)
                                      .ToList();

            // 新增門鎖
            await DoorRepository.Set(ListAdd);

            // 刪除門鎖
            await DoorRepository.Delete(ListDelete);
        }


        /// <summary>
        /// 執行門鎖狀態爬蟲
        /// </summary>
        /// <returns>Task</returns>
        public async Task ExecuteLockState() {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_SLM"></param>
        /// <returns>DoorModel</returns>
        private DoorModel ConvertRemoteToLocal(ScienerLockModel _SLM) {
            return new DoorModel() {
                ID = _SLM.LockID,
                Name = _SLM.LockName,
                Note = _SLM.LockAlias,
                Battery = _SLM.ElectricQuantity
            };
        }
    }
}