using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Response
{
    public class SonarQualityProfile
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
        /// language of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// languageName of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "languageName")]
        public string LanguageName { get; set; }

        /// <summary>
        /// parentKey of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "parentKey")]
        public string ParentKey { get; set; }

        /// <summary>
        /// parentName of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "parentName")]
        public string ParentName { get; set; }
        
        /// <summary>
        /// default quality profile or not
        /// </summary>
        [JsonProperty(PropertyName = "isDefault")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// activeRuleCount of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "activeRuleCount")]
        public int ActiveRuleCount { get; set; }

        /// <summary>
        /// projectCount of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "projectCount")]
        public int ProjectCount { get; set; }

        /// <summary>
        /// Time of last update of rules
        /// </summary>
        [JsonProperty(PropertyName = "rulesUpdatedAt")]
        public DateTime RulesUpdatedAt { get; set; }
    }
}