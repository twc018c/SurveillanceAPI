using Hangfire;
using Hangfire.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Surveillance.Interfaces;
using System;
using System.Threading.Tasks;


namespace Surveillance.Schafold {

    /// <summary>
    /// Hangfire 工作
    /// </summary>
    /// <remarks>
    /// 此類別所有方法必須為public，才能在背景觸發
    /// </remarks>
    public class HangfireJob {

        /// <summary>
        /// 載入排程工作
        /// </summary>
        /// <remarks>
        /// 排程表示式，參考 https://crontab.guru/
        /// minute   hour   day   month   day
        ///               (month)       (week)
        ///   * any value
        ///   , value list separator
        ///   - range of values
        ///   / step values
        /// </remarks>
        public static void LoadCron() {
            // 資料同步
            // 每天凌晨00點30分觸發
            RecurringJob.AddOrUpdate("Day-01", () => DataAlign(null), "30 00 */01 * *", TimeZoneInfo.Local);

            // 門鎖狀態
            // 每15分鐘檢查1次
            RecurringJob.AddOrUpdate("Minute-01", () => DoorStatus(null), "*/15 * * * *", TimeZoneInfo.Local);
        }




        #region "每天固定工作"

        /// <summary>
        /// 資料同步
        /// </summary>
        /// <param name="_PC">PerformContext</param>
        public static async Task DataAlign([FromServices] PerformContext _PC) {
            // 取得服務
            var CrawlerService = ProviderService.Collection.GetService<ICrawlerService>();

            // 執行門鎖清單爬蟲
            var Temp = await CrawlerService.ExecuteLockList();
        }

        #endregion




        #region "分鐘間隔工作"

        /// <summary>
        /// 門鎖狀態
        /// </summary>
        /// <param name="_PC">PerformContext</param>
        /// <returns>Task</returns>
        public static async Task DoorStatus([FromServices] PerformContext _PC) {
            // 取得服務
            var CrawlerService = ProviderService.Collection.GetService<ICrawlerService>();

            // 執行門鎖狀態爬蟲
            await CrawlerService.ExecuteLockState();
        }

        #endregion

    }
}