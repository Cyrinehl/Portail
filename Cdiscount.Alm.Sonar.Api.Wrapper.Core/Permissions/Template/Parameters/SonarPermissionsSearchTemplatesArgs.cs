using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Permissions.Template.Parameters
{
    /// <summary>
    /// Arguments to list permission templates
    /// </summary>
    public class SonarPermissionsSearchTemplatesArgs
    {
        /// <summary>
        /// Limit search to permission template names that contain the supplied string
        /// </summary>
        public string Q { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            SonarHelpers.AppendUrl(result, "q", Q);
            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}