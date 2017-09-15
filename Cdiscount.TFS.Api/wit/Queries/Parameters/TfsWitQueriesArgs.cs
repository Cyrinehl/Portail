using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.Queries.Parameters
{
    public class TfsWitQueriesArgs
    {

        public string apiVersion { get; set; }
        public string Depth { get; set; }
        public string FolderPath { get; set; }        
       


        public override string ToString()
        {
            var result = new StringBuilder();

            TfsHelpers.AppendUrl(result, "api-version", apiVersion);
            TfsHelpers.AppendUrl(result, "folderPath", FolderPath);
            TfsHelpers.AppendUrl(result, "$depth", Depth);


            return result.Length > 0 ? "?" + result : string.Empty;
        }


    }
}
