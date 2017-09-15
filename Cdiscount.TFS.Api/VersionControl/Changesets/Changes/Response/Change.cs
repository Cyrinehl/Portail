using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Response
{
    public class Change
    {
        [JsonProperty(PropertyName = "item")]
        public Item Item { get; set; }

        [JsonProperty(PropertyName = "changeType")]
        public string changeType { get; set; }


    }
}
