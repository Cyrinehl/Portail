using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Response
{
    public class value
    {
        [JsonProperty(PropertyName = "item")]
        public Item item { get; set; }

        [JsonProperty(PropertyName = "changeType")]
        public string changeType { get; set; }


    }
}
