using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class Example : IExamplesProvider<Entry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>Entry</returns>
        public Entry GetExamples() {
            return new Entry() {
                PageNow = 1,
                PageShow = 20
            };
        }
    }
}