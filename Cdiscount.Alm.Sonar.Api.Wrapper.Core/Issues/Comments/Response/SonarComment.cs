using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Comment.Response
{
    public class SonarComment : ISonarObject
    {
        /// <summary>
        /// Id of sonar comment
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// login of user who's post sonar comment
        /// </summary>
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        /// <summary>
        /// the sonar comment
        /// </summary>
        [JsonProperty(PropertyName = "htmlText")]
        public string HtmlText { get; set; }

        [JsonProperty(PropertyName = "markdown")]
        public string Markdown { get; set; }

        [JsonProperty(PropertyName = "updatable")]
        public bool Updatable { get; set; }

        /// <summary>
        /// date of sonar comment
        /// </summary>
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}