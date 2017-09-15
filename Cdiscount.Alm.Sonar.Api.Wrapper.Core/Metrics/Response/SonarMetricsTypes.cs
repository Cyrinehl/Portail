using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Metrics.Response
{
    /// <summary>
    /// Represents a list of metric types
    /// </summary>
    public class SonarMetricsTypes
    {
        /// <summary>
        /// List of types
        /// </summary>
        [JsonProperty(PropertyName = "types")]
        public List<string> Types { get; set; }
    }
}