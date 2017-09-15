using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Response
{
    /// <summary>
    /// Represents a condition of a quality gate
    /// </summary>
    public class SonarQualityGateCondition
    {
        /// <summary>
        /// Id of the condition
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Metric of the condition
        /// </summary>
        [JsonProperty(PropertyName = "metric")]
        public string Metric { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        [JsonProperty(PropertyName = "op")]
        public string Op { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        /// <summary>
        /// Warning
        /// </summary>
        [JsonProperty(PropertyName = "warning")]
        public string Warning { get; set; }

        /// <summary>
        /// Over leak period
        /// </summary>
        [JsonProperty(PropertyName = "period")]
        public int? Period { get; set; }
    }
}