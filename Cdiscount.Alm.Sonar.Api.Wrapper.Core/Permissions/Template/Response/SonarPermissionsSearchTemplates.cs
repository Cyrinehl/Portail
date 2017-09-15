using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Response
{
    /// <summary>
    /// Represents a list of permission templates.
    /// </summary>
    public class SonarPermissionsSearchTemplates
    {
        /// <summary>
        /// List of permission templates
        /// </summary>
        [JsonProperty(PropertyName = "permissionTemplates")]
        public List<SonarPermissionTemplate> PermissionTemplates { get; set; }
    }
}