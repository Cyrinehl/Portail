using Cdiscount.Alm.Sonar.Api.Wrapper;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Issues.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Measures.Component.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Projects.Response;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Parameters;
using Cdiscount.Alm.Sonar.Api.Wrapper.Core.QualityProfiles.Projects.Response;
using Cdiscount.TFS.Api;
using Cdiscount.TFS.Api.Build.Builds.Parameters;
using Cdiscount.TFS.Api.Build.Builds.Response;
using Cdiscount.TFS.Api.getComments.Parameters;
using Cdiscount.TFS.Api.getComments.Response;
using Cdiscount.TFS.Api.test.runs.Parameters;
using Cdiscount.TFS.Api.test.runs.Response;
using Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Parameters;
using Cdiscount.TFS.Api.VersionControl.Changesets.Changes.Response;
using Cdiscount.TFS.Api.VersionControl.Changesets.Parameters;
using Cdiscount.TFS.Api.VersionControl.Changesets.Response;
using Cdiscount.TFS.Api.wit.Queries.Parameters;
using Cdiscount.TFS.Api.wit.Queries.Response;
using Cdiscount.TFS.Api.wit.wiql.Parameters;
using Cdiscount.TFS.Api.wit.wiql.Response;
using Cdiscount.TFS.Api.wit.workItems.Parameters;
using Cdiscount.TFS.Api.wit.workItems.Response;
using DataAccess.Insert;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Response;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Changes.Parameters;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Parameters;
using Cdiscount.TFS.Api.VersionControl.Shelvesets.Response;


namespace CommonCore
{
    public class InsertIntoDatabase
    {
        private static List<Serviceinformation> Servicesinformation = new List<Serviceinformation>();
        private static List<service> services = new List<service>();
        private static List<Profile> profiles = new List<Profile>();
        private static List<CodeReview> CodeReviews = new List<CodeReview>();



        // FillServiceInformationServiceMetrics
        public static void FillTables(IConfigurationRoot configuration)
        {
            SonarApiClient SonarClient = new SonarApiClient(configuration);
            TfsApiClient TfsApiClient = new TfsApiClient(configuration);

            FillServicesNamesKeys(configuration, SonarClient, TfsApiClient);
            FillProfiles(configuration, SonarClient);
            FillServicesMetrics(SonarClient, configuration);
            FillServicesProfiles(configuration);
            //FillTablesServiceInformationServiceMetrics(configuration);
            //FillTableServiceBuild(TfsApiClient, configuration);
            //FillTableIssue(SonarClient, configuration);
            FillTablesCodeReview(TfsApiClient, configuration);
            FillTableComment(TfsApiClient, configuration);
            FillTablechangseset(TfsApiClient, configuration);

        }



        // Fill the attributes serviceKey and serviceName of each service of the list services  
        public static void FillServicesNamesKeys(IConfigurationRoot configuration, SonarApiClient SonarClient, TfsApiClient TfsApiClient)
        {


            TfsBuildDefinitionsArgs TfsBuildDefinitionsArgs = new TfsBuildDefinitionsArgs();
            TfsBuildDefinitionsArgs.apiVersion = "2.0";
            TfsBuildDefinitionsArgs.type = new List<Cdiscount.TFS.Api.Type>()
            {
                Cdiscount.TFS.Api.Type.xaml,
            };
            TfsBuildDefinitionsResponse TfsBuildDefinitionsResponse = TfsApiClient.Builds.Definitions(TfsBuildDefinitionsArgs, configuration);

            List<SonarProject> projects = SonarClient.Projects.Index(null, configuration);

            foreach (SonarProject project in projects)
            {
                service service = new service();
                service.serviceKey = project.Key;
                service.serviceName = project.Name;
                Definition definition = TfsBuildDefinitionsResponse.BuildDefinitions.Find(x => x.Name == project.Name);
                if (definition != null)
                {
                    service.serviceTfsKey = definition.Id;
                }

                services.Add(service);

            }

        }


        // Fill for each profile: the attributes ProfileName, profileKey and the attribute serviceName of profileBuilds 
        public static void FillProfiles(IConfigurationRoot configuration, SonarApiClient SonarClient)
        {


            int NumberOfProfiles;
            Int32.TryParse(configuration["NumberProfiles"], out NumberOfProfiles);

            for (int number = 0; number < NumberOfProfiles; number++)
            {
                Profile profile = new Profile();
                SonarProjectsArgs SonarProjectsArgs = new SonarProjectsArgs();

                string ProfileKey = "Profiles:" + number + ":Key";
                string ProfileName = "Profiles:" + number + ":ProfileName";

                profile.profileKey = configuration[ProfileKey];
                profile.ProfileName = configuration[ProfileName];

                SonarProjectsArgs.ProfileKey = configuration[ProfileKey];
                SonarProjectsArgs.PageSize = "400";
                SonarQualityProfileProjects SonarQualityProfileProjects = SonarClient.QualityProfiles.Projects(SonarProjectsArgs, configuration);


                foreach (SonarProjet project in SonarQualityProfileProjects.QualityProfileProjects)
                {
                    service service = new service();
                    service.serviceName = project.Name;
                    profile.profileServices.Add(service);
                }

                profiles.Add(profile);

            }
        }


