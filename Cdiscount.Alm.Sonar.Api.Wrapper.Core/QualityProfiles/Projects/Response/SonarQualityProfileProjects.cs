using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Response
{
    public class SonarQualityProfileProjects
    {
        /// <summary>
        /// Quality Profile projects
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public List<SonarProjet> QualityProfileProjects { get; set; }

        /// <summary>
        /// Ancestors of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "more")]
        public bool More { get; set; }
      
    }
}
