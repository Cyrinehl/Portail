using Cdiscount.TFS.Api.wit.Queries.Parameters;
using Cdiscount.TFS.Api.wit.Queries.Response;
using Cdiscount.TFS.Api.wit.wiql.Parameters;
using Cdiscount.TFS.Api.wit.wiql.Response;
using Cdiscount.TFS.Api.wit.workItems.Parameters;
using Cdiscount.TFS.Api.wit.workItems.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cdiscount.TFS.Api.Business.Wit
{
    public class Wit : BaseObjectApi<Wit>
    {
        public TfsWitQueriesResponse Queries(TfsWitQueriesArgs TfsWitQueriesArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}wit/queries/{1}{2}", TfsApiClient.BaseAddress, configuration["PathToQuery"], (TfsWitQueriesArgs == null) ? String.Empty : TfsWitQueriesArgs.ToString());
            return TfsApiClient.QueryObject<TfsWitQueriesResponse>(url, configuration);
        }

        public TfsWitWiqlResponse Wiql(TfsWitWiqlArgs TfsWitWiqlArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}wit/wiql/{1}{2}", TfsApiClient.BaseAddress, TfsWitWiqlArgs.queryId , (TfsWitWiqlArgs == null) ? String.Empty : TfsWitWiqlArgs.ToString());
            return TfsApiClient.QueryObject<TfsWitWiqlResponse>(url, configuration);
        }

        public TfsWitWorkitemsResponse workItems(TfsWitWorkitemsArgs TfsWitWorkitemsArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}wit/workItems/{1}", configuration["TfsApiUriChanges"], TfsWitWorkitemsArgs.queryId, (TfsWitWorkitemsArgs == null) ? String.Empty : TfsWitWorkitemsArgs.ToString());
            return TfsApiClient.QueryObject<TfsWitWorkitemsResponse>(url, configuration);
        }


    }
}
