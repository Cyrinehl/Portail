using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.Build.Builds.Response
{
    public class Element
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "buildNumber")]
        public string BuildNumber { get; set; }


        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public DateTime startTime { get; set; }

        [JsonProperty(PropertyName = "finishTime")]
        public DateTime FinishTime { get; set; }

        [JsonProperty(PropertyName = "definition")]
        public Definition Defintion { get; set; }

        [JsonProperty(PropertyName = "requestedFor")]
        public requestedFor RequestedFor { get; set; }
        

    }
}
