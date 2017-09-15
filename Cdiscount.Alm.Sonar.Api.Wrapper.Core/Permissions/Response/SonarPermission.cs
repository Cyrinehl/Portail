using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Response
{
    /// <summary>
    /// Represents a permission
    /// </summary>
    public class SonarPermission
    {
        /// <summary>
        /// key of the permission
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Number of users
        /// </summary>
        [JsonProperty(PropertyName = "usersCount")]
        public int UsersCount { get; set; }

        /// <summary>
        /// Number of groups
        /// </summary>
        [JsonProperty(PropertyName = "groupsCount")]
        public int GroupsCount { get; set; }

    }
}