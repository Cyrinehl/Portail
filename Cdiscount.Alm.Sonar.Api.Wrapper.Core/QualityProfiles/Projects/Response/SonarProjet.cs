using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Response
{
    public class SonarProjet
    {
        /// <summary>
        /// Key of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// Name of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// bool Selected
        /// </summary>
        [JsonProperty(PropertyName = "selected")]
        public bool Selected { get; set; }
    }
}