        // Fill the attributes of metrics of each service of the list builds
        public static void FillServicesMetrics(SonarApiClient SonarClient, IConfigurationRoot configuration)
        {

            SonarComponentArgs SonarComponentArgs = new SonarComponentArgs();
            SonarComponentArgs.MetricKeys = new List<MetricKeys>()  {
                 MetricKeys.bugs,
                 MetricKeys.comment_lines_density,
                 MetricKeys.code_smells,
                 MetricKeys.complexity,
                 MetricKeys.coverage,
                 MetricKeys.duplicated_lines_density,
                 MetricKeys.ncloc,
                 MetricKeys.reliability_rating,
                 MetricKeys.security_rating,
                 MetricKeys.sqale_rating,
                 MetricKeys.vulnerabilities
            };


            foreach (service b in services)
            {
                SonarComponentArgs.ComponentKey = b.serviceKey;
                ComponentMeasureResponse ComponentMeasureResponse = SonarClient.Measures.Component(SonarComponentArgs, configuration);
                List<ComponentMeasure> measures = ComponentMeasureResponse.SonarComponentMeasures.Measures;
                int count = measures.Count;

                for (int i = 0; i < count; i++)
                {
                    string metric = measures[i].Metric;
                    switch (metric)
                    {
                        case "ncloc":
                            b.size = measures[i].Value;
                            break;

                        case "coverage":
                            b.coverage = measures[i].Value.Replace(".", ",");
                            break;

                        case "duplicated_lines_density":
                            b.duplication = measures[i].Value.Replace(".", ",");
                            break;

                        case "complexity":
                            b.complexity = measures[i].Value;
                            break;

                        case "comment_lines_density":
                            b.commentLinesDensity = measures[i].Value.Replace(".", ",");
                            break;
                        case "bugs":
                            b.numberBug = measures[i].Value;
                            break;
                        case "code_smells":
                            b.numberCodeSmells = measures[i].Value;
                            break;

                        case "vulnerabilities":
                            b.numberVulnerabilities = measures[i].Value;
                            break;


                        case "security_rating":
                            b.securityRating = measures[i].Value;
                            break;

                        case "reliability_rating":
                            b.reliabilityRating = measures[i].Value;
                            break;

                        case "sqale_rating":
                            b.sqaleRating = measures[i].Value;
                            break;

                    }

                }

            }


            foreach (service b in services)
            {
                if (b.coverage == null)
                {
                    b.coverage = "0";
                }

            }

        }


        //For each profile: replace each service in profileservices with the correspending object of the list services  
        public static void FillServicesProfiles(IConfigurationRoot configuration)
        {

            int NumberOfProfiles;
            Int32.TryParse(configuration["NumberProfiles"], out NumberOfProfiles);

            for (int number = 0; number < NumberOfProfiles; number++)
            {
                List<service> tmpList = profiles[number].profileServices;
                int countTmpList = tmpList.Count;

                for (int i = 0; i < countTmpList; i++)
                {
                    profiles[number].profileServices[i] = services.Find(x => x.serviceName == profiles[number].profileServices[i].serviceName);
                    profiles[number].profileServices[i].ProfileName = profiles[number].ProfileName;
                }


            }
        }


        //Fill tables serviceinformation and servicemetrics
        public static void FillTablesServiceInformationServiceMetrics(IConfigurationRoot configuration)
        {

            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();

            foreach (Profile profile in profiles)
            {

                foreach (service service in profile.profileServices)
                {
                    try
                    {

                        Serviceinformation Serviceinformation = new Serviceinformation();
                        Servicemetrics Servicemetrics = new Servicemetrics();

                        Serviceinformation.ServiceName = service.serviceName;
                        Serviceinformation.ServiceSonarKey = service.serviceKey;
                        Serviceinformation.ServiceTfsKey = service.serviceTfsKey;
                        DataServiceInformation.InsertData(Serviceinformation, myConnection);

                        Servicemetrics.Complexity = Int32.Parse(service.complexity);
                        Servicemetrics.Coverage = Decimal.Parse(service.coverage);
                        Servicemetrics.Documentation = Decimal.Parse(service.commentLinesDensity);
                        Servicemetrics.Duplication = Decimal.Parse(service.duplication);
                        Servicemetrics.NumberBugs = Int32.Parse(service.numberBug);
                        Servicemetrics.NumberCodeSmells = Int32.Parse(service.numberCodeSmells);
                        Servicemetrics.NumberVulnerabilities = Int32.Parse(service.numberVulnerabilities);
                        Servicemetrics.ServiceProfile = service.ProfileName;
                        Servicemetrics.Size = Int32.Parse(service.size);
                        Servicemetrics.ServiceId = DataServiceInformation.GetServiceInformation(service.serviceName, myConnection);
                        Servicemetrics.InterrogationDate = DateTime.Now;

                        DataServiceMetrics.InsertData(Servicemetrics, myConnection);

                        Thread.Sleep(500);
                    }
                    catch (Exception e)
                    {
                        string error = "Exception Occre while Inserting !!!!!!!" + e.Message + "\t" + e.GetType();
                    }

                }


            }




        }


        //Fill table servicebuild
        public static void FillTableServiceBuild(TfsApiClient TfsApiClient, IConfigurationRoot configuration)
        {

            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();


            TfsBuildBuildsArgs TfsBuildBuildsArgs = new TfsBuildBuildsArgs();
            TfsBuildBuildsArgs.apiVersion = "2.0";

            foreach (Profile profile in profiles)
            {
                foreach (service service in profile.profileServices)
                {
                    if (service.serviceTfsKey != null)
                    {
                        TfsBuildBuildsArgs.definitions = new List<string>
                        {
                            service.serviceTfsKey
                        };

                        TfsBuildBuildsResponse TfsBuildBuildsResponse = TfsApiClient.Builds.builds(TfsBuildBuildsArgs, configuration);

                        foreach (Element Element in TfsBuildBuildsResponse.Elements)
                        {

                            Servicebuild Servicebuild = new Servicebuild();
                            Servicebuild.BuildName = Element.BuildNumber;
                            Servicebuild.Result = Element.Result;
                            Servicebuild.StartTime = Element.startTime;
                            Servicebuild.FinishTime = Element.FinishTime;
                            Servicebuild.ServiceId = DataServiceInformation.GetServiceInformation(Element.Defintion.Name, myConnection);

                            String DevelopperLogin = Element.RequestedFor.UniqueName.Substring(6);
                            Servicebuild.DevelopperId = GetDevelopperIDBuild(DevelopperLogin, Element, configuration, myConnection);


                            if (Servicebuild.BuildName.StartsWith("Sonar_") == true)
                            {

                                TfsTestRunsArgs TfsTestRunsArgs = new TfsTestRunsArgs();
                                TfsTestRunsArgs.apiVersion = "2.0";
                                TfsTestRunsArgs.BuildId = Element.Id;
                                TfsTestRunsResponse TfsTestRunsResponse = TfsApiClient.Test.Runs(TfsTestRunsArgs, configuration);

                                if (TfsTestRunsResponse.TestResult.Count != 0)
                                {
                                    //Fill test attributes of the build
                                    Servicebuild.TotalTests = Int32.Parse(TfsTestRunsResponse.TestResult[0].Totaltests);
                                    Servicebuild.PassedTests = Int32.Parse(TfsTestRunsResponse.TestResult[0].PassedTests);
                                    Servicebuild.IncompleteTests = Int32.Parse(TfsTestRunsResponse.TestResult[0].IncompleteTests);
                                    Servicebuild.NotApplicableTests = Int32.Parse(TfsTestRunsResponse.TestResult[0].NotApplicableTests);
                                    Servicebuild.UnanalyzedTests = Int32.Parse(TfsTestRunsResponse.TestResult[0].UnanalyzedTests);

                                }

                            }

                            DataServicesBuild.InsertData( Servicebuild, myConnection);
                        }
                    }
                }
            }
        }


