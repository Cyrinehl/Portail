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
    public class SonarPlugin
    {
        /// <summary>
        /// key of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Version of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// License of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "license")]
        public string License { get; set; }

        /// <summary>
        /// Organization Name of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "organizationName")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// Organization Url Name of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "organizationUrl")]
        public string OrganizationUrl { get; set; }

        /// <summary>
        /// Homepage Url of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "homepageUrl")]
        public string HomepageUrl { get; set; }

        /// <summary>
        /// Issue Tracker Url of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "issueTrackerUrl")]
        public string IssueTrackerUrl { get; set; }

        /// <summary>
        /// Implementation Build Name of the plugin
        /// </summary>
        [JsonProperty(PropertyName = "implementationBuild")]
        public string ImplementationBuild { get; set; }
    }
}