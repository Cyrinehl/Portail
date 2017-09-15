using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core
{
    public static class SonarHelpers
    {
        public static string FormatDateForSonarIso8601(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss") + date.ToString("zzz").Replace(":", string.Empty);
        }

        /// <summary>
        /// format the parameter for the url
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="parameterName">the parameter name</param>
        /// <param name="parameterValue">the parameter value</param>
        public static void AppendUrl(StringBuilder url, string parameterName, string parameterValue)
        {
            if (!string.IsNullOrEmpty(parameterValue))
            {
                if (url.Length > 0)
                {
                    url.Append("&");
                }
                url.Append(parameterName);
                url.Append("=");
                url.Append(parameterValue);
            }
        }

        /// <summary>
        /// format the parameter for the url
        /// </summary>
        /// <param name="url">the url</param>
        /// <param name="parameterName">the parameter name</param>
        /// <param name="parameterValues">the parameter values</param>
        /// <param name="separator">separator values (default is comma)</param>
        public static void AppendUrl<T>(StringBuilder url, string parameterName, List<T> parameterValues, string separator)
        {
            if (parameterValues.Any())
            {
                if (url.Length > 0)
                {
                    url.Append("&");
                }
                url.Append(parameterName);
                url.Append("=");
                foreach (var parameterValue in parameterValues)
                {
                    url.Append(parameterValue.ToString());
                    url.Append(separator);
                }
            }
        }

        public static void AppendUrl<T>(StringBuilder url, string parameterName, List<T> parameterValues)
        {
            AppendUrl<T>(url, parameterName, parameterValues, ",");
        }
    }
}