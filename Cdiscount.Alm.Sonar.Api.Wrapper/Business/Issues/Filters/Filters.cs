using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Filters.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Issues.Filters
{
    /// <summary>
    /// Represents issue filters
    /// </summary>
    public class Filters : BaseObjectApi<Filters>
    {
        /// <summary>
        /// List issue filters marked as favorite by request user
        /// </summary>
        /// <returns></returns>
        public SonarFiltersFavorites Favorites(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/issue_filters/favorites", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarFiltersFavorites>(url, configuration);
        }

        public SonarFiltersFavorites Favorites(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/issue_filters/favorites", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarFiltersFavorites>(url, configuration);
        }

        /// <summary>
        /// List issue filters and shared issue filters of the current user
        /// </summary>
        /// <returns></returns>

        public SonarFiltersSearch Search(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/issue_filters/search", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarFiltersSearch>(url,configuration);
        }

        public SonarFiltersSearch Search(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/issue_filters/search", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarFiltersSearch>(url, configuration);
        }
    }
}
