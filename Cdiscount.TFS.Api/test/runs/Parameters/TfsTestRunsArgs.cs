using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.test.runs.Parameters
{
    public class TfsTestRunsArgs
    {
        public string apiVersion { get; set; }
        public string BuildId { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            TfsHelpers.AppendUrl(result, "api-version", apiVersion);
            TfsHelpers.AppendUrl(result, "buildUri", "vstfs:///Build/Build/" + BuildId);

            return result.Length > 0 ? "?" + result : string.Empty;
        }

    }
}
