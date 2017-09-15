using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response
{
    /// <summary>
    /// Represents a Sonar search among issues
    /// </summary>
    public class SonarIssuesSearch
    {
        /// <summary>
        /// Paging info
        /// </summary>
        [JsonProperty(PropertyName = "paging")]
        public SonarPagingResponse Paging { get; set; }

        /// <summary>
        /// List of found issues
        /// </summary>
        [JsonProperty(PropertyName = "issues")]
        public List<SonarIssue> Issues { get; set; }

        /// <summary>
        /// List of components
        /// </summary>
        [JsonProperty(PropertyName = "components")]
        public List<SonarComponent> Components { get; set; }

        /// <summary>
        /// Details of the rules referenced by the issues found
        /// </summary>
        public List<SonarRule> Rules { get; set; }

        /// <summary>
        /// Details about the issue assignees
        /// </summary>
        [JsonProperty(PropertyName = "users")]
        public List<SonarUser> Users { get; set; }

        /// <summary>
        /// list of languages.
        /// </summary>
        [JsonProperty(PropertyName = "languages")]
        public List<SonarLanguage> Languages { get; set; }
    }
}