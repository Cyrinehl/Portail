using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Response
{
    /// <summary>
    /// Represent a project in the results of quality gate search
    /// </summary>
    public class SonarQualityGatesSearchResult
    {
        #region Sonar Properties

        /// <summary>
        /// Id of the project
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the project
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Selected or not
        /// </summary>
        [JsonProperty(PropertyName = "selected")]
        public bool Selected { get; set; } 

        #endregion Sonar Properties

    }
}