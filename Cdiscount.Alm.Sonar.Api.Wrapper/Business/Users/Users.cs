using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Users
{
    /// <summary>
    /// Manage users
    /// </summary>
    public class Users : BaseObjectApi<Users>
    {
        /// <summary>
        /// Get a list of users
        /// </summary>
        /// <param name="sonarUsersSearchArgs">Arguments</param>
        /// <returns></returns>
        public SonarUsersList<SonarUser> Search(SonarUsersSearchArgs sonarUsersSearchArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/users/search{1}", SonarApiClient.BaseAddress, (sonarUsersSearchArgs == null) ? String.Empty : sonarUsersSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarUsersList<SonarUser>>(url, configuration);
        }
        public SonarUsersList<SonarUser> Search(SonarUsersSearchArgs sonarUsersSearchArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/users/search{1}", SonarApiClient.BaseAddress, (sonarUsersSearchArgs == null) ? String.Empty : sonarUsersSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarUsersList<SonarUser>>(url, configuration);
        }

        public SonarUsersList<SonarUser> Search(IConfigurationRoot configuration)
        {
            return Search(null, configuration);
        }
        public SonarUsersList<SonarUser> Search(NameValueCollection configuration)
        {
            return Search(null, configuration);
        }
    }
}
