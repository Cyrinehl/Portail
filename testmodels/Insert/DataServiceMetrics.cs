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
    public class DataServiceMetrics
    {
        public static void InsertData(IConfigurationRoot configuration, Servicemetrics Servicemetrics, MySqlConnection myConnection)
        {
            
            try
            {
                               
                string query = "INSERT IGNORE INTO servicemetrics (ServiceID, ServiceProfile, NumberBugs, NumberVulnerabilities, NumberCodeSmells, Coverage, Duplication, Size, Complexity, Documentation, InterrogationDate, Automatic)";
                query += " VALUES (@ServiceID, @ServiceProfile, @NumberBugs, @NumberVulnerabilities, @NumberCodeSmells, @Coverage, @Duplication, @Size, @Complexity, @Documentation, @InterrogationDate, @Automatic)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceID", Servicemetrics.ServiceId);
                myCommand.Parameters.AddWithValue("@ServiceProfile", Servicemetrics.ServiceProfile);
                myCommand.Parameters.AddWithValue("@NumberBugs", Servicemetrics.NumberBugs);
                myCommand.Parameters.AddWithValue("@NumberVulnerabilities", Servicemetrics.NumberVulnerabilities);
                myCommand.Parameters.AddWithValue("@NumberCodeSmells", Servicemetrics.NumberCodeSmells);
                myCommand.Parameters.AddWithValue("@Coverage", Servicemetrics.Coverage);
                myCommand.Parameters.AddWithValue("@Duplication", Servicemetrics.Duplication);
                myCommand.Parameters.AddWithValue("@Size", Servicemetrics.Size);
                myCommand.Parameters.AddWithValue("@Complexity", Servicemetrics.Complexity);
                myCommand.Parameters.AddWithValue("@Documentation", Servicemetrics.Documentation);
                myCommand.Parameters.AddWithValue("@InterrogationDate", Servicemetrics.InterrogationDate);
                myCommand.Parameters.AddWithValue("@Automatic", Servicemetrics.Automatic);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }

        }


        public static List<MetricViewModel> GetLastestMetrics(IConfigurationRoot configuration)
        {

            
                DbDataReader reader = null;               
                List<MetricViewModel> Metrics = new List<MetricViewModel>();

                MySqlConnection myConnectionServices = new MySqlConnection(configuration["connectionString"]);
                MySqlConnection myConnectionMetrics = new MySqlConnection(configuration["connectionString"]);
                MySqlConnection myConnectionTests = new MySqlConnection(configuration["connectionString"]);

                myConnectionServices.Open();
                myConnectionMetrics.Open();
                myConnectionTests.Open();

                string queryServices = "select ServiceID, serviceName from serviceinformation";
                MySqlCommand commandServices = new MySqlCommand(queryServices, myConnectionServices);
                reader = commandServices.ExecuteReader();

                while (reader.Read())
                {

                    string queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC";
                    MySqlCommand commandMetrics = new MySqlCommand(queryMetrics, myConnectionMetrics);
                    commandMetrics.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));

                    DbDataReader readerMetrics = commandMetrics.ExecuteReader();
                    readerMetrics.Read();

                    string queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC";
                    MySqlCommand commandTests = new MySqlCommand(queryTests, myConnectionTests);
                    commandTests.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));

                    
                    DbDataReader readerTests = commandTests.ExecuteReader();
                    readerTests.Read();

                    MetricViewModel Servicemetrics = new MetricViewModel();
                    Servicemetrics.ServiceProfile = readerMetrics.GetString(2);
                    Servicemetrics.NumberBugs = readerMetrics.GetInt32(3);
                    Servicemetrics.NumberVulnerabilities = readerMetrics.GetInt32(4);
                    Servicemetrics.NumberCodeSmells = readerMetrics.GetInt32(5);
                    Servicemetrics.Coverage = readerMetrics.GetDecimal(6);
                    Servicemetrics.Duplication = readerMetrics.GetDecimal(7);
                    Servicemetrics.Size = readerMetrics.GetInt32(8);
                    Servicemetrics.Complexity = readerMetrics.GetInt32(9);
                    Servicemetrics.Documentation = readerMetrics.GetDecimal(10);
                    Servicemetrics.ServiceName = reader.GetString(1);

                    if (readerTests != null)
                    {
                    Servicemetrics.PassedTests = readerTests.GetInt32(8);
                    Servicemetrics.TotalTests = readerTests.GetInt32(7);
                    }    

                    

                    readerMetrics.Dispose();
                    readerTests.Dispose();



                }

                return Metrics;
                  

        }




    }
}
