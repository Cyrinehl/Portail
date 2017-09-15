using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.TeamFoundation.Discussion.Client;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Threading;

namespace ExposeExtractComment
{
   

        public class CountCommentsService : ICountCommentsService
        {
        public List<CodeReviewComment> CountComments(string workItemid)
        {
           
            Uri uri = new Uri("http://tfs.cdbdx.biz:8080/tfs/DefaultCollection/");
            TeamFoundationDiscussionService service = new TeamFoundationDiscussionService();
            service.Initialize(new Microsoft.TeamFoundation.Client.TfsTeamProjectCollection(uri));
            IDiscussionManager discussionManager = service.CreateDiscussionManager();



            IAsyncResult result = discussionManager.BeginQueryByCodeReviewRequest(int.Parse(workItemid), QueryStoreOptions.ServerAndLocal, new AsyncCallback(CallCompletedCallback), null);
            result.AsyncWaitHandle.WaitOne();
            var output = discussionManager.EndQueryByCodeReviewRequest(result);

            List<CodeReviewComment> comments = new List<CodeReviewComment>();

            foreach (DiscussionThread thread in output)
            {

                if (thread.ItemPath != "")
                {
                    CodeReviewComment comment = new CodeReviewComment();
                    comment.Author = thread.RootComment.Author.DisplayName;
                    comment.AuthorUniqueName = thread.RootComment.Author.UniqueName;
                    


                    comment.ReplyComments = new List<CodeReviewComment>();
                    foreach (Comment childCom in thread.RootComment.GetChildComments())
                    {
                       
                        CodeReviewComment tmp = new CodeReviewComment();
                        tmp.Author = childCom.Author.DisplayName;
                        tmp.AuthorUniqueName = childCom.Author.UniqueName;
                        tmp.Comment = childCom.Content;
                        tmp.PublishDate = childCom.PublishedDate.ToString("MMMM dd, yyyy hh:mm:ss");
                        //tmp.PublishDate =  String.Format("{0:d/M/yyyy HH:mm:ss}", childCom.PublishedDate);                        
                        comment.ReplyComments.Add(tmp);
                    }

                    comment.Comment = thread.RootComment.Content;
                    comment.PublishDate = thread.RootComment.PublishedDate.ToString("MMMM dd, yyyy hh:mm:ss");
                    //comment.PublishDate = String.Format("{0:d/M/yyyy HH:mm:ss}", thread.RootComment.PublishedDate); 
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
       
        





        [ServiceContract(Namespace = "www.Cdiscount.com")]
        public interface ICountCommentsService
            {
                [OperationContract]
            [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
                       Method = "GET",
                       UriTemplate = "GetComments/{workItemid}",
                       ResponseFormat = WebMessageFormat.Json)]
            List<CodeReviewComment> CountComments(string workItemid);
        }


        [DataContract]
        public class CodeReviewComment
        {

            
            [DataMember]
            public string Author { get; set; }
            [DataMember]
            public string AuthorUniqueName { get; set; }
            [DataMember]
            public string Comment { get; set; }
            [DataMember]
            public string PublishDate { get; set; }

            [DataMember]
            public string ItemName { get; set; }

            [DataMember]
            public List<CodeReviewComment> ReplyComments { get; set; }


        }



}
