using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.TFS.Api.getComments.Response
{
    public class TfsGetCommentsResponse
    {
        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "AuthorUniqueName")]
        public string AuthorUniqueName { get; set; }


        [JsonProperty(PropertyName = "Comment")]
        public string comment { get; set; }

        [JsonProperty(PropertyName = "ItemName")]
        public string ItemName { get; set; }

        [JsonProperty(PropertyName = "PublishDate")]
        public string PublishDate { get; set; }

        [JsonProperty(PropertyName = "ReplyComments")]
        public List<TfsGetCommentsResponse> ReplyComments { get; set; }

    }
}
