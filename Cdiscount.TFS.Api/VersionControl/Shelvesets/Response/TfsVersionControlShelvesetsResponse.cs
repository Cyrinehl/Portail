using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Shelvesets.Response
{
    public class TfsVersionControlShelvesetsResponse
    {


        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "owner")]
        public Owner Owner { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        public DateTime createdDate { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }






    }
}
