using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Filters.Response
{
    /// <summary>
    /// Represents an issue filter
    /// </summary>
    public class SonarFilter
    {
        /// <summary>
        /// Id of the filter
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the filter
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// User of the filter 
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

        /// <summary>
        /// Filter shared or not
        /// </summary>
        [JsonProperty(PropertyName = "shared")]
        public bool Shared { get; set; }
    }
}