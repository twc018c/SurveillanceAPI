using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerKeyExample : IExamplesProvider<SicenerKeyEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerKeyEntry</returns>
        public SicenerKeyEntry GetExamples() {
            return new SicenerKeyEntry() {
                LockID = 2746218,
                Date = Tool.GetDateLong()
            };
        }
    }
}