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
    /// Represents a list of global permissions.
    /// </summary>
    public class SonarPermissionsSearchGlobal
    {
        /// <summary>
        /// List of global permissions
        /// </summary>
        [JsonProperty(PropertyName = "permissions")]
        public List<SonarPermissionInSearchGlobal> Permissions { get; set; }
    }
}