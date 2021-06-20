using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardBatchLogListExample : IExamplesProvider<CardBatchLogListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardBatchLogListEntry</returns>
        public CardBatchLogListEntry GetExamples() {
            return new CardBatchLogListEntry() {
                PageNow = 1,
                PageShow = 20,
                StartTime = new DateTime(2021, 01, 01),
                EndTime = new DateTime(2021, 12, 31),
                Keyword = "",
                UserSeq = 0
            };
        }
    }
}