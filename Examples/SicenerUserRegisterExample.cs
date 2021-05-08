using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerUserRegisterExample : IExamplesProvider<SicenerUserRegisterEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerUserRegisterEntry</returns>
        public SicenerUserRegisterEntry GetExamples() {
            return new SicenerUserRegisterEntry() {
                UserName = "",
                Password = "",
                Date = Tool.GetDateLong()
            };
        }
    }
}