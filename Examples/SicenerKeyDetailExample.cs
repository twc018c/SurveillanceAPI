using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerKeyDetailExample : IExamplesProvider<ScienerKeyDetailEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerKeyDetailEntry</returns>
        public ScienerKeyDetailEntry GetExamples() {
            return new ScienerKeyDetailEntry() {
                LockID = 2746218,
                Date = Tool.GetDateLong()
            };
        }
    }
}