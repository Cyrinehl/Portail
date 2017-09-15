using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Response
{
    public class Item
    {
        [JsonProperty(PropertyName = "version")]
        public string version { get; set; }

        [JsonProperty(PropertyName = "hashValue")]
        public string hashValue { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string path { get; set; }

    }
}
