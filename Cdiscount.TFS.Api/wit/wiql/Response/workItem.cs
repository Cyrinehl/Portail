using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.wiql.Response
{
    public class WorkItem
    {
        [JsonProperty(PropertyName = "rel")]
        public string Rel{ get; set; }

        [JsonProperty(PropertyName = "source")]
        public Source Source { get; set; }

        [JsonProperty(PropertyName = "target")]
        public Target Target{ get; set; }



    }
}
