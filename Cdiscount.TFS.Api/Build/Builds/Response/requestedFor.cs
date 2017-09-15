using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.Build.Builds.Response
{
    public class requestedFor
    {

        [JsonProperty(PropertyName = "displayName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "uniqueName")]
        public string UniqueName { get; set; }

    }
}
