using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.test.runs.Response
{
    public class TfsTestRunsResponse
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "value")]
        public List<TestResult> TestResult { get; set; }

    }
}
