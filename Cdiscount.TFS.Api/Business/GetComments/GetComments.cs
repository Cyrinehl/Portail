using Cdiscount.TFS.Api.getComments.Parameters;
using Cdiscount.TFS.Api.getComments.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.Business.GetComments
{
    public class GetComments : BaseObjectApi<GetComments>
    {

        public List<TfsGetCommentsResponse> getComments(TfsGetCommentsArgs TfsGetCommentsArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}GetComments/{1}", configuration["UriGetComments"], TfsGetCommentsArgs.WorkItemId);            
            return TfsApiClient.QueryList<TfsGetCommentsResponse>(url, configuration);
        }



    }
}
