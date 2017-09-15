using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response
{
    public class SonarTextRange
    {
        /// <summary>
        /// startLine of the issue
        /// </summary>
        [JsonProperty(PropertyName = "startLine")]
        public int StartLine { get; set; }

        /// <summary>
        /// endLine of the issue
        /// </summary>
        [JsonProperty(PropertyName = "endLine")]
        public int EndLine { get; set; }

        /// <summary>
        /// startOffset of the issue
        /// </summary>
        [JsonProperty(PropertyName = "startOffset")]
        public int StartOffset { get; set; }

        /// <summary>
        /// endOffset of the issue
        /// </summary>
        [JsonProperty(PropertyName = "endOffset")]
        public int EndOffset { get; set; }
    }
}