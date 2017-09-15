using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Repositories.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Tags.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;


namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Rules
{
    /// <summary>
    /// Represents Sonar rules
    /// </summary>
    public class Rules : BaseObjectApi<Rules>
    {
        /// <summary>
        /// Get the list of rules
        /// </summary>
        /// <param name="sonarRulesSearchArgs">Search arguments</param>
        /// <returns></returns>
        public SonarRulesSearch Search(SonarRulesSearchArgs sonarRulesSearchArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/rules/search{1}", SonarApiClient.BaseAddress, (sonarRulesSearchArgs == null)?String.Empty : sonarRulesSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarRulesSearch>(url, configuration);
        }
        public SonarRulesSearch Search(SonarRulesSearchArgs sonarRulesSearchArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/rules/search{1}", SonarApiClient.BaseAddress, (sonarRulesSearchArgs == null) ? String.Empty : sonarRulesSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarRulesSearch>(url, configuration);
        }

        /// <summary>
        /// List available rule repositories
        /// </summary>
        /// <returns></returns>
        public SonarRepositories Repositories(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/rules/repositories", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarRepositories>(url, configuration);
        }
        public SonarRepositories Repositories(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/rules/repositories", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarRepositories>(url, configuration);
        }

        // <summary>
        /// List available rule tags
        /// </summary>
        /// <returns></returns>
        public SonarTags Tags(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/rules/tags", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarTags>(url, configuration);
        }
        public SonarTags Tags(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/rules/tags", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarTags>(url, configuration);
        }
    }
}