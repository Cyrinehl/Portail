using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Filters.Response
{
    /// <summary>
    /// Represents a filter of the search results
    /// </summary>
    public class SonarFilterSearch : SonarFilter
    {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "canModify")]
        public bool CanModify { get; set; }

        [JsonProperty(PropertyName = "favorite")]
        public bool Favorite { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } 
    }
}
