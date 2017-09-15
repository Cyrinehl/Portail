using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Response
{
    public class TfsVersioncontrolShelvesetsChangesReponse
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public List<value> Value { get; set; }     


    }
}
