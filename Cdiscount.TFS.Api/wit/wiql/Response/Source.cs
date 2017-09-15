using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.wiql.Response
{
    public class Source
    {
        [JsonProperty(PropertyName = "id")]
        public string SourceId { get; set; }

    }
}
