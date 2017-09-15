using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Metrics.Parameters
{
    public enum FieldsValues
    {
        name,
        description,
        domain,
        direction,
        qualitative,
        hidden,
        custom,
        decimalScale
    }

    /// <summary>
    /// Arguments to search for metrics
    /// </summary>
    public class SonarMetricsSearchArgs
    {
        public SonarMetricsSearchArgs()
        {
            Fields = new List<FieldsValues>();
        }

        /// <summary>
        /// Comma-separated list of the fields to be returned in response. All the fields are returned by default
        /// </summary>
        public List<FieldsValues> Fields { get; set; }

        /// <summary>
        /// Choose custom metrics following 3 cases: 
        /// true: only custom metrics are returned 
        /// false: only non custom metrics are returned
        /// not specified: all metrics are returned
        /// </summary>
        public bool? IsCustom { get; set; }

        public SonarPagingQuery SonarPagingQuery { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(SonarPagingQuery.ToString());
            SonarHelpers.AppendUrl(result, "f", Fields);
            if (IsCustom.HasValue)
            {
                SonarHelpers.AppendUrl(result, "isCustom", IsCustom.ToString().ToLowerInvariant());
            }

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}