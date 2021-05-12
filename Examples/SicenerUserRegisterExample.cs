using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerUserRegisterExample : IExamplesProvider<ScienerUserRegisterEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerUserRegisterEntry</returns>
        public ScienerUserRegisterEntry GetExamples() {
            return new ScienerUserRegisterEntry() {
                UserName = "",
                Password = "",
                Date = Tool.GetDateLong()
            };
        }
    }
}