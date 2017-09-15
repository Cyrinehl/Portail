using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Response
{
    /// <summary>
    /// Represents a quality profile in an inheritance result
    /// </summary>
    public class SonarInheritanceProfile
    {
        /// <summary>
        /// Key of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// parent of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "parent")]
        public string Parent { get; set; }
        
        /// <summary>
        /// activeRuleCount of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "activeRuleCount")]
        public int ActiveRuleCount { get; set; }

        /// <summary>
        /// overridingRuleCount of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "overridingRuleCount")]
        public int OverridingRuleCount { get; set; }
    }
}