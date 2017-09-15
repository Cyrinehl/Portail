using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Response
{
    /// <summary>
    /// Represents a list of users
    /// </summary>
    public class SonarUsersList<T>
    {
        /// <summary>
        /// Total number of users
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Index of the page
        /// </summary>
        [JsonProperty(PropertyName = "p")]
        public int PageIndex { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        [JsonProperty(PropertyName = "ps")]
        public int PageSize { get; set; }

        /// <summary>
        /// List of users
        /// </summary>
        [JsonProperty(PropertyName = "users")]
        public List<T> Users { get; set; }
    }
}