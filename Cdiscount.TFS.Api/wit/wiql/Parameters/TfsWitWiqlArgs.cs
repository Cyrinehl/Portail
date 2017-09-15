using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.wiql.Parameters
{
    public class TfsWitWiqlArgs
    {

        public string apiVersion { get; set; }
        public string queryId { get; set; }



        public override string ToString()
        {
            var result = new StringBuilder();

            TfsHelpers.AppendUrl(result, "api-version", apiVersion);

            return result.Length > 0 ? "?" + result : string.Empty;


        }
    }
}
