using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityGates.Response
{
    /// <summary>
    /// Represents the details of a quality gate
    /// </summary>
    public class SonarQualityGateShow : SonarQualityGate
    {
        #region Sonar Properties

        /// <summary>
        /// List of the quality gate's conditions
        /// </summary>
        [JsonProperty(PropertyName = "conditions")]
        public List<SonarQualityGateCondition> Conditions { get; set; }

        #endregion Sonar Properties

    }
}