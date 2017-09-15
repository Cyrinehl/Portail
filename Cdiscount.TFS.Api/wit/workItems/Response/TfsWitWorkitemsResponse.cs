using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.workItems.Response
{
    public class TfsWitWorkitemsResponse
    {

        [JsonProperty(PropertyName = "fields")]
        public Field Fields { get; set; }


    }
}
