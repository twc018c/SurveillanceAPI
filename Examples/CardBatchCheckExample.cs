using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardBatchCheckExample : IExamplesProvider<CardBatchCheckEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardBatchCheckEntry</returns>
        public CardBatchCheckEntry GetExamples() {
            return new CardBatchCheckEntry() {
                CardID = "",
                HolderID = "",
                Time = new DateTime(2021, 04, 01)
            };
        }
    }
}