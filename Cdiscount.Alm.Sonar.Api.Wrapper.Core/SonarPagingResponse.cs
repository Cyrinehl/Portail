using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core
{
    /// <summary>
    /// Helps to handle Sonar queries that spans multiples "pages"
    /// </summary>
    public class SonarPagingResponse
    {
        /// <summary>
        /// Index of the page
        /// </summary>
        [JsonProperty(PropertyName = "pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// Number of elements per page
        /// </summary>
        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Total number of elements returned
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }        
    }
}