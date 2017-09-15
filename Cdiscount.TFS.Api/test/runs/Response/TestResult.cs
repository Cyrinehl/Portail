using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.test.runs.Response
{
    public class TestResult
    {


        [JsonProperty(PropertyName = "totalTests")]
        public string Totaltests { get; set; }

        [JsonProperty(PropertyName = "incompleteTests")]
        public string IncompleteTests { get; set; }

        [JsonProperty(PropertyName = "notApplicableTests")]
        public string NotApplicableTests { get; set; }


        [JsonProperty(PropertyName = "passedTests")]
        public string PassedTests { get; set; }

        [JsonProperty(PropertyName = "unanalyzedTests")]
        public string UnanalyzedTests { get; set; }

        
    }
}
