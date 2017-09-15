using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Response
{
    public class Author
    {
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "uniqueName")]
        public string UniqueName { get; set; }

        

        


    }
}
