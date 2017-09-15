
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Cdiscount.TFS.Api;
using Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Response;
using Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Parameters;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Response;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Parameters;
using Cdiscount.TFS.Api.VersionControl.Changesets.Parameters;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Parameters;
using Cdiscount.TFS.Api.VersionControl.Changesets.Response;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Response;
using Cdiscount.TFS.Api.getComments.Parameters;
using Cdiscount.TFS.Api.getComments.Response;
using Cdiscount.TFS.Api.Build.Builds.Parameters;
using Cdiscount.TFS.Api.Build.Builds.Response;
using Cdiscount.TFS.Api.test.runs.Parameters;
using Cdiscount.TFS.Api.test.runs.Response;
using Cdiscount.TFS.Api.wit.Queries.Response;
using Cdiscount.TFS.Api.wit.Queries.Parameters;
using Cdiscount.TFS.Api.wit.wiql.Parameters;
using Cdiscount.TFS.Api.wit.wiql.Response;
using Cdiscount.TFS.Api.wit.workItems.Parameters;
using Cdiscount.TFS.Api.wit.workItems.Response;
using DataAccess;
using CommonCore;
using System.Linq;
using Cdiscount.Alm.Sonar.Api.Wrapper;
using Cdiscount.Export;

namespace Test
{
    class Program
    {
       

