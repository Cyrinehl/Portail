using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Response
{
    /// <summary>
    /// Represents the inheritance of a quality profile
    /// </summary>
    public class SonarInheritance
    {
        /// <summary>
        /// Profile
        /// </summary>
        [JsonProperty(PropertyName = "profile")]
        public SonarInheritanceProfile Profile { get; set; }

        /// <summary>
        /// ancestors of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "ancestors")]
        public List<SonarInheritanceProfile> Ancestors { get; set; }

        /// <summary>
        /// children of the quality profile
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public List<SonarInheritanceProfile> Children { get; set; }
    }
}