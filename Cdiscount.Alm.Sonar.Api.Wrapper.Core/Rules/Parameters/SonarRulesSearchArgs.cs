using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Rules.Parameters
{
    /// <summary>
    /// Represents arguments to search rules
    /// </summary>
    public class SonarRulesSearchArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SonarRulesSearchArgs()
        {
            SonarPagingQuery = new SonarPagingQuery();
            Languages = new List<string>();
            Repositories = new List<string>();
            Severities = new List<SonarSeverity>();
        }

        /// <summary>
        /// List of languages
        /// </summary>
        public List<string> Languages { get; set; }

        /// <summary>
        /// List of repositories
        /// </summary>
        public List<string> Repositories { get; set; }

        /// <summary>
        /// Comma-separated list of default severities. Not the same than severity of rules in Quality profiles
        /// </summary>
        public List<SonarSeverity> Severities { get; set; }

        /// <summary>
        /// Results paging parameters
        /// </summary>
        public SonarPagingQuery SonarPagingQuery { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(SonarPagingQuery.ToString());

            SonarHelpers.AppendUrl(result, "languages", Languages);
            SonarHelpers.AppendUrl(result, "repositories", Repositories);
            SonarHelpers.AppendUrl(result, "severities", Severities);

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}