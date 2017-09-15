using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.Build.Builds.Parameters
{
  

    public class TfsBuildBuildsArgs
    {
      
            public string apiVersion { get; set; }
            public List<string> definitions { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
           
            TfsHelpers.AppendUrl(result, "api-version", apiVersion);            
            TfsHelpers.AppendUrl(result, "definitions", definitions);

           
            return result.Length > 0 ? "?" + result : string.Empty;
        }

        

    }
}
