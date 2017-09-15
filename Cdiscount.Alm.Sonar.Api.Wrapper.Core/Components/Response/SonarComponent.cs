using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.Response
{
    /// <summary>
    /// Represents a Sonar component (of a project)
    /// </summary>
    public class SonarComponent : ISonarObject
    {
        /// <summary>
        /// id of the component
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Key of the component
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// uuid of the component
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// is component enabled
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Qualifier of the component
        /// </summary>
        [JsonProperty(PropertyName = "qualifier")]
        public string Qualifier { get; set; }

        /// <summary>
        /// Name of the component
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Long name of the component
        /// </summary>
        [JsonProperty(PropertyName = "longName")]
        public string LongName { get; set; }

        /// <summary>
        /// path of the component
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// projectId of the component
        /// </summary>
        [JsonProperty(PropertyName = "projectId")]
        public int ProjectId { get; set; }

        /// <summary>
        /// subProjectId of the component
        /// </summary>
        [JsonProperty(PropertyName = "subProjectId")]
        public int SubProjectId { get; set; }
    }
}