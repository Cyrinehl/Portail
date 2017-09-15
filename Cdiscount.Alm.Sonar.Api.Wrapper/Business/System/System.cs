using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.System.Response;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.System
{
    public class System : BaseObjectApi<System>
    {
        /// <summary>
        ///Get the server status:
        ///UP: SonarQube instance is up and running
        ///DOWN: SonarQube instance is up but not running because SQ can not connect to database 
        ///or migration has failed(refer to WS /api/system/migrate_db for details) or some other reason(check logs).
        ///RESTARTING: SonarQube instance is still up but a restart has been requested(refer to WS /api/system/restart for details).
        ///DB_MIGRATION_NEEDED: database migration is required.DB migration can be started using WS /api/system/migrate_db.
        ///DB_MIGRATION_RUNNING: DB migration is running(refer to WS /api/system/migrate_db for details)
        /// </summary>
        /// <returns></returns>
        public SonarSystemStatus Status(IConfigurationRoot configuration)
        {
            string url = string.Format("{0}api/system/status", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarSystemStatus>(url, configuration);
        }
        public SonarSystemStatus Status(NameValueCollection configuration)
        {
            string url = string.Format("{0}api/system/status", SonarApiClient.BaseAddress);
            return SonarApiClient.QueryObject<SonarSystemStatus>(url, configuration);
        }
    }
}