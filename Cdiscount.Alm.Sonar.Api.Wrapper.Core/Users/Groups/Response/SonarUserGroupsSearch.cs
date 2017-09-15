using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Response
{
    /// <summary>
    /// Represents a list of user groups
    /// </summary>
    public class SonarUserGroupsSearch
    {
        /// <summary>
        /// Total of users
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Page index
        /// </summary>
        [JsonProperty(PropertyName = "p")]
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        [JsonProperty(PropertyName = "ps")]
        public int PageSize { get; set; }

        /// <summary>
        /// Groups
        /// </summary>
        [JsonProperty(PropertyName = "groups")]
        public List<SonarUserGroup> Groups { get; set; }
    }
}