        //Fill table issue
        public static void FillTableIssue(SonarApiClient SonarApiClient, IConfigurationRoot configuration)
        {
            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();

            // appel à la base pour avoir tous les services => dictionnaire<string,int> 

            foreach (Profile profile in profiles)
            {
                foreach (service service in profile.profileServices)
                {
                    int ServiceID = DataServiceInformation.GetServiceInformation(service.serviceName, myConnection);
                    SonarIssuesSearchArgs SonarIssuesSearch = new SonarIssuesSearchArgs();
                    SonarIssuesSearch.ProjectKeys.Add(service.serviceKey);
                    SonarIssuesSearch SonarIssues = SonarApiClient.Issues.Search(SonarIssuesSearch, configuration);

                    // fill list a issue for each service
                    while (SonarIssues.Issues.Count < SonarIssues.Paging.Total)
                    {
                        SonarIssuesSearch.SonarPagingQuery.PageIndex++;
                        SonarIssuesSearch tmp = SonarApiClient.Issues.Search(SonarIssuesSearch, configuration);
                        foreach (SonarIssue issue in tmp.Issues)
                        {
                            SonarIssues.Issues.Add(issue);
                        }

                    }                    

                    //get existing issue's rules of the service from DB
                    List<DataIssue.IssueRuleType> issuesInDB = DataIssue.GetServiceIssues( ServiceID, myConnection);


                    // update table
                    if (DataIssue.CountRows(myConnection) != 0)
                    {
                        foreach (DataIssue.IssueRuleType IssueRule in issuesInDB)
                        {
                            if (SonarIssues.Issues.Find(x => x.Key == IssueRule.IssueRule && x.Type == IssueRule.IssueType) == null)
                            {
                                SonarIssuesSearchArgs SonarIssuesSearchUpdate = new SonarIssuesSearchArgs();
                                SonarIssuesSearchUpdate.IssuesKeys.Add(IssueRule.IssueRule);
                                SonarIssuesSearchUpdate.Resolved = true;
                                SonarIssuesSearch SonarIssuesUpdate = SonarApiClient.Issues.Search(SonarIssuesSearchUpdate, configuration);

                                DataIssue.UpdateIssue( IssueRule, myConnection, SonarIssuesUpdate.Issues[0].UpdateDate);
                            }
                        }
                    }


                    InsertServiceIssuesIntoDB(ServiceID, myConnection, configuration, SonarIssues, SonarApiClient);
                                     
                    SonarIssuesSearch.ProjectKeys.Clear();

                }

            }
        }


        // Fill table changeset
        public static void FillTablechangseset(TfsApiClient TfsApiClient, IConfigurationRoot configuration)
        {
            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();


            if (DataChangeset.CheckEmpty(myConnection) == 0)
            {
                TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgs = new TfsVensionControlChangesetsArgs();
                TfsVensionControlChangesetsArgs.apiVersion = "2.0";

                TfsVensionControlChangesetsArgs.searchCriteriaFromDate = new DateTime(2017, 01, 01);
                TfsVensionControlChangesetsArgs.top = 256;

                GetAndInsertChangesets(TfsApiClient, TfsVensionControlChangesetsArgs, configuration, myConnection);

            }
            else
            {
                
                TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgs = new TfsVensionControlChangesetsArgs();
                TfsVensionControlChangesetsArgs.apiVersion = "2.0";

                TfsVensionControlChangesetsArgs.top = 256;

                int MaxChangesetID = DataChangeset.GetLatestChangesetId(myConnection);

                if (MaxChangesetID != 0 && MaxChangesetID != -1)
                {
                    TfsVensionControlChangesetsArgs.searchCriteriafromId = MaxChangesetID;
                    GetAndInsertChangesets(TfsApiClient, TfsVensionControlChangesetsArgs, configuration, myConnection);

                }

            }

        }


