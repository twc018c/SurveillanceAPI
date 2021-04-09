using System;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener Token
    /// </summary>
    public class ScienerTokenModel {

        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public int uid { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public string refresh_token { get; set; } = "";
    }
}