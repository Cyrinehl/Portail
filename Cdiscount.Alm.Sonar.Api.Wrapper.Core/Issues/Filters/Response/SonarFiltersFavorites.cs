using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Filters.Response
{
    /// <summary>
    /// Represents a list favoriteFilters
    /// </summary>
    public class SonarFiltersFavorites
    {
        /// <summary>
        /// List of favorite filters
        /// </summary>
        [JsonProperty(PropertyName = "favoriteFilters")]
        public List<SonarFilter> FavoriteFilters { get; set; }
    }
}