        // Fill tables Codereviewrequest Codereviewresponse
        public static void FillTablesCodeReview(TfsApiClient TfsApiClient, IConfigurationRoot configuration)
        {

            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();
            DateTime ReferenceDate = new DateTime(2017,09,01);

            // get ids and names of queries
            TfsWitQueriesArgs TfsWitQueriesArgs = new TfsWitQueriesArgs();
            TfsWitQueriesArgs.Depth = "1";
            TfsWitQueriesArgs.apiVersion = "2.2";
            TfsWitQueriesResponse TfsWitQueriesResponse = TfsApiClient.Wit.Queries(TfsWitQueriesArgs, configuration);

            //get workitemsIDs of the query codeReview
            Child query = TfsWitQueriesResponse.Children.Find(x => x.Name == configuration["CodeReviewQueryName"]);
            string QueryId = query.Id;
            TfsWitWiqlArgs TfsWitWiqlArgs = new TfsWitWiqlArgs();
            TfsWitWiqlArgs.apiVersion = "2.2";
            TfsWitWiqlArgs.queryId = QueryId;
            TfsWitWiqlResponse TfsWitWiqlResponse = TfsApiClient.Wit.Wiql(TfsWitWiqlArgs, configuration);


            // Fill the ids of the list CodeReviews
            foreach (WorkItem WorkItem in TfsWitWiqlResponse.WorkItemRelations)
            {
                if (WorkItem.Source != null && WorkItem.Target != null)
                {
                    CodeReview CodeReveviewTmp = CodeReviews.Find(x => x.Codereviewrequest.CodeReviewRequestId == Int32.Parse(WorkItem.Source.SourceId));
                    if (CodeReveviewTmp != null)
                    {
                        Codereviewresponse Codereviewresponse = new Codereviewresponse();
                        Codereviewresponse.CodeReviewRequestId = Int32.Parse(WorkItem.Source.SourceId);
                        Codereviewresponse.CodeReviewResponseId = Int32.Parse(WorkItem.Target.TargetId);
                        CodeReveviewTmp.CodeReviewResponse.Add(Codereviewresponse);
                    }
                    else
                    {
                        CodeReview CodeReview = new CodeReview();
                        Codereviewrequest Codereviewrequest = new Codereviewrequest();
                        Codereviewrequest.CodeReviewRequestId = Int32.Parse(WorkItem.Source.SourceId);
                        CodeReview.Codereviewrequest = Codereviewrequest;

                        Codereviewresponse Codereviewresponse = new Codereviewresponse();
                        Codereviewresponse.CodeReviewRequestId = Int32.Parse(WorkItem.Source.SourceId);
                        Codereviewresponse.CodeReviewResponseId = Int32.Parse(WorkItem.Target.TargetId);
                        CodeReview.CodeReviewResponse.Add(Codereviewresponse);
                        CodeReviews.Add(CodeReview);
                    }

                }

            }


            foreach (CodeReview CodeReview in CodeReviews)
            {
                TfsWitWorkitemsArgs TfsWitWorkitemsArgs = new TfsWitWorkitemsArgs();
                TfsWitWorkitemsArgs.queryId = CodeReview.Codereviewrequest.CodeReviewRequestId.ToString();
                TfsWitWorkitemsResponse TfsWitWorkitemsResponse = TfsApiClient.Wit.workItems(TfsWitWorkitemsArgs, configuration);

                if (TfsWitWorkitemsResponse.Fields.CreatedDate >= ReferenceDate)
                {
                    CodeReview.Codereviewrequest.CreatedDate = TfsWitWorkitemsResponse.Fields.CreatedDate;
                    CodeReview.Codereviewrequest.ClosedDate = TfsWitWorkitemsResponse.Fields.ClosedDate;
                    CodeReview.Codereviewrequest.ChangedDate = TfsWitWorkitemsResponse.Fields.ChangedDate;
                    CodeReview.Codereviewrequest.Title = TfsWitWorkitemsResponse.Fields.Title;
                    CodeReview.Codereviewrequest.State = TfsWitWorkitemsResponse.Fields.State;
                    CodeReview.Codereviewrequest.ContexteType = TfsWitWorkitemsResponse.Fields.ContextType;
                    CodeReview.Codereviewrequest.CodeReviewClosedStatus = TfsWitWorkitemsResponse.Fields.MicrosoftVSTSCodeReviewClosedStatus;
                    CodeReview.Codereviewrequest.CodeReviewContext = TfsWitWorkitemsResponse.Fields.Context;


                    string loginCreatedBy = GetLoginCodeReview(TfsWitWorkitemsResponse.Fields.CreatedBy);

                    CodeReview.Codereviewrequest.CreatedBy = GetDevelopperID(loginCreatedBy, configuration, myConnection);


                    foreach (Codereviewresponse Codereviewresponse in CodeReview.CodeReviewResponse)
                    {
                        TfsWitWorkitemsArgs TfsWitWorkitemsArgsResponse = new TfsWitWorkitemsArgs();
                        TfsWitWorkitemsArgsResponse.queryId = Codereviewresponse.CodeReviewResponseId.ToString();
                        TfsWitWorkitemsResponse TfsWitWorkitemsResponseResponse = TfsApiClient.Wit.workItems(TfsWitWorkitemsArgsResponse, configuration);

                        Codereviewresponse.CodeReviewRequestId = CodeReview.Codereviewrequest.CodeReviewRequestId;
                        Codereviewresponse.State = TfsWitWorkitemsResponseResponse.Fields.State;
                        Codereviewresponse.CreatedDate = TfsWitWorkitemsResponseResponse.Fields.CreatedDate;
                        Codereviewresponse.ClosedDate = TfsWitWorkitemsResponseResponse.Fields.ClosedDate;
                        Codereviewresponse.ChangedDate = TfsWitWorkitemsResponseResponse.Fields.ChangedDate;
                        Codereviewresponse.Title = TfsWitWorkitemsResponseResponse.Fields.Title;
                        Codereviewresponse.ClosedStatus = TfsWitWorkitemsResponseResponse.Fields.MicrosoftVSTSCodeReviewClosedStatus;


                        if (TfsWitWorkitemsResponseResponse.Fields.MicrosoftVSTSCommonReviewedBy != null)
                        {
                            string DevelopperLoginReviewedBy = GetLoginCodeReview(TfsWitWorkitemsResponseResponse.Fields.MicrosoftVSTSCommonReviewedBy);
                            Codereviewresponse.ReviewedBy = GetDevelopperID(DevelopperLoginReviewedBy, configuration, myConnection);
                        }

                    }
                }


            }

            myConnection.Close();
            MySqlConnection myConnectionRead = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionWrite = new MySqlConnection(configuration["connectionString"]);
            myConnectionRead.Open();
            myConnectionWrite.Open();

            foreach (CodeReview CodeReview in CodeReviews)
            {

                if (CodeReview.Codereviewrequest.CodeReviewContext != null)
                {
                    if (DataCodeReviewRequest.ExistsCodeReview(CodeReview.Codereviewrequest.CodeReviewRequestId, myConnectionRead) == 0)
                    {
                        DataCodeReviewRequest.InsertData(CodeReview.Codereviewrequest, myConnectionWrite);
                        fillTableShelveset(TfsApiClient, configuration, CodeReview.Codereviewrequest.CodeReviewContext, CodeReview.Codereviewrequest.CodeReviewRequestId, myConnectionWrite);

                        foreach (Codereviewresponse Codereviewresponse in CodeReview.CodeReviewResponse)
                        {
                            DataCodeReviewResponse.InsertData(Codereviewresponse, myConnectionWrite);
                        }
                    }

                    else
                    {
                        DataCodeReviewRequest.UpdateCodeReview(CodeReview.Codereviewrequest.CodeReviewRequestId, CodeReview.Codereviewrequest, myConnectionWrite);

                        foreach (Codereviewresponse Codereviewresponse in CodeReview.CodeReviewResponse)
                        {
                            DataCodeReviewResponse.UpdateCodeReview(Codereviewresponse.CodeReviewResponseId, Codereviewresponse, myConnectionWrite);
                        }
                    }


                }
                
            }

        }


