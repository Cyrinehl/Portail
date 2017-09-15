using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters
{
    /// <summary>
    /// Comma-separated list of the optional fields to be returned in response. Action plans are dropped in 5.5, it is not returned in the response.
    /// </summary>
    public enum AdditionalField
    {
        _all,
        comments,
        languages,

        //actionPlans,
        rules,

        transitions,
        actions,
        users,
    }

    public class SonarIssuesSearchArgs
    {
        public SonarIssuesSearchArgs()
        {
            SonarPagingQuery = new SonarPagingQuery();
            AdditionalFields = new List<AdditionalField>();
            Tags = new List<string>();
            Assignees = new List<string>();
            Authors = new List<string>();
            IssuesKeys = new List<string>();
            ProjectKeys = new List<string>();
            ComponentKeys = new List<string>();
            ComponentUuids = new List<string>();
            Severities = new List<SonarSeverity>();
            Rules = new List<string>();

        }

        /// <summary>
        /// Gets or sets the additional fields. Comma-separated list of the optional fields to be returned in response. Action plans are dropped in 5.5, it is not returned in the response.
        /// </summary>
        /// <value>
        /// The additional fields.
        /// </value>
        public List<AdditionalField> AdditionalFields { get; set; }

        /// <summary>
        /// Comma-separated list of coding rule keys. Format is <repository>:<rule>
        /// </summary>
        /// <value>
        /// Key Rules
        /// </value>
        public List<string> Rules { get; set; }

        public List<string> ProjectKeys { get; set; }

        /// <summary>
        /// Gets or sets the assigned. To retrieve assigned or unassigned issues
        /// </summary>
        /// <value>
        /// The assigned.
        /// </value>
        public bool? Assigned { get; set; }


        /// <summary>
        /// Gets or sets the assigned. To retrieve assigned or unassigned issues
        /// </summary>
        /// <value>
        /// The assigned.
        /// </value>
        public bool Resolved { get; set; }

        /// <summary>
        /// Gets or sets the assignees. Comma-separated list of assignee logins. The value '__me__' can be used as a placeholder for user who performs the request
        /// </summary>
        /// <value>
        /// The assignees.
        /// </value>
        public List<string> Assignees { get; set; }

        /// <summary>
        /// authors of the issues searched. Comma-separated list of SCM accounts
        /// </summary>
        public List<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets the component keys. 
        /// To retrieve issues associated to a specific list of components sub-components (comma-separated list of component keys). 
        /// A component can be a view, developer, project, module, directory or file.
        /// </summary>
        /// <value>
        /// The component keys.
        /// </value>
        public List<string> ComponentKeys { get; set; }

        /// <summary>
        /// Gets or sets the component uuids.
        /// To retrieve issues associated to a specific list of components their sub-components (comma-separated list of component UUIDs). 
        /// This parameter is mostly used by the Issues page, please prefer usage of the componentKeys parameter. A component can be a project, module, directory or file.
        /// </summary>
        /// <value>
        /// The component uuids.
        /// </value>
        public List<string> ComponentUuids { get; set; }

        /// <summary>
        /// Gets or sets the created after.To retrieve issues created after the given date (inclusive). Format: date or datetime ISO formats. If this parameter is set, createdSince must not be set
        /// </summary>
        /// <value>
        /// The created after.
        /// </value>
        public DateTime? CreatedAfter { get; set; }

        /// <summary>
        /// Gets or sets the created at. To retrieve issues created in a specific analysis, identified by an ISO-formatted datetime stamp.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the created before. To retrieve issues created before the given date (exclusive). Format: date or datetime ISO formats
        /// </summary>
        /// <value>
        /// The created before.
        /// </value>
        public DateTime? CreatedBefore { get; set; }

        /// <summary>
        /// Coma separated list of issues keys
        /// </summary>
        public List<string> IssuesKeys { get; set; }

        public string Statuses { get; set; }

        public SonarPagingQuery SonarPagingQuery { get; set; }

        public List<string> Tags { get; set; }

        /// <summary>
        /// Comma-separated list of severities
        /// </summary>
        public List<SonarSeverity> Severities { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(SonarPagingQuery.ToString());

            SonarHelpers.AppendUrl(result, "issues", IssuesKeys);
            if (Assigned != null)
            {
                SonarHelpers.AppendUrl(result, "assigned", Assigned.ToString().ToLowerInvariant());
            }
            SonarHelpers.AppendUrl(result, "statuses", Statuses);
            SonarHelpers.AppendUrl(result, "tags", Tags);
            if (CreatedAfter != null)
            {
                SonarHelpers.AppendUrl(result, "createdAfter", WebUtility.UrlEncode(SonarHelpers.FormatDateForSonarIso8601(CreatedAfter.Value)));
                // when scanning for createdAfter, automatically sort by created date
                SonarHelpers.AppendUrl(result, "s", "CREATION_DATE");
                SonarHelpers.AppendUrl(result, "asc", "true");
            }
            if (CreatedAt != null)
            {
                SonarHelpers.AppendUrl(result, "createdAt", WebUtility.UrlEncode(SonarHelpers.FormatDateForSonarIso8601(CreatedAt.Value)));
            }
            if (CreatedBefore != null)
            {
                SonarHelpers.AppendUrl(result, "createdBefore", WebUtility.UrlEncode(SonarHelpers.FormatDateForSonarIso8601(CreatedBefore.Value)));
            }
            SonarHelpers.AppendUrl(result, "additionalFields", AdditionalFields);
            SonarHelpers.AppendUrl(result, "assignees", Assignees);
            SonarHelpers.AppendUrl(result, "authors", Authors);
            SonarHelpers.AppendUrl(result, "componentKeys", ComponentKeys);
            SonarHelpers.AppendUrl(result, "componentUuids", ComponentUuids);
            SonarHelpers.AppendUrl(result, "severities", Severities);
            SonarHelpers.AppendUrl(result, "rules", Rules);
            SonarHelpers.AppendUrl(result, "projectKeys", ProjectKeys);
            SonarHelpers.AppendUrl(result, "resolved", Resolved.ToString().ToLowerInvariant());

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}