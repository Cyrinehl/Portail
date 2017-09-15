using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Metrics.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Metrics.Parameters;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Metrics
{
    /// <summary>
    /// Manage metrics
    /// </summary>
    public class Metrics : BaseObjectApi<Metrics>
    {
        /// <summary>
        /// Search for metrics
        /// </summary>
        /// <param name="sonarMetricsSearchArgs"></param>
        /// <returns></returns>
        public SonarMetricsSearch Search(SonarMetricsSearchArgs sonarMetricsSearchArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/metrics/search{1}", SonarApiClient.BaseAddress, (sonarMetricsSearchArgs == null) ? String.Empty : sonarMetricsSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarMetricsSearch>(url, configuration);
        }
        public SonarMetricsSearch Search(SonarMetricsSearchArgs sonarMetricsSearchArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/metrics/search{1}", SonarApiClient.BaseAddress, (sonarMetricsSearchArgs == null) ? String.Empty : sonarMetricsSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarMetricsSearch>(url, configuration);
        }

        /// <summary>
        /// List all available metric types
        /// </summary>
        /// <returns></returns>
        public SonarMetricsTypes Types(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/metrics/types", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarMetricsTypes>(url, configuration);
        }
        public SonarMetricsTypes Types(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/metrics/types", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarMetricsTypes>(url, configuration);
        }
    }
}