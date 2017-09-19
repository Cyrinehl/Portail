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
    public static class DataFile
    {


        public static void InsertData(File File, MySqlConnection myConnection)
        {
       
            try
            {              
              
                string query = "INSERT IGNORE INTO file (FileKey, ServiceId)";
                query += " VALUES (@FileKey, @ServiceId)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@FileKey", File.FileKey);               
                myCommand.Parameters.AddWithValue("@ServiceId", File.ServiceId);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table file:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int GetFileInformation(string FileKey, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                int r = 0;
                string query = "SELECT FileID from file WHERE FileKey =@FileKey";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@FileKey", FileKey);
                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToInt32(result);
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting File from table file:" + e.Message + "\t" + e.GetType();
                return 0;
            }



        }

        public static void updateFile(MySqlConnection myConnection, int ServiceID, string FileKey)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                string query = "UPDATE file SET ServiceID=@ServiceID WHERE FileKey=@FileKey";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceID", ServiceID);           
                myCommand.Parameters.AddWithValue("@FileKey", FileKey);
               

                object result = myCommand.ExecuteScalar();


            }
            catch (Exception e)
            {
                string error = "Exception Occre while updating table file:" + e.Message + "\t" + e.GetType();

            }
        }


        public static int CountTableRows(MySqlConnection myConnection)
        {
            try
            {
                int r = -1;
                string query = "SELECT COUNT(*) FROM file";
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
                string error = "Exception Occre while selecting from table file:" + e.Message + "\t" + e.GetType();
                return -1;
            }

        }


        public static string GetFilekey(int FileID, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                string r = null;
                string query = "SELECT FileKey from file WHERE FileID =@FileID";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@FileID", FileID);
                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToString(result);
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting File from table:" + e.Message + "\t" + e.GetType();
                return null;
            }



        }

        public static void FileUpdate(IConfigurationRoot configuration)
        {
            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();
            MySqlConnection myConnectionf = new MySqlConnection(configuration["connectionString"]);
            myConnectionf.Open();


            string queryServices = "SELECT * FROM developper.file";

            MySqlCommand command = new MySqlCommand(queryServices, myConnection);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string GetKey = reader.GetString(2);
                if (GetKey.StartsWith("Service/Services/"))
                {
                    string ServiceName = GetKey.Replace("Service/Services/", "");
                    int index = ServiceName.IndexOf('/');
                    if (index != -1)
                    {
                        ServiceName = ServiceName.Substring(0, index);
                        ServiceName = ServiceName + " Dev";

                        int serviceId = DataServiceInformation.GetServiceInformation(ServiceName, myConnectionf);
                        string queryFile = "UPDATE file SET ServiceID=@ServiceID WHERE FileKey=@FileKey";

                        MySqlCommand commandMetrics = new MySqlCommand(queryFile, myConnectionf);
                        commandMetrics.Parameters.AddWithValue("@ServiceID", serviceId);
                        commandMetrics.Parameters.AddWithValue("@FileKey", GetKey);

                        if (serviceId != -1 && serviceId != 0)
                        {
                            object result = commandMetrics.ExecuteScalar();
                        }
                       
                    }

                }

            }
        }



    }
}
