using Cdiscount.TFS.Api;
using Cdiscount.TFS.Api.Build.Builds.Parameters;
using Cdiscount.TFS.Api.Build.Builds.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cdiscount.TFS.Api.Business.Build
{
    public class Builds : BaseObjectApi<Builds>
    {
        public TfsBuildDefinitionsResponse Definitions(TfsBuildDefinitionsArgs TfsBuildDefinitionsArgs, IConfigurationRoot configuration )
        {
            string url = string.Format("{0}build/definitions{1}", TfsApiClient.BaseAddress, (TfsBuildDefinitionsArgs == null) ? String.Empty : TfsBuildDefinitionsArgs.ToString());
            return TfsApiClient.QueryObject<TfsBuildDefinitionsResponse>(url, configuration);
        }


        public TfsBuildBuildsResponse builds(TfsBuildBuildsArgs TfsBuildBuildsArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}build/builds{1}", TfsApiClient.BaseAddress, (TfsBuildBuildsArgs == null) ? String.Empty : TfsBuildBuildsArgs.ToString());
            return TfsApiClient.QueryObject<TfsBuildBuildsResponse>(url, configuration);
        }
    }
}
