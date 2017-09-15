using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Repositories.Response
{
    /// <summary>
    /// Represents the repositories of rules
    /// </summary>
    public class SonarRepositories
    {
        /// <summary>
        /// List of repositories
        /// </summary>
        [JsonProperty(PropertyName = "repositories")]
        public List<SonarRepository> Repositories { get; set; }
    }
}