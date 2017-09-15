using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Response
{
    public class ComponentMeasureResponse
    {
        /// <summary>
        /// Component 
        /// </summary>         
        [JsonProperty(PropertyName = "component")]
        public SonarComponentMeasures SonarComponentMeasures { get; set; }



    }
}
