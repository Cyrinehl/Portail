using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Response;
using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Global.Response
{
    /// <summary>
    /// Represents a permission in the result of search global permission
    /// </summary>
    public class SonarPermissionInSearchGlobal : SonarPermission
    {
        /// <summary>
        /// Name of the permission
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the permission
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}