using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace Cdiscount.TFS.Api
{
    public class TfsBuildDefinitionsResponse
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public List<Definition> BuildDefinitions { get; set; }



    }
}
