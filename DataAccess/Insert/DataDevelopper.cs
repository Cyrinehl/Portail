using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace DataAccess.Insert
{
    public class DataDevelopper
    {
        public static void InsertData(Developper Developper, MySqlConnection myConnection)
        {
           
            try
            {
                               
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                string query = "INSERT IGNORE INTO developper (Email, StartDate, EndDate, Login, Name)";
                query += " VALUES (@Email, @StartDate, @EndDate, @Login, @Name)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@Email", Developper.Email);
                myCommand.Parameters.AddWithValue("@StartDate", Developper.StartDate);
                myCommand.Parameters.AddWithValue("@EndDate", Developper.EndDate);
                myCommand.Parameters.AddWithValue("@Login", Developper.Login);
                myCommand.Parameters.AddWithValue("@Name", Developper.Name);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table developper:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int GetDevelopperInformation(string DevelopperLogin, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                int r = 0;
                string query = "SELECT DevelopperID from developper WHERE Login =@Login";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@Login", DevelopperLogin);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToInt32(result);                  
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table developper:" + e.Message + "\t" + e.GetType();
                return 0;
            }



        }

        public static DevelopperMetrics GetDevelopperMetrics(string DevelopperLogin, IConfigurationRoot configuration)
        {
            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionRequest = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionIDs = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionComment = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionChangeset = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionBuild = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionNbChangesets = new MySqlConnection(configuration["connectionString"]);

            List<ChangesetService> Changesets = new List<ChangesetService>();

            myConnectionNbChangesets.Open();
            myConnectionRequest.Open();
            myConnectionIDs.Open();
            myConnectionComment.Open();
            myConnectionChangeset.Open();
            myConnectionBuild.Open();

            int DevelopperID = GetDevelopperInformation(DevelopperLogin, myConnection);

            string query = "SELECT serviceinformation.ServiceName, issue.Severity, issue.Type, issue.Resolved FROM issue, serviceinformation where DevelopperID = @DevelopperID and serviceinformation.ServiceID = issue.ServiceID and Resolved=@Resolved";
            string queryRequest = "SELECT count(*) FROM developper.codereviewrequest where CreatedBy = @CreatedBy";
            string queryCodeReviewRequestIDs = "SELECT CodeReviewRequestID FROM codereviewrequest where CreatedBy = @CreatedBy ";
            string queryChangesets = "SELECT count(*) FROM developper.changeset where DevelopperID = @DevelopperID";
            string queryChangesetService = "SELECT changeset.ChangesetID, changeset.DevelopperID, serviceinformation.ServiceName FROM changeset, developper.changesetfile, serviceinformation, file where changesetfile.FileID = file.FileID and file.ServiceID = serviceinformation.ServiceID and changeset.ChangesetID = changesetfile.changesetID";
            string queryBuilds = "SELECT Result FROM developper.servicebuild where DevelopperID= @DevelopperID";


            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            MySqlCommand myCommandNbChangesets = new MySqlCommand(queryChangesets, myConnectionNbChangesets);
            MySqlCommand myCommandRequest = new MySqlCommand(queryRequest, myConnectionRequest);
            MySqlCommand myCommandIDs= new MySqlCommand(queryCodeReviewRequestIDs, myConnectionIDs);
            MySqlCommand myCommandChangesets = new MySqlCommand(queryChangesetService, myConnectionChangeset);
            MySqlCommand myCommandBuild = new MySqlCommand(queryBuilds, myConnectionBuild);

            myCommand.Parameters.AddWithValue("@DevelopperID", DevelopperID);
            myCommand.Parameters.AddWithValue("@Resolved", "False");

            myCommandRequest.Parameters.AddWithValue("@CreatedBy", DevelopperID);
            myCommandIDs.Parameters.AddWithValue("@CreatedBy", DevelopperID);
            //myCommandChangesets.Parameters.AddWithValue("@DevelopperID", DevelopperID);
            myCommandBuild.Parameters.AddWithValue("@DevelopperID", DevelopperID);
            myCommandNbChangesets.Parameters.AddWithValue("@DevelopperID", DevelopperID);


            DevelopperMetrics DevelopperMetrics = new DevelopperMetrics();

            DbDataReader reader = myCommand.ExecuteReader();
            DbDataReader readerRequest = myCommandRequest.ExecuteReader();
            DbDataReader readerIDs= myCommandIDs.ExecuteReader();
            DbDataReader readerChangeset = myCommandChangesets.ExecuteReader();
            DbDataReader readerBuild = myCommandBuild.ExecuteReader();
            DbDataReader readerNbChangeset = myCommandNbChangesets.ExecuteReader();



            readerRequest.Read();
            while (readerChangeset.Read())
            {
                ChangesetService Changeset = new ChangesetService();
                Changeset.changesetID = readerChangeset.GetInt32(0);
                Changeset.developperID = readerChangeset.GetInt32(1);
                Changeset.serviceName = readerChangeset.GetString(2);
                Changesets.Add(Changeset);

            }




            List<ChangesetService> ChangesetsTmp = Changesets.FindAll(x => x.developperID.Equals(DevelopperID));

            ChangesetsTmp.Distinct();

            foreach (ChangesetService ChangesetService in ChangesetsTmp)
            {
                ChangesetPerService TMP =  DevelopperMetrics.ChangesetPerService.Find(x => x.ServiceName.Equals(ChangesetService.serviceName));
                if (TMP != null)
                {
                    TMP.NbChnagesets ++;
                }
                else
                {
                    ChangesetPerService ChangesetPerService = new ChangesetPerService();
                    ChangesetPerService.ServiceName = ChangesetService.serviceName;
                    ChangesetPerService.NbChnagesets = 1;
                    DevelopperMetrics.ChangesetPerService.Add(ChangesetPerService);
                }

            }
            readerNbChangeset.Read();


            DevelopperMetrics.NbCodeReviewRequested = readerRequest.GetInt32(0);
            DevelopperMetrics.NbChangesets = readerNbChangeset.GetInt32(0);


            DevelopperMetrics.NbComments = 0;


            while (readerBuild.Read())
            {
                Build build = new Build();
                build.Result = readerBuild.GetString(0);
                DevelopperMetrics.Builds.Add(build);               
            }
            
            DevelopperMetrics.BuildFailed = DevelopperMetrics.Builds.FindAll(x => x.Result.Equals("failed")).Count;
            DevelopperMetrics.BuildPartiallySuccedeed = DevelopperMetrics.Builds.FindAll(x => x.Result.Equals("partiallySucceeded")).Count;
            DevelopperMetrics.BuildSucceded = DevelopperMetrics.Builds.FindAll(x => x.Result.Equals("succeeded")).Count;
            DevelopperMetrics.BuildCancelled = DevelopperMetrics.Builds.FindAll(x => x.Result.Equals("canceled")).Count;

            while (readerIDs.Read())
            {
                string QueryComments = "SELECT count(*) FROM developper.comment where CodeReviewRequestID = @CodeReviewRequestID";
                MySqlCommand myCommandComment = new MySqlCommand(QueryComments, myConnectionComment);
                
                myCommandComment.Parameters.AddWithValue("@CodeReviewRequestID", readerIDs.GetInt32(0));
                DbDataReader readerComments = myCommandComment.ExecuteReader();

                readerComments.Read();

                DevelopperMetrics.NbComments = DevelopperMetrics.NbComments + readerComments.GetInt32(0);

                readerComments.Dispose();

            }



            while (reader.Read())
            {
                IssueDevelopper IssueDevelopper = new IssueDevelopper();
                IssueDevelopper.ServiceName = reader.GetString(0);
                IssueDevelopper.Severity = reader.GetString(1);
                IssueDevelopper.Type = reader.GetString(2);
                IssueDevelopper.Resolved = reader.GetString(3);

                DevelopperMetrics.developpersIssues.Add(IssueDevelopper);
            }

            DevelopperMetrics.NbIssues = DevelopperMetrics.developpersIssues.Count;

            IEnumerable<string> ServiceList = DevelopperMetrics.developpersIssues.Select(o => o.ServiceName).Distinct();
            foreach (string Service in ServiceList)
            {
                List<IssueDevelopper> ListServiceIssues = DevelopperMetrics.developpersIssues.FindAll(x => x.ServiceName.Equals(Service));
                IssuesPerService IssuesPerService = new IssuesPerService();
                IssuesPerService.ServiceName = Service;
                IssuesPerService.NbIssues = ListServiceIssues.Count;
                DevelopperMetrics.IssuesPerService.Add(IssuesPerService);
            }

            return DevelopperMetrics;

        }


    }
}
