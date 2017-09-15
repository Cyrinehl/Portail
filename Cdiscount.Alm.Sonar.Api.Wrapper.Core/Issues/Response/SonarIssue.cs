using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Comment.Response;
using Cdiscount.Alm.SonarQube.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response
{
    /// <summary>
    /// Represents a Sonar issue
    /// </summary>
    public class SonarIssue : ISonarObject
    {
        #region Sonar Properties

        /// <summary>
        /// Key of the issue
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Rule at the origin of the issue
        /// </summary>
        [JsonProperty(PropertyName = "rule")]
        public string RuleKey { get; set; }

        /// <summary>
        /// Severity of the issue
        /// </summary>
        [JsonProperty(PropertyName = "severity")]
        public string Severity { get; set; }

        /// <summary>
        /// Component that relates to the issue
        /// </summary>
        [JsonProperty(PropertyName = "component")]
        public string Component { get; set; }

        /// <summary>
        /// Component Id that relates to the issue
        /// </summary>
        [JsonProperty(PropertyName = "componentId")]
        public int ComponentId { get; set; }

        /// <summary>
        /// Project that relates to the issue
        /// </summary>
        [JsonProperty(PropertyName = "project")]
        public string ProjectKey { get; set; }

        /// <summary>
        /// subProject that relates to the issue
        /// </summary>
        [JsonProperty(PropertyName = "subProject")]
        public string SubProject { get; set; }

        /// <summary>
        /// Line number in the source code
        /// </summary>
        [JsonProperty(PropertyName = "line")]
        public string Line { get; set; }

        /// <summary>
        /// The comments of the issue
        /// </summary>
        [JsonProperty(PropertyName = "textRange")]
        public SonarTextRange TextRange { get; set; }

        /// <summary>
        /// Status of the issue
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Message content of the issue
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Effort content of the issue
        /// </summary>
        [JsonProperty(PropertyName = "effort")]
        public string Effort { get; set; }

        /// <summary>
        /// Debt content of the issue
        /// </summary>
        [JsonProperty(PropertyName = "debt")]
        public string Debt { get; set; }

        /// <summary>
        /// Assignee of the issue
        /// </summary>
        [JsonProperty(PropertyName = "assignee")]
        public string Assignee { get; set; }

        /// <summary>
        /// Author of the issue
        /// </summary>
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        /// <summary>
        /// tags
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// The comments of the issue
        /// </summary>
        [JsonProperty(PropertyName = "comments")]
        public SonarComment[] Comments { get; set; }

        /// <summary>
        /// Date of creation
        /// </summary>
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Last update date
        /// </summary>
        [JsonProperty(PropertyName = "updateDate")]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// type of the issue
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        #endregion Sonar Properties

        #region addtional properties

        /// <summary>
        /// Non sonar field used internally to indicate wether the issue is considered as a
        /// technical debt issue (different from regular issues which represent regressions)
        /// Technical debt issues are issues "planned" in a Sonar Action Plan named "Technical
        /// Debt". There is one such plan in each project.
        /// </summary>
        public bool IsTechnicalDebt => Tags != null && Tags.Contains(Constants.TechnicalDebtTag);

        #endregion addtional properties
    }
}