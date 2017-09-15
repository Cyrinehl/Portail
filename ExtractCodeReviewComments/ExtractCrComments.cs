using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Discussion.Client;
using Microsoft.Extensions.Configuration;

namespace ExtractCodeReviewComments
{
    public static class ExtractCrComments
    {



        public static List<CodeReviewComment> CountComments(int workItemid, IConfigurationRoot configuration)
        {
            Uri uri = new Uri(configuration["TfsApiUriTFS"]);
            TeamFoundationDiscussionService service = new TeamFoundationDiscussionService();
            service.Initialize(new Microsoft.TeamFoundation.Client.TfsTeamProjectCollection(uri));
            IDiscussionManager discussionManager = service.CreateDiscussionManager();



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
