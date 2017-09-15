using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Response;
using Microsoft.Extensions.Configuration;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Users.Groups
{
    /// <summary>
    /// Manage user groups
    /// </summary>
    public class UserGroups : BaseObjectApi<UserGroups>
    {
        /// <summary>
        /// Search for user groups
        /// </summary>
        /// <param name="sonarUserGroupsSearchArgs">Arguments</param>
        /// <returns></returns>
        public SonarUserGroupsSearch Search(SonarUserGroupsSearchArgs sonarUserGroupsSearchArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/user_groups/search{1}", SonarApiClient.BaseAddress, (sonarUserGroupsSearchArgs == null) ? String.Empty : sonarUserGroupsSearchArgs.ToString());
            return SonarApiClient.QueryObject<SonarUserGroupsSearch>(url, configuration);
        }

        public SonarUserGroupsSearch Search(IConfigurationRoot configuration)
        {
            return Search(null);
        }

        /// <summary>
        /// Search for users with membership information with respect to a group
        /// </summary>
        /// <param name="sonarUserGroupsUsersArgs"></param>
        /// <returns></returns>
        public SonarUsersList<SonarUserOfGroup> Users(SonarUserGroupsUsersArgs sonarUserGroupsUsersArgs, IConfigurationRoot configuration)
        {
            if (sonarUserGroupsUsersArgs == null)
            {
                throw new ArgumentException("The argument can't be null.");
            }
            else if ((!sonarUserGroupsUsersArgs.Id.HasValue && String.IsNullOrEmpty(sonarUserGroupsUsersArgs.Name))
                || (sonarUserGroupsUsersArgs.Id.HasValue && !String.IsNullOrEmpty(sonarUserGroupsUsersArgs.Name)))
            {
                throw new ArgumentException("Group name or group id must be provided, not both.");
            }
            else
            {
                string url = string.Format("{0}api/user_groups/users{1}", SonarApiClient.BaseAddress, sonarUserGroupsUsersArgs);
                return SonarApiClient.QueryObject<SonarUsersList<SonarUserOfGroup>>(url, configuration);
            }
        }
    }
}
