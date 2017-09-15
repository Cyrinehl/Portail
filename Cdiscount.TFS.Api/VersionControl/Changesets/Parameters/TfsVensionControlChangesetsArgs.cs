using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Cdiscount.TFS.Api.VersionControl.Changesets.Parameters
{
    public class TfsVensionControlChangesetsArgs
    {

        public string apiVersion { get; set; }
        public string searchCriteriaAuthor { get; set; }
        public int searchCriteriatoId { get; set; }
        public int searchCriteriafromId { get; set; }
        public DateTime? searchCriteriaFromDate { get; set; }
        public DateTime? searchCriteriaToDate { get; set; }
        public int top { get; set; }
        public int skip { get; set; }


        public override string ToString()
        {
            var result = new StringBuilder();

            TfsHelpers.AppendUrl(result, "api-version", apiVersion);
            TfsHelpers.AppendUrl(result, "searchCriteria.toId", searchCriteriatoId.ToString());
            TfsHelpers.AppendUrl(result, "searchCriteria.fromId", searchCriteriafromId.ToString());

            // if (searchCriteriaAuthor != null)
            //{
            TfsHelpers.AppendUrl(result, "searchCriteria.author", searchCriteriaAuthor);
            //}

            if (searchCriteriaFromDate != null)
            {
                TfsHelpers.AppendUrl(result, "searchCriteria.fromDate", WebUtility.UrlEncode(TfsHelpers.FormatDateForSonarIso8601(searchCriteriaFromDate.Value)));
            }

            if (searchCriteriaToDate != null)
            {
                TfsHelpers.AppendUrl(result, "searchCriteria.toDate", WebUtility.UrlEncode(TfsHelpers.FormatDateForSonarIso8601(searchCriteriaToDate.Value)));
            }
                                           
            TfsHelpers.AppendUrl(result, "$top", top.ToString());
            TfsHelpers.AppendUrl(result, "$skip", skip.ToString());

            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}
