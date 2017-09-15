using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Response
{
    public class ComponentMeasure
    {
        /// <summary>
        /// Name of the metric
        /// </summary>
        [JsonProperty(PropertyName = "metric")]
        public string Metric { get; set; }

        /// <summary>
        /// Value of the metric
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

     
    }
}
