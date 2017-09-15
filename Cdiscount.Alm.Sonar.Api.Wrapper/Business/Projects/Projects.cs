using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Parameters;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;



namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Projects
{
    public class Projects : BaseObjectApi<Projects>
    {
        /// <summary>
        /// Search for projects
        /// </summary>
        /// <param name="sonarProjectsIndexArgs">Arguments</param>
        /// <returns></returns>
        public List<SonarProject> Index(SonarProjectsIndexArgs sonarProjectsIndexArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/projects/index{1}", SonarApiClient.BaseAddress, (sonarProjectsIndexArgs == null)?String.Empty : sonarProjectsIndexArgs.ToString());
            return SonarApiClient.QueryList<SonarProject>(url,configuration);
        }
        public List<SonarProject> Index(SonarProjectsIndexArgs sonarProjectsIndexArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/projects/index{1}", SonarApiClient.BaseAddress, (sonarProjectsIndexArgs == null) ? String.Empty : sonarProjectsIndexArgs.ToString());
            return SonarApiClient.QueryList<SonarProject>(url, configuration);
        }
    }
}