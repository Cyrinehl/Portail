using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Response
{
    /// <summary>
    /// Represents a permission template.
    /// </summary>
    public class SonarPermissionTemplate
    {
        /// <summary>
        /// Id of the permission template
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the permission template
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// ProjectKeyPattern of the permission template
        /// </summary>
        [JsonProperty(PropertyName = "projectKeyPattern")]
        public string ProjectKeyPattern { get; set; }

        /// <summary>
        /// Creation date and time
        /// </summary>
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last update date and time
        /// </summary>
        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// List of permissions
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public List<SonarPermission> Permissions { get; set; }
    }
}