        // Fill table Comment
        public static void FillTableComment(TfsApiClient TfsApiClient, IConfigurationRoot configuration)
        {
            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();


            if (DataComment.CountRows(myConnection) == 0)
            {
                foreach (CodeReview CodeReview in CodeReviews)
                {
                    InsertCommentIntoDB(CodeReview, myConnection, configuration, TfsApiClient);
                }
            }
            else
            {
                foreach (CodeReview CodeReview in CodeReviews)
                {

                    if (CodeReview.Codereviewrequest.State.Equals("Closed") == false)
                    {
                        DataComment.DeleteComments(CodeReview.Codereviewrequest.CodeReviewRequestId, myConnection);
                        InsertCommentIntoDB(CodeReview, myConnection, configuration, TfsApiClient);

                    }
                }

            }

        }


        // Get Login for table codeReview
        public static string GetLoginCodeReview(string Login)
        {
            string DevelopperLogin;

            if (Login.Contains("CDBDX"))
            {
                int IndexCreatedBy = Login.LastIndexOf('<');
                DevelopperLogin = Login.Substring(IndexCreatedBy + 1).Trim('>').Substring(6);
                
            }
            else
            {
                DevelopperLogin = Login.ToLower().Replace(" ", ".");
            }

            return DevelopperLogin;
        }

        //// get Login Developper
        //public static string GetLoginIssue(string DevelopperLogin)
        //{

        //    if (DevelopperLogin.Substring(0, 6) == "cdbdx\\")
        //    {
        //        DevelopperLogin = DevelopperLogin.Substring(6);
        //    }
        //    else
        //    {
        //        int index = DevelopperLogin.IndexOf("@");
        //        DevelopperLogin = DevelopperLogin.Substring(0, index - 1);

        //    }

        //    return DevelopperLogin;
        //}

    
        // get ID Developper for table servicebuild
        public static int GetDevelopperIDBuild(string Login, Element Element, IConfigurationRoot configuration, MySqlConnection myConnection)
        {
            int DevelopperID = DataDevelopper.GetDevelopperInformation( Login, myConnection);

            if (DevelopperID == 0)
            {
                Developper Developper = new Developper();
                Developper.Login = Login;
                Developper.Name = Element.RequestedFor.Name;
                DataDevelopper.InsertData( Developper, myConnection);
                DevelopperID = DataDevelopper.GetDevelopperInformation( Login, myConnection);
            }
            return DevelopperID;
        }


        // get ID Developper
        public static int GetDevelopperID(string Login, IConfigurationRoot configuration, MySqlConnection myConnection)
        {

            int DevelopperID = DataDevelopper.GetDevelopperInformation( Login, myConnection);

            if (DevelopperID == 0)
            {
                Developper Developper = new Developper();
                Developper.Login = Login;
                DataDevelopper.InsertData( Developper, myConnection);
                DevelopperID = DataDevelopper.GetDevelopperInformation(Login, myConnection);
            }

            return DevelopperID;
        }


        // get Developper Login for table comment
        public static string GetLoginComment(string DevelopperLogin)
        {
            DevelopperLogin = DevelopperLogin.Substring(6);
            return DevelopperLogin;

        }


