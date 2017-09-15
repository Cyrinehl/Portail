using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Response
{
    public class Component
    {
        [JsonProperty(PropertyName = "id")]
        public string ComponentId { get; set; }


        [JsonProperty(PropertyName = "key")]
        public string ComponentKey { get; set; }


        [JsonProperty(PropertyName = "name")]
        public string ComponentName { get; set; }


        [JsonProperty(PropertyName = "qualifier")]
        public string Qualifier { get; set; }


        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }


        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
    }
}
