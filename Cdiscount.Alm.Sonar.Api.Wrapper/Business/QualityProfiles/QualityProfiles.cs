using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Inheritance.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;




namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.QualityProfiles
{
    /// <summary>
    /// Represents a quality profile
    /// </summary>
    public class QualityProfiles : BaseObjectApi<QualityProfiles>
    {
        /// <summary>
        /// Get the list of QualityProfiles
        /// </summary>
        /// <returns></returns>
        public SonarQualityProfilesSearch Search(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/qualityprofiles/search", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarQualityProfilesSearch>(url, configuration);
        }
        public SonarQualityProfilesSearch Search(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/qualityprofiles/search", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarQualityProfilesSearch>(url, configuration);
        }


        /// <summary>
        /// Get the inheritance of a quality profile
        /// </summary>
        /// <param name="profileKey">Key of the quality profile</param>
        /// <returns></returns>
        public SonarInheritance Inheritance(SonarInheritanceArgs sonarInheritanceArgs, IConfigurationRoot configuration)
        {
            if (String.IsNullOrEmpty(sonarInheritanceArgs.ProfileKey) 
                && (String.IsNullOrEmpty(sonarInheritanceArgs.Language) || String.IsNullOrEmpty(sonarInheritanceArgs.ProfileName)))
            {
                throw new ArgumentException("Either quality profile key, or a combination of profileName + language must be set.");
            }
            string url = string.Format("{0}api/qualityprofiles/inheritance{1}", SonarApiClient.BaseAddress, sonarInheritanceArgs);
            return SonarApiClient.QueryObject<SonarInheritance>(url, configuration);
        }
        public SonarInheritance Inheritance(SonarInheritanceArgs sonarInheritanceArgs, NameValueCollection configuration)
        {
            if (String.IsNullOrEmpty(sonarInheritanceArgs.ProfileKey)
                && (String.IsNullOrEmpty(sonarInheritanceArgs.Language) || String.IsNullOrEmpty(sonarInheritanceArgs.ProfileName)))
            {
                throw new ArgumentException("Either quality profile key, or a combination of profileName + language must be set.");
            }
            string url = string.Format("{0}api/qualityprofiles/inheritance{1}", SonarApiClient.BaseAddress, sonarInheritanceArgs);
            return SonarApiClient.QueryObject<SonarInheritance>(url, configuration);
        }


        /// <summary>
        /// Get projects of a quality profile
        /// </summary>
        /// <param name="profileKey">Key of the quality profile</param>
        public SonarQualityProfileProjects Projects(SonarProjectsArgs SonarProjectsArgs, IConfigurationRoot configuration)
        {
            if (String.IsNullOrEmpty(SonarProjectsArgs.ProfileKey)
               && (String.IsNullOrEmpty(SonarProjectsArgs.PageSize) ))
            {
                throw new ArgumentException("Quality profile key And PageSize must be set.");
            }
            string url = string.Format("{0}api/qualityprofiles/projects{1}", SonarApiClient.BaseAddress, SonarProjectsArgs);
            return SonarApiClient.QueryObject<SonarQualityProfileProjects>(url, configuration);


        }
        public SonarQualityProfileProjects Projects(SonarProjectsArgs SonarProjectsArgs, NameValueCollection configuration)
        {
            if (String.IsNullOrEmpty(SonarProjectsArgs.ProfileKey)
               && (String.IsNullOrEmpty(SonarProjectsArgs.PageSize)))
            {
                throw new ArgumentException("Quality profile key And PageSize must be set.");
            }
            string url = string.Format("{0}api/qualityprofiles/projects{1}", SonarApiClient.BaseAddress, SonarProjectsArgs);
            return SonarApiClient.QueryObject<SonarQualityProfileProjects>(url, configuration);


        }








    }
}