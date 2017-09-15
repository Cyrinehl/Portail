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
    /// Represents a list of metrics
    /// </summary>
    public class SonarMetricsSearch
    {
        /// <summary>
        /// List of metrics
        /// </summary>
        [JsonProperty(PropertyName = "metrics")]
        public List<SonarMetric> Metrics { get; set; }

        /// <summary>
        /// Total numbers of metrics
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Page index of the result
        /// </summary>
        [JsonProperty(PropertyName = "p")]
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size of the pagination
        /// </summary>
        [JsonProperty(PropertyName = "ps")]
        public int PageSize { get; set; }
    }
}