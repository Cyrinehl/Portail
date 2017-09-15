using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Plugins.Response
{
    /// <summary>
    /// Represents a sonar plugin
    /// </summary>
    public class SonarPluginsInstalled
    {
        /// <summary>
        /// List of installed plugins
        /// </summary>
        [JsonProperty(PropertyName = "plugins")]
        public List<SonarPlugin> Plugins { get; set; }
    }
}