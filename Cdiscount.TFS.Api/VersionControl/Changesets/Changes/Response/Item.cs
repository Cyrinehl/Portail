using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Response
{
    public class Item
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }      

    }
}
