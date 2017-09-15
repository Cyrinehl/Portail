using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Issues
{
    /// <summary>
    /// Read and update issues
    /// </summary>
    public class Issues : BaseObjectApi<Issues>
    {
        /// <summary>
        /// Search for issues
        /// </summary>
        /// <param name="sonarIssuesSearchArg">Search arguments. If null, return all issues</param>
        /// <returns></returns>
        public SonarIssuesSearch Search(SonarIssuesSearchArgs sonarIssuesSearchArg, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/issues/search{1}", SonarApiClient.BaseAddress, (sonarIssuesSearchArg == null)?String.Empty : sonarIssuesSearchArg.ToString());
            return SonarApiClient.QueryObject<SonarIssuesSearch>(url, configuration);
        }

        public SonarIssuesSearch Search(SonarIssuesSearchArgs sonarIssuesSearchArg, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/issues/search{1}", SonarApiClient.BaseAddress, (sonarIssuesSearchArg == null) ? String.Empty : sonarIssuesSearchArg.ToString());
            return SonarApiClient.QueryObject<SonarIssuesSearch>(url, configuration);
        }


        public async Task<SonarIssuesSearch> SearchAsync(SonarIssuesSearchArgs sonarIssuesSearchArg, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/issues/search{1}", SonarApiClient.BaseAddress, (sonarIssuesSearchArg == null) ? String.Empty : sonarIssuesSearchArg.ToString());
            return await SonarApiClient.QueryObjectAsync<SonarIssuesSearch>(url, configuration).ConfigureAwait(false);
        }
        public async Task<SonarIssuesSearch> SearchAsync(SonarIssuesSearchArgs sonarIssuesSearchArg, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/issues/search{1}", SonarApiClient.BaseAddress, (sonarIssuesSearchArg == null) ? String.Empty : sonarIssuesSearchArg.ToString());
            return await SonarApiClient.QueryObjectAsync<SonarIssuesSearch>(url, configuration).ConfigureAwait(false);
        }

    }
}