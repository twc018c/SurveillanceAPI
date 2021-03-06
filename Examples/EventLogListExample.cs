using Surveillance.Enums;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class EventLogListExample : IExamplesProvider<EventLogListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>EventLogEntry</returns>
        public EventLogListEntry GetExamples() {
            return new EventLogListEntry() {
                PageNow = 1,
                PageShow = 20,
                StartTime = new DateTime(2021, 01, 01),
                EndTime = new DateTime(2021, 12, 31),
                Keyword = "",
                UserSeq = 0,
                Status = EVENT_LOG_STATUS.UNKNOW
            };
        }
    }
}