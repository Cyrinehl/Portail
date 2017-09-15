using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Response
{
    /// <summary>
    /// Represents a project
    /// </summary>
    public class SonarProject
    {
        /// <summary>
        /// Id of the project
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// key of the project
        /// </summary>
        [JsonProperty(PropertyName = "k")]
        public string Key { get; set; }

        /// <summary>
        /// Namme of the project
        /// </summary>
        [JsonProperty(PropertyName = "nm")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "sc")]
        public string Sc { get; set; }

        [JsonProperty(PropertyName = "qu")]
        public string Qu { get; set; }
    }
}