using Cdiscount.TFS.Api.test.runs.Parameters;
using Cdiscount.TFS.Api.test.runs.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cdiscount.TFS.Api.Business.Test
{
    public class Test : BaseObjectApi<Test>
    {
        public TfsTestRunsResponse Runs(TfsTestRunsArgs TfsTestRunsArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}test/runs{1}", TfsApiClient.BaseAddress, (TfsTestRunsArgs == null) ? String.Empty : TfsTestRunsArgs.ToString());
            return TfsApiClient.QueryObject<TfsTestRunsResponse>(url, configuration);
        }


    }
}
