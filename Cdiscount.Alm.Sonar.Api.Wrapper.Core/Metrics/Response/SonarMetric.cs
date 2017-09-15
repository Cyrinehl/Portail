using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Metrics.Response
{
    /// <summary>
    /// Represents a metric
    /// </summary>
    public class SonarMetric
    {
        /// <summary>
        /// Id of the metric
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// key of the metric
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Namme of the metric
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the metric
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Domain of the metric
        /// </summary>
        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }
        
        /// <summary>
        /// Type of the metric
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Direction of the metric
        /// </summary>
        [JsonProperty(PropertyName = "direction")]
        public int Direction { get; set; }

        [JsonProperty(PropertyName = "qualitative")]
        public bool Qualitative { get; set; }

        [JsonProperty(PropertyName = "hidden")]
        public bool Hidden { get; set; }

        [JsonProperty(PropertyName = "custom")]
        public bool Custom { get; set; }
    }
}