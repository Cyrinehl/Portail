using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Parameters
{
    /// <summary>
    /// Arguments to get the list of users
    /// </summary>
    public class SonarUsersSearchArgs
    {
        public SonarUsersSearchArgs()
        {
            SonarPagingQuery = new SonarPagingQuery();
        }

        public SonarPagingQuery SonarPagingQuery { get; set; }

        /// <summary>
        /// Filter on login or name.
        /// </summary>
        public string Q { get; set; }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            if (SonarPagingQuery != null)
            {
                result.Append(SonarPagingQuery.ToString());
            }
            SonarHelpers.AppendUrl(result, "q", Q);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}