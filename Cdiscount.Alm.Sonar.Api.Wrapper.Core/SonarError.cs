using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core
{
    /// <summary>
    /// Helps to handle Sonar errors
    /// </summary>
    public class SonarError
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty(PropertyName = "err_code")]
        public string Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty(PropertyName = "err_msg")]
        public string Message { get; set; }
    }
}