        // Insert a Comment Into table comment
        public static void InsertCommentIntoDB(CodeReview CodeReview, MySqlConnection myConnection, IConfigurationRoot configuration, TfsApiClient TfsApiClient)
        {

            TfsGetCommentsArgs TfsGetCommentsArgs = new TfsGetCommentsArgs();
            TfsGetCommentsArgs.WorkItemId = CodeReview.Codereviewrequest.CodeReviewRequestId.ToString();
            List<TfsGetCommentsResponse> TfsGetCommentsReponse = TfsApiClient.Comments.getComments(TfsGetCommentsArgs, configuration);

            foreach (TfsGetCommentsResponse TfsGetCommentsResponse in TfsGetCommentsReponse)
            {
                Comment Comment = new Comment();
                string DeveloperLogin = GetLoginComment(TfsGetCommentsResponse.AuthorUniqueName);
                Comment.DevelopperId = GetDevelopperID(TfsGetCommentsResponse.AuthorUniqueName, configuration, myConnection);
                Comment.CodeReviewRequestId = CodeReview.Codereviewrequest.CodeReviewRequestId;
                Comment.PublishDate = DateTime.Parse(TfsGetCommentsResponse.PublishDate);
                Comment.Content = TfsGetCommentsResponse.comment;
                if (TfsGetCommentsResponse.ItemName != null)
                {
                    Comment.FileId = TreatFileTFS(TfsGetCommentsResponse.ItemName, myConnection, configuration);
                }

                if (Comment.FileId != 0)
                {
                    DataComment.InsertData(Comment, myConnection);
                }
               

                int Parent = DataComment.GetLastID(myConnection);

                foreach (TfsGetCommentsResponse TfsGetCommentsResponseChild in TfsGetCommentsResponse.ReplyComments)
                {
                    Comment CommentChild = new Comment();
                    string DevLogin = GetLoginComment(TfsGetCommentsResponseChild.AuthorUniqueName);
                    CommentChild.DevelopperId = GetDevelopperID(TfsGetCommentsResponseChild.AuthorUniqueName, configuration, myConnection);
                    Comment.ParentId = Parent;
                    CommentChild.CodeReviewRequestId = CodeReview.Codereviewrequest.CodeReviewRequestId;
                    CommentChild.PublishDate = DateTime.Parse(TfsGetCommentsResponseChild.PublishDate);
                    CommentChild.Content = TfsGetCommentsResponseChild.comment;

                    if (TfsGetCommentsResponseChild.ItemName != null)
                    {
                        CommentChild.FileId = TreatFileTFS(TfsGetCommentsResponseChild.ItemName, myConnection, configuration);
                    }

                    if (CommentChild.FileId != 0)
                    {
                        DataComment.InsertData( CommentChild, myConnection);
                    }

                   
                }



            }

        }


        // Insert issue's service into table issue 
        public static void InsertServiceIssuesIntoDB(int ServiceID, MySqlConnection myConnection, IConfigurationRoot configuration, SonarIssuesSearch SonarIssues, SonarApiClient SonarClient)
        {

            foreach (SonarIssue issue in SonarIssues.Issues)
            {               
                Issue Issue = new Issue();

                Issue.IssueId = issue.Key;
                Issue.RuleKey = issue.RuleKey;
                Issue.Severity = issue.Severity;
                Issue.Type = issue.Type;
                Issue.RuleKey = issue.RuleKey;
                Issue.ServiceId = ServiceID;
                Issue.Type = issue.Type;
                Issue.CreationDate = issue.CreationDate;
                Issue.UpdateDate = issue.UpdateDate;

                if (issue.Line != null)
                {
                    Issue.Line = Int32.Parse(issue.Line);
                }

                
                if ( !String.IsNullOrEmpty(issue.Component))
                {
                    SonarComponentShowArgs SonarComponentShowArgsFile = new SonarComponentShowArgs();
                    SonarComponentShowArgsFile.ComponentKey = issue.Component;
                    ComponentShowResponse ComponentShowResponseFile = SonarClient.Components.Show(SonarComponentShowArgsFile, configuration);
                    int ID = TreatFileSonar(ComponentShowResponseFile, myConnection, configuration);
                    if (ID != -1)
                    {
                        Issue.FileId = ID;

                    }

                }
               
              
                /*List<SonarIssue> issuelist = new List<SonarIssue>();
                IEnumerable<string> AuthorList=  issuelist.Select(o => o.Author).Distinct();
                */

                if (issue.Assignee != null )
                {
                    Issue.DevelopperId = GetDevelopperID(issue.Assignee, configuration, myConnection);
                }
               

                int Exists = DataIssue.ExistIssues( Issue.IssueId, Issue.Type, myConnection);

                if ( Exists == 0 )
                {
                    DataIssue.InsertData( Issue, myConnection);
                }
                
            }

        }


        // Get changesets from the api and insert them into table changeset, also table changesetfile for each changeset
        public static void GetAndInsertChangesets(TfsApiClient TfsApiClient, TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgs, IConfigurationRoot configuration, MySqlConnection myConnection)
        {

            TfsVersionControlChangesetsResponse TfsVersionControlChangesetsResponse = TfsApiClient.VersionControl.Changesets(TfsVensionControlChangesetsArgs, configuration);
            int count = TfsVersionControlChangesetsResponse.ChangeSets.Count;

            TfsVersionControlChangesetsResponse TfsVersionControlChangesetsResponseTmp = TfsVersionControlChangesetsResponse;


            while (count != 1)
            {

                TfsVensionControlChangesetsArgs TfsVensionControlChangesetsArgsTmp = TfsVensionControlChangesetsArgs;
                TfsVensionControlChangesetsArgsTmp.searchCriteriatoId = Int32.Parse(TfsVersionControlChangesetsResponseTmp.ChangeSets[count - 1].ChangesetId);

                TfsVersionControlChangesetsResponseTmp = TfsApiClient.VersionControl.Changesets(TfsVensionControlChangesetsArgsTmp, configuration);

                Cdiscount.TFS.Api.VersionControl.Changesets.Response.Changeset ToRemove = TfsVersionControlChangesetsResponseTmp.ChangeSets[0];
                TfsVersionControlChangesetsResponseTmp.ChangeSets.RemoveAt(0);

                foreach (Cdiscount.TFS.Api.VersionControl.Changesets.Response.Changeset changeset in TfsVersionControlChangesetsResponseTmp.ChangeSets)
                {
                    TfsVersionControlChangesetsResponse.ChangeSets.Add(changeset);

                }

                TfsVersionControlChangesetsResponseTmp.ChangeSets.Insert(0,ToRemove);
                count = TfsVersionControlChangesetsResponseTmp.ChangeSets.Count;

            }
            
            foreach (Cdiscount.TFS.Api.VersionControl.Changesets.Response.Changeset changeset in TfsVersionControlChangesetsResponse.ChangeSets)
            {
                DataAccess.Models.Changeset ChangesetToInsert = new DataAccess.Models.Changeset();

               
                ChangesetToInsert.ChangesetId = Int32.Parse(changeset.ChangesetId);
                ChangesetToInsert.Comment = changeset.Comment;
                ChangesetToInsert.CreatedDate = changeset.CreatedDate;

                String DevelopperLogin = changeset.Author.UniqueName.Substring(6);
                ChangesetToInsert.DevelopperId = GetDevelopperID(DevelopperLogin, configuration, myConnection);

                DataChangeset.InsertData(ChangesetToInsert, myConnection);
                fillTableChangesetFile(TfsApiClient, configuration, Int32.Parse(changeset.ChangesetId), myConnection);
            }


        }


