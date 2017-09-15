using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Shelvesets.Response
{
    public class Owner
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "uniqueName")]
        public string UniqueName { get; set; }

    }
}
