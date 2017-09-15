using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Response
{
    public class TfsVersioncontrolChangesetsChangesReponse
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public List<Change> Changes { get; set; }


    }
}
