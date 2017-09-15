using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api
{


    public enum Type { build, xaml }
    public class TfsBuildDefinitionsArgs
    {

        public string apiVersion { get; set; }
        public List<Type> type { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            TfsHelpers.AppendUrl(result, "api-version", apiVersion);
            TfsHelpers.AppendUrl(result, "type", type);

            return result.Length > 0 ? "?" + result : string.Empty;
        }

    }
}
