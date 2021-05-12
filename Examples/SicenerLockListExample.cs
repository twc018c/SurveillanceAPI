using Surveillance.Enums;
using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerLockListExample : IExamplesProvider<ScienerLockListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerLockListEntry</returns>
        public ScienerLockListEntry GetExamples() {
            return new ScienerLockListEntry() {
                LockAlias = "",
                Type = SCIENER_DEVICE_TYPE.LOCK,
                PageNo = 1,
                PageSize = 20,
                Date = Tool.GetDateLong()
            };
        }
    }
}