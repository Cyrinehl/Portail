using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Parameters
{
    public enum FieldsValues
    {
        name,
        description,
        membersCount
    }

    /// <summary>
    /// Arguments to get the list of groups
    /// </summary>
    public class SonarUserGroupsSearchArgs
    {
        public SonarUserGroupsSearchArgs()
        {
            SonarPagingQuery = new SonarPagingQuery();
            Fields = new List<FieldsValues>();
        }

        /// <summary>
        /// List of the fields to be returned in response. All the fields are returned by default
        /// </summary>
        public List<FieldsValues> Fields { get; set; }

        public SonarPagingQuery SonarPagingQuery { get; set; }

        /// <summary>
        /// Limit search to names that contain the supplied string.
        /// </summary>
        public string Q { get; set; }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            SonarHelpers.AppendUrl(result, "f", Fields);
            if (SonarPagingQuery != null)
            {
                result.Append(SonarPagingQuery.ToString());
            }
            SonarHelpers.AppendUrl(result, "q", Q);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}