using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace DataAccess.Insert
{
    public static class DataIssue
    {


        public static void InsertData(IConfigurationRoot configuration, Issue Issue, MySqlConnection myConnection)
        {
          
            try
            {
               
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                string query = "INSERT INTO issue (CreationDate, DevelopperId, FileId, Line, Module, ModuleKey, RuleKey, ServiceId, Severity ,IssueID, Type, UpdateDate)";
                query += " VALUES (@CreationDate, @DevelopperId, @FileId, @Line, @Module, @ModuleKey, @RuleKey, @ServiceId, @Severity, @IssueID, @Type, @UpdateDate)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CreationDate", Issue.CreationDate);
                myCommand.Parameters.AddWithValue("@DevelopperId", Issue.DevelopperId);
                myCommand.Parameters.AddWithValue("@FileId", Issue.FileId);
                myCommand.Parameters.AddWithValue("@Line", Issue.Line);
                myCommand.Parameters.AddWithValue("@Module", Issue.Module);
                myCommand.Parameters.AddWithValue("@ModuleKey", Issue.ModuleKey);
                myCommand.Parameters.AddWithValue("@RuleKey", Issue.RuleKey);
                myCommand.Parameters.AddWithValue("@ServiceId", Issue.ServiceId);
                myCommand.Parameters.AddWithValue("@Severity", Issue.Severity);
                myCommand.Parameters.AddWithValue("@IssueID", Issue.IssueId);
                myCommand.Parameters.AddWithValue("@Type", Issue.Type);
                myCommand.Parameters.AddWithValue("@UpdateDate", Issue.UpdateDate);

                int row = myCommand.ExecuteNonQuery();
                if (row == 1)
                {
                    string infdg = "yes";
                }
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }


        public static string GetIssueInformation(IConfigurationRoot configuration, string IssueID, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                string r="notFound";
                string query = "SELECT * from issue WHERE IssueID =@IssueID";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@IssueID", IssueID);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToString(result);
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table:" + e.Message + "\t" + e.GetType();
                return "erroooooooooooor";
            }

        }

        public static List<IssueRuleType> GetServiceIssues(IConfigurationRoot configuration, int ServiceID, MySqlConnection myConnection)
        {

            try
            {
                List<IssueRuleType> Issues = new List<IssueRuleType>();
                DbDataReader myReader;

                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
               
                string query = "SELECT IssueID, Type from issue WHERE ServiceID =@ServiceID";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceID", ServiceID);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    IssueRuleType IssueRuleType = new IssueRuleType();
                    IssueRuleType.IssueRule = myReader.GetString(0);
                    IssueRuleType.IssueType = myReader.GetString(1);
                    Issues.Add(IssueRuleType);
                }

                myReader.Dispose();

                return Issues;



            }
            catch (Exception e)
            {

                string error = "Exception Occre while selecting from table:" + e.Message + "\t" + e.GetType();
                List<IssueRuleType> vide = new List<IssueRuleType>();
                return vide;
            }



        }

        public static int CountRows(MySqlConnection myConnection)
        {
            try
            {
                int r = -1;
                ConnectionState State = myConnection.State;
                string query = "SELECT COUNT(*) FROM issue";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToInt32(result);
                }


                return r;
            }
            catch (Exception e)
            {
                string error = "Exception Occre while getting rows ID:" + e.Message + "\t" + e.GetType();
                return -1;

            }
        }

        public static void UpdateIssue(IConfigurationRoot configuration, IssueRuleType Issue, MySqlConnection myConnection, DateTime UpdateTime)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                string query = "UPDATE issue SET Resolved=@Resolved, UpdateDate=@UpdateDate WHERE IssueID = @IssueID and Type=@Type ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@Resolved", "True");
                myCommand.Parameters.AddWithValue("@UpdateDate", UpdateTime);
                myCommand.Parameters.AddWithValue("@IssueID", Issue.IssueRule);
                myCommand.Parameters.AddWithValue("@Type", Issue.IssueType);

                object result = myCommand.ExecuteScalar();


            }
            catch (Exception e)
            {
                string error = "Exception Occre while updating table:" + e.Message + "\t" + e.GetType();

            }



        }



        public static int ExistIssues(IConfigurationRoot configuration, string IssueID, string IssueType, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                int r = 0;

                string query = "SELECT * from issue WHERE IssueID =@IssueID and Type=@Type  ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@IssueID", IssueID);
                myCommand.Parameters.AddWithValue("@Type", IssueType);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = 1;
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table:" + e.Message + "\t" + e.GetType();
                return -1;
            }

        }

        public class IssueRuleType
        {
            public string IssueRule;
            public string IssueType;
        }

    }
}
