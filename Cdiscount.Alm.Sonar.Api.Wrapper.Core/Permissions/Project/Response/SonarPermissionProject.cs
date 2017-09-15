using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Response;
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
    /// Represents a project with its permissions
    /// </summary>
    public class SonarPermissionProject
    {
        /// <summary>
        /// Id of the project
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// key of the project
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of the project
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Project qualifier
        /// </summary>
        [JsonProperty(PropertyName = "qualifier")]
        public string Qualifier { get; set; }

        /// <summary>
        /// List of permissions
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public List<SonarPermission> Permissions { get; set; }
    }
}