using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Response
{
    /// <summary>
    /// Represents the result of a quality gat searching
    /// </summary>
    public class SonarQualityGatesSearch
    {
        #region Sonar Properties

        /// <summary>
        /// Indicate if there is more results on the next pages
        /// </summary>
        [JsonProperty(PropertyName = "more")]
        public bool More { get; set; }

        /// <summary>
        /// List of results (on the current page)
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<SonarQualityGatesSearchResult> Results { get; set; }

        #endregion Sonar Properties

    }
}