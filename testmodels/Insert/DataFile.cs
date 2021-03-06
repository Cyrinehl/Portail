﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public static class DataFile
    {


        public static void InsertData(IConfigurationRoot configuration, File File, MySqlConnection myConnection)
        {

       
            try
            {              
                ConnectionState State = myConnection.State;
                string query = "INSERT IGNORE INTO file (FileKey, FilePath, ServiceId)";
                query += " VALUES (@FileKey, @FilePath, @ServiceId)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@FileKey", File.FileKey);
                myCommand.Parameters.AddWithValue("@FilePath", File.FilePath);
                myCommand.Parameters.AddWithValue("@ServiceId", File.ServiceId);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int GetFileInformation(IConfigurationRoot configuration, string FileKey, MySqlConnection myConnection)
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
                string error = "Exception Occre while selecting File from table:" + e.Message + "\t" + e.GetType();
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
                string error = "Exception Occre while updating from table:" + e.Message + "\t" + e.GetType();

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
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
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



    }
}
