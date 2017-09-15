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
    /// Represents a Sonar rule
    /// </summary>
    public class SonarRule : ISonarObject
    {
        /// <summary>
        /// Key of the rule
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Repository
        /// </summary>
        [JsonProperty(PropertyName = "repo")]
        public string Repo { get; set; }

        /// <summary>
        /// Name of the rule
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// lang of the rule
        /// </summary>
        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        /// <summary>
        /// Status of the rule
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// langName of the rule
        /// </summary>
        [JsonProperty(PropertyName = "langName")]
        public string LangName { get; set; }
    }
}