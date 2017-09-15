using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Components
{
    public class Components : BaseObjectApi<Components>
    {
        public ComponentShowResponse Show(SonarComponentShowArgs SonarComponentShowArgs, IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/components/show{1}", SonarApiClient.BaseAddress, (SonarComponentShowArgs == null) ? String.Empty : SonarComponentShowArgs.ToString());
            return SonarApiClient.QueryObject<ComponentShowResponse>(url, configuration);
        }

        public ComponentShowResponse Show(SonarComponentShowArgs SonarComponentShowArgs, NameValueCollection configuration)
        {
            string url = string.Format("{0}api/components/show{1}", SonarApiClient.BaseAddress, (SonarComponentShowArgs == null) ? String.Empty : SonarComponentShowArgs.ToString());
            return SonarApiClient.QueryObject<ComponentShowResponse>(url, configuration);
        }
    }
}
