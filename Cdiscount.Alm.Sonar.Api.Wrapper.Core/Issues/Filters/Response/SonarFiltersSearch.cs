using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Filters.Response
{
    /// <summary>
    /// Represents the result of filters search 
    /// </summary>
    public class SonarFiltersSearch
    {
        #region Sonar Properties

        /// <summary>
        /// List of issue filters
        /// </summary>
        [JsonProperty(PropertyName = "issueFilters")]
        public List<SonarFilterSearch> IssueFilters { get; set; }

        #endregion Sonar Properties
    }
}