        // Get FileID from serviceinformation table
        public static int TreatFileTFS(String ItemName, MySqlConnection myConnection, IConfigurationRoot configuration)
        {
            int FileID = 0;

            if (ItemName.StartsWith("$/Cdiscount/Main/"))
            {
                 ItemName = ItemName.Replace("$/Cdiscount/Main/", "");                
                int serviceId = 0;

                if (ItemName.StartsWith("Service/Services/"))
                {
                    string ServiceName = ItemName.Replace("Service/Services/", "");
                    int index = ServiceName.IndexOf('/');
                    if (index != -1)
                    {
                        ServiceName = ServiceName.Substring(0, index);
                        ServiceName = ServiceName + " Dev";

                        serviceId = DataServiceInformation.GetServiceInformation( ServiceName, myConnection);

                    }

                }
                 FileID = DataFile.GetFileInformation( ItemName, myConnection);

                if (FileID == 0)
                {
                    File file = new File();
                    file.FileKey = ItemName;

                    if (serviceId != 0 && serviceId != -1)
                    {
                        file.ServiceId = serviceId;
                    }

                    DataFile.InsertData( file, myConnection);
                    FileID = DataFile.GetFileInformation( ItemName, myConnection);
                }

                return FileID;

            }

            return FileID;


        }
      
        
        // Get FileID from serviceinformation table
        public static int TreatFileSonar(ComponentShowResponse Component, MySqlConnection myConnection, IConfigurationRoot configuration)
        {
            string Suffix = "Service/Services/";

            if (Component != null)
            {
                Component ComponentProject = Component.Ancestors.Find(x => x.Qualifier.Equals("TRK"));

                int serviceId = DataServiceInformation.GetServiceInformation( ComponentProject.ComponentName, myConnection);
                string ProjectPath = ComponentProject.ComponentName.Replace(" Dev", "");

                Component ComponentModule = Component.Ancestors.Find(x => x.Qualifier.Equals("BRC"));
                string ModulePath = ComponentModule.Path;

                string FilePath = Component.Component.Path;

                string ItemName = Suffix + ProjectPath + "/" + ModulePath + "/" + FilePath;

                int FileID = DataFile.GetFileInformation(ItemName, myConnection);

                if (FileID == 0)
                {

                    File file = new File();
                    file.FileKey = ItemName;
                    if (serviceId != 0 && serviceId != -1 )
                    {
                        file.ServiceId = serviceId;
                    }
                    DataFile.InsertData( file, myConnection);
                    FileID = DataFile.GetFileInformation( ItemName, myConnection);

                }

                return FileID;

            }
            else
            {
                return -1;
            }


            

        }


        // Fill table ChangesetFile
        public static void fillTableChangesetFile(TfsApiClient TfsApiClient, IConfigurationRoot configuration, int ChangeSetID, MySqlConnection myConnection)
        {
            
            TfsVersioncontrolChangesetsChangesArgs TfsVersioncontrolChangesetsChangesArgs = new TfsVersioncontrolChangesetsChangesArgs();
            TfsVersioncontrolChangesetsChangesArgs.apiVersion = "2.0";
            TfsVersioncontrolChangesetsChangesArgs.id = ChangeSetID;
            TfsVersioncontrolChangesetsChangesArgs.top = 100;
            TfsVersioncontrolChangesetsChangesArgs.skip = 0;
            TfsVersioncontrolChangesetsChangesReponse TfsVersioncontrolChangesetsChangesReponse = TfsApiClient.VersionControl.ChangesetChanges(TfsVersioncontrolChangesetsChangesArgs, configuration);

            int countChanges = TfsVersioncontrolChangesetsChangesReponse.Changes.Count;

            while (countChanges != 0 && countChanges == 100)
            {

                TfsVersioncontrolChangesetsChangesArgs TfsVersioncontrolChangesetsChangesArgsTmp = TfsVersioncontrolChangesetsChangesArgs;
                TfsVersioncontrolChangesetsChangesArgsTmp.top = 100;
                TfsVersioncontrolChangesetsChangesArgsTmp.skip = 100 + TfsVersioncontrolChangesetsChangesArgsTmp.skip;
                TfsVersioncontrolChangesetsChangesReponse TfsVersioncontrolChangesetsChangesReponseTmp = TfsApiClient.VersionControl.ChangesetChanges(TfsVersioncontrolChangesetsChangesArgsTmp, configuration);
                foreach (Change change in TfsVersioncontrolChangesetsChangesReponseTmp.Changes)
                {
                    TfsVersioncontrolChangesetsChangesReponse.Changes.Add(change);
                }
                countChanges = TfsVersioncontrolChangesetsChangesReponseTmp.Changes.Count;

            }



            foreach (Change Change in TfsVersioncontrolChangesetsChangesReponse.Changes)
            {

                Changesetfile Changesetfile = new Changesetfile();
                Changesetfile.FileId = TreatFileTFS(Change.Item.Path,  myConnection,  configuration);
                Changesetfile.ChangesetId = ChangeSetID;

                int Exists = DataChangesetFile.Exist(Changesetfile.FileId, Changesetfile.ChangesetId, myConnection);

                if (Exists == 0 && Changesetfile.FileId != 0)
                {
                    DataChangesetFile.InsertData( Changesetfile, myConnection);
                }
                
            }



        }


