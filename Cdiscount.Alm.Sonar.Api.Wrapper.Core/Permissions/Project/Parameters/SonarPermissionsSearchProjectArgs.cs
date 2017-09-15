using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Project.Parameters
{
    public enum QualifierValues
    {
        TRK
    }

    /// <summary>
    /// Arguments to list project permissions
    /// </summary>
    public class SonarPermissionsSearchProjectArgs
    {
        /// <summary>
        /// Pagination
        /// </summary>
        public SonarPagingQuery SonarPagingQuery { get; set; }

        /// <summary>
        /// Project id
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Project key
        /// </summary>
        public string ProjectKey { get; set; }

        /// <summary>
        /// Limit search to:
        /// project names that contain the supplied string
        /// project keys that are exactly the same as the supplied string
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// Project qualifier. Filter the results with the specified qualifier
        /// </summary>
        public QualifierValues? Qualifier { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            if (SonarPagingQuery != null)
            {
                result.Append(SonarPagingQuery.ToString());
            }
            SonarHelpers.AppendUrl(result, "projectId", ProjectId);
            SonarHelpers.AppendUrl(result, "projectKey", ProjectKey);
            SonarHelpers.AppendUrl(result, "q", Q);
            if (Qualifier != null)
            {
                SonarHelpers.AppendUrl(result, "qualifier", Qualifier.ToString());
            }

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}