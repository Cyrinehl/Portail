using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Parameters
{
    public class SonarProjectsArgs
    {
        /// <summary>
        /// A quality profile key. 
        /// </summary>
        public string ProfileKey { get; set; }

        /// <summary>
        /// Index of the page to display
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// Size for the paging to apply
        /// </summary>
        public string PageSize { get; set; }
       
        /// <summary>
        /// If specified, return only projects whose name match the query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Depending on the value, show only selected items (selected=selected), deselected items (selected=deselected), or all items with their selection status (selected=all)
        /// </summary>
        public string Selected { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            SonarHelpers.AppendUrl(result, "key", ProfileKey);
            SonarHelpers.AppendUrl(result, "page", Page);
            SonarHelpers.AppendUrl(result, "pageSize", PageSize);
            SonarHelpers.AppendUrl(result, "query", Query);
            SonarHelpers.AppendUrl(result, "selected", Selected);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}