        // Fill table Shelveset
        public static void fillTableShelveset(TfsApiClient TfsApiClient, IConfigurationRoot configuration, string ShelvesetName, int CodeReviewRequestID, MySqlConnection myConnection)
        {


            TfsVersionControlShelvesetsArgs TfsVersionControlShelvesetsArgs = new TfsVersionControlShelvesetsArgs();
            TfsVersionControlShelvesetsArgs.shelveset = ShelvesetName;
            TfsVersionControlShelvesetsResponse TfsVersionControlShelvesetsResponse = TfsApiClient.VersionControl.Shelvesets(TfsVersionControlShelvesetsArgs, configuration);

            if (TfsVersionControlShelvesetsResponse != null)
            {
                Shelveset Shelveset = new Shelveset();
                if (TfsVersionControlShelvesetsResponse.Comment != null)
                {
                    Shelveset.Comment = TfsVersionControlShelvesetsResponse.Comment;
                }

                Shelveset.CreatedDate = TfsVersionControlShelvesetsResponse.createdDate;
                Shelveset.ShelvesetName = TfsVersionControlShelvesetsResponse.Name;
                Shelveset.CodeReviewRequestID = CodeReviewRequestID;
                Shelveset.ShelvesetOwner = DataDevelopper.GetDevelopperInformation( TfsVersionControlShelvesetsResponse.Owner.UniqueName.Substring(6), myConnection);

                int Exists = DataShelveset.Exist(Shelveset.ShelvesetName, Shelveset.ShelvesetOwner, myConnection);

                if (Exists == 0)
                {
                    DataShelveset.InsertData(Shelveset, myConnection);
                }

                
                TableShelvesetFile(TfsApiClient, configuration, Shelveset, TfsVersionControlShelvesetsResponse.Owner, myConnection);
            }



        }
       
        public static void TableShelvesetFile(TfsApiClient TfsApiClient, IConfigurationRoot configuration, Shelveset Shelveset, Owner Owner, MySqlConnection myConnection)
        {

            TfsVersionControlShelvesetsChangesArgs TfsVersionControlShelvesetsChangesArgs = new TfsVersionControlShelvesetsChangesArgs();
            TfsVersionControlShelvesetsChangesArgs.Name = Shelveset.ShelvesetName;
            TfsVersionControlShelvesetsChangesArgs.top = 100;
            TfsVersionControlShelvesetsChangesArgs.Owner = Owner.UniqueName.Substring(6);
            TfsVersioncontrolShelvesetsChangesReponse TfsVersioncontrolShelvesetsChangesReponse = TfsApiClient.VersionControl.ShelvesetsChanges(TfsVersionControlShelvesetsChangesArgs, configuration);

            if (TfsVersioncontrolShelvesetsChangesReponse != null)
            {

                FillTableShelvesetFile(TfsVersionControlShelvesetsChangesArgs, TfsApiClient, configuration, Shelveset, myConnection);
            }
            else
            {

                TfsVersionControlShelvesetsChangesArgs TfsVersionControlShelvesetsChanges = new TfsVersionControlShelvesetsChangesArgs();
                TfsVersionControlShelvesetsChanges.Name = Shelveset.ShelvesetName;
                TfsVersionControlShelvesetsChanges.top = 100;
                TfsVersionControlShelvesetsChanges.Owner = Owner.Id;
                FillTableShelvesetFile(TfsVersionControlShelvesetsChanges, TfsApiClient, configuration, Shelveset, myConnection);

            }


        }

      
        // Fill table ShelvesetFile
        public static void FillTableShelvesetFile(TfsVersionControlShelvesetsChangesArgs TfsVersionControlShelvesetsChangesArgs, TfsApiClient TfsApiClient, IConfigurationRoot configuration, Shelveset shelveset, MySqlConnection myConnection)
        {
            TfsVersioncontrolShelvesetsChangesReponse TfsVersioncontrolShelvesetsChangesRep = TfsApiClient.VersionControl.ShelvesetsChanges(TfsVersionControlShelvesetsChangesArgs, configuration);

            int countChanges = Int32.Parse(TfsVersioncontrolShelvesetsChangesRep.Count);

            while (countChanges != 0 && countChanges == 100)
            {

                TfsVersionControlShelvesetsChangesArgs TfsVersioncontrolShelvesetsChangesArgsTmp = TfsVersionControlShelvesetsChangesArgs;
                TfsVersioncontrolShelvesetsChangesArgsTmp.top = 100;
                TfsVersioncontrolShelvesetsChangesArgsTmp.skip = 100 + TfsVersioncontrolShelvesetsChangesArgsTmp.skip;
                TfsVersioncontrolShelvesetsChangesReponse TfsVersioncontrolShelvesetsChangesResponseTmp = TfsApiClient.VersionControl.ShelvesetsChanges(TfsVersioncontrolShelvesetsChangesArgsTmp, configuration);
                foreach (value value in TfsVersioncontrolShelvesetsChangesResponseTmp.Value)
                {
                    TfsVersioncontrolShelvesetsChangesRep.Value.Add(value);
                }
                countChanges = TfsVersioncontrolShelvesetsChangesResponseTmp.Value.Count;

            }

            int shelveID = DataShelveset.GetShelvesetId(shelveset.ShelvesetName, shelveset.ShelvesetOwner, myConnection);

            foreach (value value in TfsVersioncontrolShelvesetsChangesRep.Value)
            {

                Shelvesetfile ShelvesetToInsert = new Shelvesetfile();
                ShelvesetToInsert.ShelevesetId = shelveID;
                ShelvesetToInsert.FileId = TreatFileTFS(value.item.path, myConnection, configuration);

                int Exists = DataShelvsetFile.Exist(ShelvesetToInsert.ShelevesetId, ShelvesetToInsert.FileId, myConnection);

                if (Exists == 0 && ShelvesetToInsert.FileId != 0)
                {
                    DataShelvsetFile.InsertData(ShelvesetToInsert, myConnection);
                }

            }



        }


    }
}