        static void Main(string[] args)
        {
            IConfigurationRoot configuration = GetConfig();

            InsertIntoDatabase.FillTables(configuration);
            //test.InsertData(configuration);


            //TfsApiClient TfsApiClient = new TfsApiClient(configuration);
            //SonarApiClient SonarClient = new SonarApiClient(configuration);
            //TfsVersionControlShelvesetsArgs TfsVersionControlShelvesetsArgs = new TfsVersionControlShelvesetsArgs();
            //TfsVersionControlShelvesetsArgs.shelveset = "CodeReview_2017-08-29_03.52.55.7900";
            //TfsVersionControlShelvesetsResponse TfsVersionControlShelvesetsResponse = TfsApiClient.VersionControl.Shelvesets(TfsVersionControlShelvesetsArgs, configuration);

            //TfsVersionControlShelvesetsChangesArgs TfsVersionControlShelvesetsChangesArgs = new TfsVersionControlShelvesetsChangesArgs();
            //TfsVersionControlShelvesetsChangesArgs.Name = "CodeReview_2017-08-29_03.42.50.0012";
            //TfsVersionControlShelvesetsChangesArgs.Owner = "jorys.gaillard";
            //TfsVersioncontrolShelvesetsChangesReponse TfsVersioncontrolShelvesetsChangesReponse = TfsApiClient.VersionControl.ShelvesetsChanges(TfsVersionControlShelvesetsChangesArgs, configuration);

            //TreatCodeReview.GenerateExcel(configuration);
          

            // Generate Excel Files
            //TreatExport.GenerateExcelSilo(configuration);
            //TreatExportIssues.TreatIssuesExcel(configuration);

            string fin = "fin";

            // get definitions and their ID for the project CDISCOUNT
            //TfsBuildDefinitionsArgs TfsBuildDefinitionsArgs = new TfsBuildDefinitionsArgs();
            //TfsBuildDefinitionsArgs.apiVersion = "2.0";
            //TfsBuildDefinitionsArgs.type = new List<Cdiscount.TFS.Api.Type>()
            //{
            //    Cdiscount.TFS.Api.Type.xaml,
            //};
            //TfsBuildDefinitionsResponse TfsBuildDefinitionsResponse = TfsApiClient.Builds.Definitions(TfsBuildDefinitionsArgs, configuration);


            // get builds for a definition
            //TfsBuildBuildsArgs TfsBuildBuildsArgs = new TfsBuildBuildsArgs();
            //TfsBuildBuildsArgs.apiVersion = "2.0";
            //TfsBuildBuildsArgs.definitions = new List<string>
            //{
            //   "1333"
            //};
            //TfsBuildBuildsResponse TfsBuildBuildsResponse = TfsApiClient.Builds.builds(TfsBuildBuildsArgs, configuration);


            //// get testResults for a build 
            //TfsTestRunsArgs TfsTestRunsArgs = new TfsTestRunsArgs();
            //TfsTestRunsArgs.apiVersion = "2.0";
            //TfsTestRunsArgs.BuildId = "1389639";
            //TfsTestRunsResponse TfsTestRunsResponse = TfsApiClient.Test.Runs(TfsTestRunsArgs, configuration);


            //// get Changesets by a user AND/OR by date range
            //TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgs = new TfsVensionControlChangesetsArgs();
            //TfsVensionControlChangesetsArgs.apiVersion = "2.0";
            ////TfsVensionControlChangesetsArgs.searchCriteriaAuthor = "zouheir.zraidi";

            ////TfsVensionControlChangesetsArgs.searchCriteriaFromDate = new DateTime(2017, 01, 01);
            ////TfsVensionControlChangesetsArgs.searchCriteriaToDate = new DateTime(2017, 01, 02);
            //TfsVensionControlChangesetsArgs.top = 100;
            //TfsVensionControlChangesetsArgs.skip = 0;
            //TfsVersionControlChangesetsResponse TfsVersionControlChangesetsResponse = TfsApiClient.VersionControl.Changesets(TfsVensionControlChangesetsArgs, configuration);

            //int count = TfsVersionControlChangesetsResponse.ChangeSets.Count;

            //while (count != 0 && count == 100)
            //{

            //    TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgsTmp = TfsVensionControlChangesetsArgs;
            //    TfsVensionControlChangesetsArgsTmp.top = 100;
            //    TfsVensionControlChangesetsArgsTmp.skip = 100 + TfsVensionControlChangesetsArgsTmp.skip;
            //    TfsVersionControlChangesetsResponse TfsVersionControlChangesetsResponseTmp = TfsApiClient.VersionControl.Changesets(TfsVensionControlChangesetsArgs, configuration);
            //    foreach (Changeset changeset in TfsVersionControlChangesetsResponseTmp.ChangeSets)
            //    {
            //        TfsVersionControlChangesetsResponse.ChangeSets.Add(changeset);
            //    }
            //    count = TfsVersionControlChangesetsResponseTmp.ChangeSets.Count;

            //}


            //// get Changesets by a user AND/OR by date range
            //TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgs = new TfsVensionControlChangesetsArgs();
            //TfsVensionControlChangesetsArgs.apiVersion = "2.0";
            ////TfsVensionControlChangesetsArgs.searchCriteriaAuthor = "zouheir.zraidi";

            //TfsVensionControlChangesetsArgs.searchCriteriaFromDate = new DateTime(2017, 01, 01);
            ////TfsVensionControlChangesetsArgs.searchCriteriaToDate = new DateTime(2017, 08, 02);
            //TfsVensionControlChangesetsArgs.top = 256;
            ////TfsVensionControlChangesetsArgs.skip = 0;
            //TfsVersionControlChangesetsResponse TfsVersionControlChangesetsResponse = TfsApiClient.VersionControl.Changesets(TfsVensionControlChangesetsArgs, configuration);

            //int count = TfsVersionControlChangesetsResponse.ChangeSets.Count;

            //TfsVersionControlChangesetsResponse TfsVersionControlChangesetsResponseTmp = TfsVersionControlChangesetsResponse;

            //while (count != 1 )
            //{

            //    TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgsTmp = TfsVensionControlChangesetsArgs;                
            //    TfsVensionControlChangesetsArgsTmp.searchCriteriatoId = Int32.Parse(TfsVersionControlChangesetsResponseTmp.ChangeSets[count-1].ChangesetId);

            //    TfsVersionControlChangesetsResponseTmp = TfsApiClient.VersionControl.Changesets(TfsVensionControlChangesetsArgsTmp, configuration);

            //    Changeset ToRemove = TfsVersionControlChangesetsResponseTmp.ChangeSets[0];
            //    TfsVersionControlChangesetsResponseTmp.ChangeSets.RemoveAt(0);

            //    foreach (Changeset changeset in TfsVersionControlChangesetsResponseTmp.ChangeSets)
            //    {
            //       TfsVersionControlChangesetsResponse.ChangeSets.Add(changeset);

            //    }


            //    TfsVersionControlChangesetsResponseTmp.ChangeSets.Insert(0,ToRemove);
            //    count = TfsVersionControlChangesetsResponseTmp.ChangeSets.Count;

            //}





            //// get changes for a changeset
            //TfsVersioncontrolChangesetsChangesArgs TfsVersioncontrolChangesetsChangesArgs = new TfsVersioncontrolChangesetsChangesArgs();
            //TfsVersioncontrolChangesetsChangesArgs.apiVersion = "2.0";
            //TfsVersioncontrolChangesetsChangesArgs.id = 607316;
            //TfsVersioncontrolChangesetsChangesArgs.top = 100;
            //TfsVersioncontrolChangesetsChangesArgs.skip = 0;
            //TfsVersioncontrolChangesetsChangesReponse TfsVersioncontrolChangesetsChangesReponse = TfsApiClient.VersionControl.ChangesetChanges(TfsVersioncontrolChangesetsChangesArgs, configuration);

            //int countChanges = TfsVersioncontrolChangesetsChangesReponse.Changes.Count;

            //while (countChanges != 0 && countChanges == 100)
            //{

            //    TfsVersioncontrolChangesetsChangesArgs TfsVersioncontrolChangesetsChangesArgsTmp = TfsVersioncontrolChangesetsChangesArgs;
            //    TfsVersioncontrolChangesetsChangesArgsTmp.top = 100;
            //    TfsVersioncontrolChangesetsChangesArgsTmp.skip = 100 + TfsVersioncontrolChangesetsChangesArgsTmp.skip;
            //    TfsVersioncontrolChangesetsChangesReponse TfsVersioncontrolChangesetsChangesReponseTmp = TfsApiClient.VersionControl.ChangesetChanges(TfsVersioncontrolChangesetsChangesArgsTmp, configuration);
            //    foreach (Change change in TfsVersioncontrolChangesetsChangesReponseTmp.Changes)
            //    {
            //        TfsVersioncontrolChangesetsChangesReponse.Changes.Add(change);
            //    }
            //    countChanges = TfsVersioncontrolChangesetsChangesReponseTmp.Changes.Count;

            //}




            //// get ids and names of queries
            //TfsWitQueriesArgs TfsWitQueriesArgs = new TfsWitQueriesArgs();
            //TfsWitQueriesArgs.Depth = "1";
            //TfsWitQueriesArgs.apiVersion = "2.2";
            //TfsWitQueriesResponse TfsWitQueriesResponse = TfsApiClient.Wit.Queries(TfsWitQueriesArgs, configuration);

            ////get workitemsIDs of the query codeReview
            //Child query = TfsWitQueriesResponse.Children.Find(x => x.Name == configuration["CodeReviewQueryName"]);
            //string QueryId = query.Id;
            //TfsWitWiqlArgs TfsWitWiqlArgs = new TfsWitWiqlArgs();
            //TfsWitWiqlArgs.apiVersion = "2.2";
            //TfsWitWiqlArgs.queryId = QueryId;
            //TfsWitWiqlResponse TfsWitWiqlResponse = TfsApiClient.Wit.Wiql(TfsWitWiqlArgs, configuration);

            //List<CodeReveview> CodeReviews = new List<CodeReveview>();
            ////TfsWitWiqlResponse.WorkItemRelations.RemoveAt(0);

            //foreach (WorkItem WorkItem in TfsWitWiqlResponse.WorkItemRelations)
            //{
            //    if (WorkItem.Source != null  &&  WorkItem.Target!= null)
            //    {
            //        CodeReveview CodeReveviewTmp = CodeReviews.Find(x => x.CodeReviewRequest == Int32.Parse(WorkItem.Source.SourceId) );
            //        if (CodeReveviewTmp != null)
            //        {
            //            CodeReveviewTmp.CodeReviewResponse.Add(Int32.Parse(WorkItem.Target.TargetId));
            //        }
            //        else
            //        {
            //            CodeReveview CodeReveview = new CodeReveview();
            //            CodeReveview.CodeReviewRequest = Int32.Parse(WorkItem.Source.SourceId);
            //            CodeReveview.CodeReviewResponse.Add(Int32.Parse(WorkItem.Target.TargetId));
            //            CodeReviews.Add(CodeReveview);
            //        }

            //    }

            //}

            //foreach (CodeReveview CodeReveview in CodeReviews)
            //{



            //}

            ////get comments of a codereviewrequest
            //TfsGetCommentsArgs TfsGetCommentsArgs = new TfsGetCommentsArgs();
            //TfsGetCommentsArgs.WorkItemId = "1020645";
            //List<TfsGetCommentsResponse> TfsGetCommentsReponse = TfsApiClient.Comments.getComments(TfsGetCommentsArgs, configuration);



            ////get details about a workitem
            //TfsWitWorkitemsArgs TfsWitWorkitemsArgs = new TfsWitWorkitemsArgs();
            //TfsWitWorkitemsArgs.queryId = "672111";
            //TfsWitWorkitemsResponse TfsWitWorkitemsResponse = TfsApiClient.Wit.workItems(TfsWitWorkitemsArgs, configuration);



            //InsertIntoDatabase.FillTablesCodeReview(TfsApiClient,  configuration);
            //InsertIntoDatabase.FillTableComment(TfsApiClient, configuration);
            //InsertIntoDatabase.FillTablechangseset(TfsApiClient, configuration);

            //InsertIntoDatabase.FillTablechangseset(TfsApiClient,  configuration);

            //// get comments of a code review
            //TfsGetCommentsArgs TfsGetCommentsArgs = new TfsGetCommentsArgs();
            //TfsGetCommentsArgs.WorkItemId = "1270744";
            //List<TfsGetCommentsResponse> TfsGetCommentsReponse = TfsApiClient.Comments.getComments(TfsGetCommentsArgs, configuration);


        }



        
        public static IConfigurationRoot GetConfig()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

            return configuration;
        } 

    }


}