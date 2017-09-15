using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Response
{
    public class TfsVersionControlChangesetsResponse
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public List<Changeset> ChangeSets { get; set; }
    }
}
