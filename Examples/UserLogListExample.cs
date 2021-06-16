using Surveillance.Enums;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class UserLogListExample : IExamplesProvider<UserLogListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>UserLogEntry</returns>
        public UserLogListEntry GetExamples() {
            return new UserLogListEntry() {
                StartTime = new DateTime(2021, 01, 01),
                EndTime = new DateTime(2021, 12, 31),
                UserSeq = 1,
                Status = USER_LOG_STATUS.LOGIN
            };
        }
    }
}