using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Measures
{
    public class Measures : BaseObjectApi<Measures>
    {
        /// <summary>
        /// Get measures of a project
        /// </summary>
        /// <param name="projectKey">Key of the quality profile</param>
        public ComponentMeasureResponse Component(SonarComponentArgs SonarComponentArgs, IConfigurationRoot configuration)
        {
            if (String.IsNullOrEmpty(SonarComponentArgs.ComponentKey))              
            {
                throw new ArgumentException("ComponentKey must be set.");
            }

            string url = string.Format("{0}api/measures/component{1}", SonarApiClient.BaseAddress, (SonarComponentArgs == null) ? String.Empty : SonarComponentArgs.ToString());
            return SonarApiClient.QueryObject<ComponentMeasureResponse>(url, configuration);
        }

        public ComponentMeasureResponse Component(SonarComponentArgs SonarComponentArgs, NameValueCollection configuration)
        {
            if (String.IsNullOrEmpty(SonarComponentArgs.ComponentKey))
            {
                throw new ArgumentException("ComponentKey must be set.");
            }

            string url = string.Format("{0}api/measures/component{1}", SonarApiClient.BaseAddress, (SonarComponentArgs == null) ? String.Empty : SonarComponentArgs.ToString());
            return SonarApiClient.QueryObject<ComponentMeasureResponse>(url, configuration);
        }


    }
}
