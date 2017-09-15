using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Response
{
    /// <summary>
    /// Represents the result of rules searching
    /// </summary>
    public class SonarRulesSearch
    {
        /// <summary>
        /// Total of rules found
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Page index of the result
        /// </summary>
        [JsonProperty(PropertyName = "p")]
        public int P { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        [JsonProperty(PropertyName = "ps")]
        public int Ps { get; set; }
        
        /// <summary>
        /// List of rules
        /// </summary>
        [JsonProperty(PropertyName = "rules")]
        public List<SonarRule> Rules { get; set; }
    }
}