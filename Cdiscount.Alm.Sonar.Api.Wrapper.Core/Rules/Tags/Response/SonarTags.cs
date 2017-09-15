using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Tags.Response
{
    /// <summary>
    /// Represents the list of tags
    /// </summary>
    public class SonarTags
    {
        /// <summary>
        /// List of tags
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }
    }
}