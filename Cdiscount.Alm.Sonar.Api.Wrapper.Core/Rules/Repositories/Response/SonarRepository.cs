using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Repositories.Response
{
    /// <summary>
    /// Represents a Sonar repository
    /// </summary>
    public class SonarRepository
    {
        /// <summary>
        /// Key
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
    }
}