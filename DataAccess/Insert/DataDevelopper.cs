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

            int DevelopperID = GetDevelopperInformation(DevelopperLogin, myConnection);

            string query = "SELECT serviceinformation.ServiceName, issue.Severity, issue.Type, issue.Resolved FROM issue, serviceinformation where DevelopperID = @DevelopperID and serviceinformation.ServiceID = issue.ServiceID and Resolved=@Resolved";

            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.Parameters.AddWithValue("@DevelopperID", DevelopperID);
            myCommand.Parameters.AddWithValue("@Resolved", "False");

            DevelopperMetrics DevelopperMetrics = new DevelopperMetrics();
            DbDataReader reader = myCommand.ExecuteReader();

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
