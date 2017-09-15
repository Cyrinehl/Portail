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
        public static void InsertData( Servicemetrics Servicemetrics, MySqlConnection myConnection)
        {
            
            try
            {
                               
                string query = "INSERT IGNORE INTO servicemetrics (ServiceID, ServiceProfile, NumberBugs, NumberVulnerabilities, NumberCodeSmells, Coverage, Duplication, Size, Complexity, Documentation, InterrogationDate)";
                query += " VALUES (@ServiceID, @ServiceProfile, @NumberBugs, @NumberVulnerabilities, @NumberCodeSmells, @Coverage, @Duplication, @Size, @Complexity, @Documentation, @InterrogationDate)";

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

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table servicemetrics:" + e.Message + "\t" + e.GetType();
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

                //string queryServices = "select ServiceID, serviceName from serviceinformation";
                string queryServices = "SELECT ServiceID, ServiceName, DirectionName, DirectionteamName FROM serviceinformation se, teamdirection te, direction di where se.DirectionTeamID = te.DirectionTeamID and te.DirectionID = di.DirectionID";
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
                    Servicemetrics.DirectionName = reader.GetString(2);
                    Servicemetrics.TeamName = reader.GetString(3);

                    if (readerTests.Read())
                    {
                    //Servicemetrics.PassedTests = readerTests.GetInt32(8);
                    //Servicemetrics.TotalTests = readerTests.GetInt32(6);
                        if (!readerTests.IsDBNull(8))
                        {
                            Servicemetrics.PassedTests = readerTests.GetInt32(8);
                        }

                        if (!readerTests.IsDBNull(6))
                        {
                            Servicemetrics.TotalTests = readerTests.GetInt32(6);
                        }

                    }   

                                      
                    readerMetrics.Dispose();
                    readerTests.Dispose();

                    Metrics.Add(Servicemetrics);


                }

                return Metrics;
                                 

        }
        public static List<MetricViewModel> GetDeltaMetrics(IConfigurationRoot configuration)
        {


            DbDataReader reader = null;
            List<TmpObject> Objects = new List<TmpObject>();
            List<MetricViewModel> ListToReturn = new List<MetricViewModel>();  
            
            MySqlConnection myConnectionServices = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionLastDate = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionMetrics = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionTests = new MySqlConnection(configuration["connectionString"]);

            myConnectionServices.Open();
            myConnectionLastDate.Open();
            myConnectionMetrics.Open();
            myConnectionTests.Open();

            //string queryServices = "select ServiceID, serviceName from serviceinformation";
            string queryServices = "SELECT ServiceID, ServiceName, DirectionName, DirectionteamName FROM serviceinformation se, teamdirection te, direction di where se.DirectionTeamID = te.DirectionTeamID and te.DirectionID = di.DirectionID";
            MySqlCommand commandServices = new MySqlCommand(queryServices, myConnectionServices);



            reader = commandServices.ExecuteReader();

            while (reader.Read())
            {


                TmpObject Object = new TmpObject();

                string queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 2";
                MySqlCommand commandMetrics = new MySqlCommand(queryMetrics, myConnectionMetrics);
                commandMetrics.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));

                DbDataReader readerMetrics = commandMetrics.ExecuteReader();
                

                string queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 2";
                MySqlCommand commandTests = new MySqlCommand(queryTests, myConnectionTests);
                commandTests.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));


                DbDataReader readerTests = commandTests.ExecuteReader();

                while (readerMetrics.Read())
                {


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
                    Servicemetrics.DirectionName = reader.GetString(2);
                    Servicemetrics.TeamName = reader.GetString(3);

                    if (readerTests.Read())
                    {

                        //Servicemetrics.PassedTests = readerTests.GetInt32(8);
                        //Servicemetrics.TotalTests = readerTests.GetInt32(6);
                        if (!readerTests.IsDBNull(8))
                        {
                            Servicemetrics.PassedTests = readerTests.GetInt32(8);
                        }

                        if (!readerTests.IsDBNull(6))
                        {
                            Servicemetrics.TotalTests = readerTests.GetInt32(6);
                        }


                    }

                    Object.Metrics.Add(Servicemetrics);

                }




                readerMetrics.Dispose();
                readerTests.Dispose();

                Objects.Add(Object);


            }



            foreach (TmpObject ob in Objects)
            {
                ob.MetricsToShow.ServiceProfile = ob.Metrics[0].ServiceProfile;
                ob.MetricsToShow.ServiceName = ob.Metrics[0].ServiceName;
                ob.MetricsToShow.DirectionName = ob.Metrics[0].DirectionName;
                ob.MetricsToShow.TeamName = ob.Metrics[0].TeamName;
                ob.MetricsToShow.NumberBugs = ob.Metrics[0].NumberBugs - ob.Metrics[1].NumberBugs;
                ob.MetricsToShow.NumberVulnerabilities = ob.Metrics[0].NumberVulnerabilities - ob.Metrics[1].NumberVulnerabilities;
                ob.MetricsToShow.NumberCodeSmells = ob.Metrics[0].NumberCodeSmells - ob.Metrics[1].NumberCodeSmells;
                ob.MetricsToShow.Coverage = ob.Metrics[0].Coverage - ob.Metrics[1].Coverage;
                ob.MetricsToShow.Duplication = ob.Metrics[0].Duplication - ob.Metrics[1].Duplication;
                ob.MetricsToShow.Size = ob.Metrics[0].Size - ob.Metrics[1].Size;
                ob.MetricsToShow.Complexity = ob.Metrics[0].Complexity - ob.Metrics[1].Complexity;
                ob.MetricsToShow.Documentation = ob.Metrics[0].Documentation - ob.Metrics[1].Documentation;

                ListToReturn.Add(ob.MetricsToShow);
            }


            return ListToReturn;


        }


        public static List<MetricViewModel> GetDeltaMetricsBox(IConfigurationRoot configuration, string choice="")
        {


            DbDataReader reader = null;
            List<TmpObject> Objects = new List<TmpObject>();
            List<MetricViewModel> ListToReturn = new List<MetricViewModel>();  
            
            MySqlConnection myConnectionServices = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionReferenceMetrics = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionReferenceTests = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionMetrics = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionTests = new MySqlConnection(configuration["connectionString"]);

            myConnectionServices.Open();
            myConnectionMetrics.Open();
            myConnectionTests.Open();
            myConnectionReferenceMetrics.Open();
            myConnectionReferenceTests.Open();


            string queryServices = "SELECT ServiceID, ServiceName, DirectionName, DirectionteamName FROM serviceinformation se, teamdirection te, direction di where se.DirectionTeamID = te.DirectionTeamID and te.DirectionID = di.DirectionID";
            MySqlCommand commandServices = new MySqlCommand(queryServices, myConnectionServices);

            string queryMetrics = null;
            string queryTests = null;
            reader = commandServices.ExecuteReader();

            while (reader.Read())
            {


                string referenceMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 1";
                string referenceTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 1";


                TmpObject Object = new TmpObject();

                switch (choice)
                {
                    case "une semaine":
                        queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 1,1";
                        queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 1,1";
                        break;

                    case "deux semaines":
                        queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 2,1";
                        queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 2,1";
                        break;

                    case "un mois":
                        queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 4,1";
                        queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 4,1";
                        break;

                    case "un trimestre":
                        queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 12,1";
                        queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 12,1";
                        break;

                    default:
                        queryMetrics = "select * from servicemetrics where ServiceID = @ServiceID order by InterrogationDate DESC limit 1,1";
                        queryTests = "SELECT * FROM servicebuild where ServiceID=@ServiceID and (result = 'succeeded' or result = 'partiallySucceeded') and BuildName LIKE 'Sonar_%' order by FinishTime DESC limit 1,1";
                        break;

                }

                

                MySqlCommand commandMetrics = new MySqlCommand(queryMetrics, myConnectionMetrics);
                MySqlCommand commandTests = new MySqlCommand(queryTests, myConnectionTests);
                MySqlCommand commandReferenceMetrics = new MySqlCommand(referenceMetrics, myConnectionReferenceMetrics);
                MySqlCommand commandReferenceTests = new MySqlCommand(referenceTests, myConnectionReferenceTests);

                commandMetrics.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));
                commandReferenceMetrics.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));
                commandReferenceTests.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));
                commandTests.Parameters.AddWithValue("@ServiceID", reader.GetInt32(0));

                DbDataReader readerMetrics = commandMetrics.ExecuteReader();
                DbDataReader readerReferenceMetrics = commandReferenceMetrics.ExecuteReader();
                DbDataReader readerReferenceTests= commandReferenceTests.ExecuteReader();
                DbDataReader readerTests = commandTests.ExecuteReader();

                if (readerMetrics.Read() && readerReferenceMetrics.Read())
                {                   
                    Object.Metrics.Add(FillObject(readerReferenceMetrics, readerReferenceTests, reader));
                    Object.Metrics.Add(FillObject(readerMetrics, readerTests,reader));

                }
                                                                
                readerMetrics.Dispose();
                readerTests.Dispose();
                readerReferenceMetrics.Dispose();
                readerReferenceTests.Dispose();

                if (Object.Metrics.Count != 0)
                {
                    Objects.Add(Object);
                }
                

            }


            foreach (TmpObject ob in Objects)
            {
                ob.MetricsToShow.ServiceProfile = ob.Metrics[0].ServiceProfile;
                ob.MetricsToShow.ServiceName = ob.Metrics[0].ServiceName;
                ob.MetricsToShow.DirectionName = ob.Metrics[0].DirectionName;
                ob.MetricsToShow.TeamName = ob.Metrics[0].TeamName;
                ob.MetricsToShow.NumberBugs = ob.Metrics[0].NumberBugs - ob.Metrics[1].NumberBugs;
                ob.MetricsToShow.NumberVulnerabilities = ob.Metrics[0].NumberVulnerabilities - ob.Metrics[1].NumberVulnerabilities;
                ob.MetricsToShow.NumberCodeSmells = ob.Metrics[0].NumberCodeSmells - ob.Metrics[1].NumberCodeSmells;
                ob.MetricsToShow.Coverage = ob.Metrics[0].Coverage - ob.Metrics[1].Coverage;
                ob.MetricsToShow.Duplication = ob.Metrics[0].Duplication - ob.Metrics[1].Duplication;
                ob.MetricsToShow.Size = ob.Metrics[0].Size - ob.Metrics[1].Size;
                ob.MetricsToShow.Complexity = ob.Metrics[0].Complexity - ob.Metrics[1].Complexity;
                ob.MetricsToShow.Documentation = ob.Metrics[0].Documentation - ob.Metrics[1].Documentation;
                ob.MetricsToShow.PassedTests = ob.Metrics[0].PassedTests - ob.Metrics[1].PassedTests;
                ob.MetricsToShow.TotalTests = ob.Metrics[0].TotalTests - ob.Metrics[1].TotalTests;

                ListToReturn.Add(ob.MetricsToShow);
            }


            return ListToReturn;


        }

        private static MetricViewModel FillObject(DbDataReader reader, DbDataReader readerTest, DbDataReader readerService )
        {
            MetricViewModel Servicemetrics = new MetricViewModel();
            Servicemetrics.ServiceProfile = reader.GetString(2);
            Servicemetrics.NumberBugs = reader.GetInt32(3);
            Servicemetrics.NumberVulnerabilities = reader.GetInt32(4);
            Servicemetrics.NumberCodeSmells = reader.GetInt32(5);
            Servicemetrics.Coverage = reader.GetDecimal(6);
            Servicemetrics.Duplication = reader.GetDecimal(7);
            Servicemetrics.Size = reader.GetInt32(8);
            Servicemetrics.Complexity = reader.GetInt32(9);
            Servicemetrics.Documentation = reader.GetDecimal(10);
            Servicemetrics.ServiceName = readerService.GetString(1);
            Servicemetrics.DirectionName = readerService.GetString(2);
            Servicemetrics.TeamName = readerService.GetString(3);

            if (readerTest.Read())
            {
                if (!readerTest.IsDBNull(8))
                {
                    Servicemetrics.PassedTests = readerTest.GetInt32(8);
                }

                if (!readerTest.IsDBNull(6))
                {
                    Servicemetrics.TotalTests = readerTest.GetInt32(6);
                }
            }
          

            return Servicemetrics;

        }




    }
}
