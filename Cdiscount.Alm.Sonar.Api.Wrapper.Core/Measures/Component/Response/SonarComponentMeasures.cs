using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Response
{
    public class SonarComponentMeasures
    {

        /// <summary>
        /// Component Key
        /// </summary>       
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
     
        /// <summary>
        /// List of measures
        /// </summary>
        [JsonProperty(PropertyName = "measures")]
        public List<ComponentMeasure> Measures { get; set; }

    }
}
