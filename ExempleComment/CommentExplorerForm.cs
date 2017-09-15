using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Discussion.Client;



namespace CommentExplorer
{
    public partial class CommentExplorerForm : Form
    {
        const string TfsUri = "http://tfs.cdbdx.biz:8080/tfs/DefaultCollection";

        public CommentExplorerForm()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {            
            Uri uri = new Uri(TfsUri);

            TeamFoundationDiscussionService service = new TeamFoundationDiscussionService();
            service.Initialize(new TfsTeamProjectCollection(uri));

            TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            WorkItemStore store = projectCollection.GetService<WorkItemStore>();

            WorkItemLinkInfo[] list = GetCodeReviewRequests(store);

            IDiscussionManager discussionManager = service.CreateDiscussionManager();

            List<ResponseAnalysis> responseList = new List<ResponseAnalysis>();

            List<WorkItemLinkInfo> filteredList = list.Where(p => p.SourceId != 0).ToList();

            foreach (WorkItemLinkInfo item in filteredList)
            {
                ResponseAnalysis response = new ResponseAnalysis();

                WorkItem Widemand = store.GetWorkItem(item.SourceId);
                WorkItem WiResponse = store.GetWorkItem(item.TargetId);

                string reviewer = WiResponse.Fields["Accepted By"].Value.ToString();

                string date = Widemand.Fields["Created Date"].Value.ToString();

                response.WorkiTemId = Widemand.Id;
                response.CommentNumber = CountComments(Widemand.Id, discussionManager, NormalizeName(reviewer));
                response.OwnerName = Widemand.CreatedBy;
                response.CodeReviewStatus = WiResponse.Fields["Closed Status"].Value.ToString();
                response.Direction = GetDirection(Widemand.CreatedBy);
                response.ReviewerName = reviewer;
                response.Team = GetTeam(Widemand.CreatedBy);
               
                //WorkItemType type = item.Links.WorkItem.Type;

                responseList.Add(response);
            }

            int nbConcernedLines = 0;
        }

        private string GetTeam(string createdBy)
        {
            return ("");
        }

        private string GetDirection(string createdBy)
        {
            return ("");
        }

        private string NormalizeName(string createdBy)
        {
            int splitIndex = createdBy.IndexOf("<CDBDX");

            string result = createdBy;

            if (splitIndex > 0)
            {
                result = createdBy.Substring(0, splitIndex - 1);
            }

            return result;
        }

        static void CallCompletedCallback(IAsyncResult result)
        {
            // Handle error conditions here
        }

        private WorkItemLinkInfo[] GetCodeReviewRequests(WorkItemStore store)
        {
            QueryDefinition query2 = store.GetQueryDefinition(new Guid("3ff1f0be-1fcf-43ee-9206-9371793f503d"));

            Query executeQuery = new Query(store, query2.QueryText);

            WorkItemLinkInfo[] result =  executeQuery.RunLinkQuery();

            return result;
        }

        private void ShowCodeReviewInitiators(List<WorkItem> codeReviewRequest)
        {
            var creators = codeReviewRequest.Select(r => r.CreatedBy).GroupBy(r => r);
            var reviewCounts = new Dictionary<string, int>();

            foreach (var creatorGroup in creators)
                reviewCounts[creatorGroup.Key] = creatorGroup.Count();

            reviewCounts.OrderByDescending(x => x.Value);
        }

        private int CountComments(int workItemid, IDiscussionManager discussionManager, string reviewer)
        {
            IAsyncResult result = discussionManager.BeginQueryByCodeReviewRequest(workItemid, QueryStoreOptions.ServerAndLocal, new AsyncCallback(CallCompletedCallback), null);
            var output = discussionManager.EndQueryByCodeReviewRequest(result);

            List<CodeReviewComment> comments = new List<CodeReviewComment>();

            foreach (DiscussionThread thread in output)
            {
                if ((thread.RootComment != null) && (Equals(thread.RootComment.Author.DisplayName, reviewer)))
                {
                    CodeReviewComment comment = new CodeReviewComment();
                    comment.Author = thread.RootComment.Author.DisplayName;
                    comment.Comment = thread.RootComment.Content;
                    comment.PublishDate = thread.RootComment.PublishedDate.ToShortDateString();
                    comment.ItemName = thread.ItemPath;
                    comments.Add(comment);
                }
            }

            int nbComment = comments.Count;

            return (nbComment);

        }
    }
}
