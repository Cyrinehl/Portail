using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Project.Response
{
    /// <summary>
    /// Represents a list of project permissions.
    /// </summary>
    public class SonarPermissionsSearchProject
    {
        /// <summary>
        /// Paging
        /// </summary>
        [JsonProperty(PropertyName = "paging")]
        public SonarPagingResponse Paging { get; set; }

        /// <summary>
        /// List of projects
        /// </summary>
        [JsonProperty(PropertyName = "projects")]
        public List<SonarPermissionProject> Projects { get; set; }
    }
}