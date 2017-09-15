using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Response
{
    /// <summary>
    /// Represents the list of quality gates
    /// </summary>
    public class SonarQualityGatesList
    {
        #region Sonar Properties

        /// <summary>
        /// List of quality gates
        /// </summary>
        [JsonProperty(PropertyName = "qualitygates")]
        public List<SonarQualityGate> Qualitygates { get; set; }

        #endregion Sonar Properties

    }
}