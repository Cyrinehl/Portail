using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Parameters
{

    public enum MetricKeys
    {
        coverage,
        ncloc,
        comment_lines_density,
        complexity,     
        bugs,
        vulnerabilities,
        code_smells,
        duplicated_lines_density,
        sqale_rating,
        security_rating,
        reliability_rating
    }

    public class SonarComponentArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SonarComponentArgs()
        {
            MetricKeys = new List<MetricKeys>();
        }
        
        /// <summary>
        /// Comma-separated list of Metric keys
        /// </summary>
        public List<MetricKeys> MetricKeys { get; set; }

        public string ComponentKey { get; set; }

        public string ComponentId { get; set; }

        public string DeveloperId { get; set; }
        public string DeveloperKey { get; set; }


        public override string ToString()
        {
            var result = new StringBuilder();
            
            SonarHelpers.AppendUrl(result, "metricKeys", MetricKeys);
            SonarHelpers.AppendUrl(result, "componentKey", ComponentKey);
            SonarHelpers.AppendUrl(result, "componentId", ComponentId);
            SonarHelpers.AppendUrl(result, "developerId", DeveloperKey);
            SonarHelpers.AppendUrl(result, "developerKey", DeveloperId);
                       
            return result.Length > 0 ? "?" + result : string.Empty;
        }





    }
}
