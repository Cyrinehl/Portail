using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Comments.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Business.Issues.Comments
{
    /// <summary>
    /// Manage the comments of an issue 
    /// </summary>
    public class Comments : BaseObjectApi<Comments>
    {
        /// <summary>
        /// add comment on issue
        /// </summary>
        /// <param name="commentAddArgs"></param>
        public void Add(CommentAddArgs commentAddArgs)
        {
            string url = String.Format("{0}api/issues/add_comment", this.SonarApiClient.BaseAddress);
            //SonarApiClient.Post(url, commentAddArgs.ToString());
        }
    }
}