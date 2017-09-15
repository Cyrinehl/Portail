using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Languages.Response
{
    /// <summary>
    /// Represents a list of supported programming languages
    /// </summary>
    public class SonarLanguagesList
    {
        /// <summary>
        /// List of languages
        /// </summary>
        [JsonProperty(PropertyName = "languages")]
        public List<SonarLanguage> Languages { get; set; }
    }
}