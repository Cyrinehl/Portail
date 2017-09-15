using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.wiql.Response
{
    public class TfsWitWiqlResponse
    {

        [JsonProperty(PropertyName = "workItemRelations")]
        public List<WorkItem> WorkItemRelations { get; set; }

        




    }
}
