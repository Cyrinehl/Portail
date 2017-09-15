using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.wiql.Response
{
    public class Target
    {
        [JsonProperty(PropertyName = "id")]
        public string TargetId { get; set; }
    }
}
