using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.wit.workItems.Response
{
    public class Field
    {
        [JsonProperty(PropertyName = "System.WorkItemType")]
        public string WorkItemType { get; set; }


        [JsonProperty(PropertyName = "System.State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "System.Reason")]
        public string Reason { get; set; }


        [JsonProperty(PropertyName = "System.CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "System.ChangedDate")]
        public DateTime ChangedDate { get; set; }


        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ClosedDate")]
        public DateTime ClosedDate { get; set; }


        [JsonProperty(PropertyName = "System.CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ContextType")]
        public string ContextType { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.Context")]
        public string Context { get; set; }


        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.ClosedStatus")]
        public string MicrosoftVSTSCodeReviewClosedStatus { get; set; }


        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ClosedBy")]
        public string MicrosoftVSTSCommonClosedBy { get; set; }


        [JsonProperty(PropertyName = "Microsoft.VSTS.CodeReview.AcceptedBy")]
        public string MicrosoftVSTSCodeReviewAcceptedBy { get; set; }


        [JsonProperty(PropertyName = "Microsoft.VSTS.Common.ReviewedBy")]
        public string MicrosoftVSTSCommonReviewedBy { get; set; }
        
        [JsonProperty(PropertyName = "System.Title")]
        public string Title { get; set; }



    }
}
