using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.TeamFoundation.Discussion.Client;
using Microsoft.TeamFoundation;

namespace TESTTEST
{
    public class Class1
    {

        public static List<CodeReviewComment> CountComments(int workItemid, IDiscussionManager discussionManager)
        {
            IAsyncResult result = discussionManager.BeginQueryByCodeReviewRequest(workItemid, QueryStoreOptions.ServerAndLocal, new AsyncCallback(CallCompletedCallback), null);
            var output = discussionManager.EndQueryByCodeReviewRequest(result);

            List<CodeReviewComment> comments = new List<CodeReviewComment>();

            foreach (DiscussionThread thread in output)
            {

                if (thread.ItemPath != "")
                {
                    CodeReviewComment comment = new CodeReviewComment();
                    comment.Author = thread.RootComment.Author.DisplayName;
                    comment.AuthorUniqueName = thread.RootComment.Author.UniqueName;
                    comment.Comment = thread.RootComment.Content;
                    comment.PublishDate = thread.RootComment.PublishedDate.ToShortDateString();
                    comment.ItemName = thread.ItemPath;
                    comments.Add(comment);
                }


            }

            return comments;

        }


        static void CallCompletedCallback(IAsyncResult result)
        {
            // Handle error conditions here
        }


    }
}
