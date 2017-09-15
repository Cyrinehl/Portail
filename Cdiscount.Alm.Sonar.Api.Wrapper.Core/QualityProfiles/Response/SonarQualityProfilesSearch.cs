using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Response
{
    public class SonarQualityProfilesSearch
    {
        #region Sonar Properties

        /// <summary>
        /// List of quality profiles
        /// </summary>
        [JsonProperty(PropertyName = "profiles")]
        public List<SonarQualityProfile> Profiles { get; set; }

        #endregion Sonar Properties

        #region addtional properties

        /// <summary>
        /// Default profile of each language
        /// Key : Language
        /// Value : Default profile key
        /// </summary>
        public Dictionary<string, string> DefaultQualityProfileByLanguage => Profiles.Where(p => p.IsDefault)
            .ToDictionary(p => p.Language, p => p.Key);

        /// <summary>
        /// Number of projects by quality profile
        /// Key : Profile key
        /// Value : Nb project
        /// </summary>
        public Dictionary<string, int> NbProjectsByQualityProfile => Profiles.ToDictionary(p => p.Key, p => p.ProjectCount);

        /// <summary>
        /// Number of projects by quality profile
        /// Key : Profile key
        /// Value : Nb Active rules
        /// </summary>
        public Dictionary<string, int> NbActiveRulesByQualityProfile => Profiles.ToDictionary(p => p.Key, p => p.ActiveRuleCount);

        #endregion addtional properties

    }
}