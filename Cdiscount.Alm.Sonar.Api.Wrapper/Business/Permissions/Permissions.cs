using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Global.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Project.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Project.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Permissions
{
    /// <summary>
    /// Manage permission templates
    /// </summary>
    public class Permissions : BaseObjectApi<Permissions>
    {
        /// <summary>
        /// List global permissions
        /// </summary>
        /// <returns></returns>
        public SonarPermissionsSearchGlobal SearchGlobal(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/permissions/search_global_permissions", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarPermissionsSearchGlobal>(url, configuration);
        }
        public SonarPermissionsSearchGlobal SearchGlobal(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/permissions/search_global_permissions", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarPermissionsSearchGlobal>(url, configuration);
        }

        /// <summary>
        /// List project permissions. A project can be a technical project, a view or a developer
        /// </summary>
        /// <param name="sonarPermissionsSearchProjectArgs"></param>
        /// <returns></returns>
        public SonarPermissionsSearchProject SearchProject(SonarPermissionsSearchProjectArgs sonarPermissionsSearchProjectArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/permissions/search_project_permissions{1}", SonarApiClient.BaseAddress
                , (sonarPermissionsSearchProjectArgs == null) ? String.Empty : sonarPermissionsSearchProjectArgs.ToString());
            return SonarApiClient.QueryObject<SonarPermissionsSearchProject>(url, configuration);
        }
        public SonarPermissionsSearchProject SearchProject(SonarPermissionsSearchProjectArgs sonarPermissionsSearchProjectArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/permissions/search_project_permissions{1}", SonarApiClient.BaseAddress
                , (sonarPermissionsSearchProjectArgs == null) ? String.Empty : sonarPermissionsSearchProjectArgs.ToString());
            return SonarApiClient.QueryObject<SonarPermissionsSearchProject>(url, configuration);
        }

        public SonarPermissionsSearchProject SearchProject(IConfigurationRoot configuration)
        {
            return SearchProject(null, configuration);
        }
        public SonarPermissionsSearchProject SearchProject(NameValueCollection configuration)
        {
            return SearchProject(null, configuration);
        }

        /// <summary>
        /// List permission templates
        /// </summary>
        /// <param name="sonarPermissionsSearchTemplatesArgs"></param>
        /// <returns></returns>
        public SonarPermissionsSearchTemplates SearchTemplate(SonarPermissionsSearchTemplatesArgs sonarPermissionsSearchTemplatesArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/permissions/search_templates{1}", SonarApiClient.BaseAddress
                , (sonarPermissionsSearchTemplatesArgs == null) ? String.Empty : sonarPermissionsSearchTemplatesArgs.ToString());
            return SonarApiClient.QueryObject<SonarPermissionsSearchTemplates>(url, configuration);
        }
        public SonarPermissionsSearchTemplates SearchTemplate(SonarPermissionsSearchTemplatesArgs sonarPermissionsSearchTemplatesArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/permissions/search_templates{1}", SonarApiClient.BaseAddress
                , (sonarPermissionsSearchTemplatesArgs == null) ? String.Empty : sonarPermissionsSearchTemplatesArgs.ToString());
            return SonarApiClient.QueryObject<SonarPermissionsSearchTemplates>(url, configuration);
        }

        public SonarPermissionsSearchTemplates SearchTemplate(IConfigurationRoot configuration)
        {
            return SearchTemplate(null, configuration);
        }
        public SonarPermissionsSearchTemplates SearchTemplate(NameValueCollection configuration)
        {
            return SearchTemplate(null, configuration);
        }
    }
}