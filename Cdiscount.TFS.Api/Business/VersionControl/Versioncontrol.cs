using Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Parameters;
using Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Response;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Parameters;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Response;
using Cdiscount.TFS.Api.VersionControl.Changesets.Parameters;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Parameters;
using Cdiscount.TFS.Api.VersionControl.Changesets.Response;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace Cdiscount.TFS.Api.Business.VersionControl
{
    public class Versioncontrol : BaseObjectApi<Versioncontrol>
    {
        public TfsVersionControlChangesetsResponse Changesets(TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}tfvc/changesets{1}", TfsApiClient.BaseAddress, (TfsVensionControlChangesetsArgs == null) ? String.Empty : TfsVensionControlChangesetsArgs.ToString());
            return TfsApiClient.QueryObject<TfsVersionControlChangesetsResponse>(url, configuration);
        }


        public TfsVersioncontrolChangesetsChangesReponse ChangesetChanges(TfsVersioncontrolChangesetsChangesArgs TfsVersioncontrolChangesetsChangesArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}tfvc/changesets/{1}/changes{2}", configuration["TfsApiUriChanges"] , TfsVersioncontrolChangesetsChangesArgs.id, (TfsVersioncontrolChangesetsChangesArgs == null) ? String.Empty : TfsVersioncontrolChangesetsChangesArgs.ToString());
            return TfsApiClient.QueryObject<TfsVersioncontrolChangesetsChangesReponse>(url, configuration);
        }


        public TfsVersionControlShelvesetsResponse Shelvesets(TfsVersionControlShelvesetsArgs TfsVersionControlShelvesetsArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}tfvc/shelvesets/{1};", configuration["TfsApiUriChanges"], TfsVersionControlShelvesetsArgs.shelveset, (TfsVersionControlShelvesetsArgs == null) ? String.Empty : TfsVersionControlShelvesetsArgs.ToString());
            return TfsApiClient.QueryObject<TfsVersionControlShelvesetsResponse>(url, configuration);
        }


        public TfsVersioncontrolShelvesetsChangesReponse ShelvesetsChanges(TfsVersionControlShelvesetsChangesArgs TfsVersionControlShelvesetsChangesArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}tfvc/shelvesets/{1};{2}/changes{3}", configuration["TfsApiUriChanges"], TfsVersionControlShelvesetsChangesArgs.Name, TfsVersionControlShelvesetsChangesArgs.Owner, (TfsVersionControlShelvesetsChangesArgs == null) ? String.Empty : TfsVersionControlShelvesetsChangesArgs.ToString());
            return TfsApiClient.QueryObject<TfsVersioncontrolShelvesetsChangesReponse>(url, configuration);
        }

    }
}
