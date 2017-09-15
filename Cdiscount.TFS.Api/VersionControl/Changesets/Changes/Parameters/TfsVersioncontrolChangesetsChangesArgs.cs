using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Parameters
{
    public class TfsVersioncontrolChangesetsChangesArgs
    {
        public string apiVersion { get; set; }
        public int id { get; set; }
        public int top { get; set; }
        public int skip { get; set; }



        public override string ToString()
        {
            var result = new StringBuilder();

            TfsHelpers.AppendUrl(result, "api-version", apiVersion);          
            TfsHelpers.AppendUrl(result, "$top", top.ToString());
            TfsHelpers.AppendUrl(result, "$skip", skip.ToString());

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}
