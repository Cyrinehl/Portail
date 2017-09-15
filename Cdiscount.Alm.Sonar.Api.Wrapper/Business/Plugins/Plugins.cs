using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Plugins.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Plugins.Parameters;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;


namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Plugins
{
    /// <summary>
    /// Manage the plugins on the server, including installing, uninstalling, and upgrading.
    /// </summary>
    public class Plugins : BaseObjectApi<Plugins>
    {
        /// <summary>
        /// Get the list of all the plugins installed on the SonarQube instance, sorted by plugin name.        
        /// </summary>
        /// <param name="sonarPluginsInstalledArgs">Arguments</param>
        /// <returns></returns>
        public SonarPluginsInstalled Installed(SonarPluginsInstalledArgs sonarPluginsInstalledArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/plugins/installed{1}", SonarApiClient.BaseAddress, (sonarPluginsInstalledArgs == null) ? string.Empty : sonarPluginsInstalledArgs.ToString());
            return SonarApiClient.QueryObject<SonarPluginsInstalled>(url, configuration);
        }
        public SonarPluginsInstalled Installed(SonarPluginsInstalledArgs sonarPluginsInstalledArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/plugins/installed{1}", SonarApiClient.BaseAddress, (sonarPluginsInstalledArgs == null) ? string.Empty : sonarPluginsInstalledArgs.ToString());
            return SonarApiClient.QueryObject<SonarPluginsInstalled>(url, configuration);
        }


        public SonarPluginsInstalled Installed(IConfigurationRoot configuration)
        {
            return Installed(null, configuration);
        }
        public SonarPluginsInstalled Installed(NameValueCollection configuration)
        {
            return Installed(null, configuration);
        }
    }
}