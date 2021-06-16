using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class UserListExample : IExamplesProvider<UserListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>UserEntry</returns>
        public UserListEntry GetExamples() {
            return new UserListEntry() {
                Keyword = ""
            };
        }
    }
}