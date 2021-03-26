using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class UserExample : IExamplesProvider<UserEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>UserEntry</returns>
        public UserEntry GetExamples() {
            return new UserEntry() {
                Keyword = ""
            };
        }
    }
}