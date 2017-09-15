using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace DataAccess.Insert
{
    public static class DataChangesetFile
    {

        public static void InsertData(IConfigurationRoot configuration, Changesetfile Changesetfile, MySqlConnection myConnection)
        {

            
            try
            {
                
                ConnectionState State = myConnection.State;
                string query = "INSERT INTO changesetfile (ChangesetId, FileId)";
                query += " VALUES (@ChangesetId, @FileId)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ChangesetId", Changesetfile.ChangesetId);             
                myCommand.Parameters.AddWithValue("@FileId", Changesetfile.FileId);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int Exist(int FileID, int ChangesetID, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                int r = 0;

                string query = "SELECT * from changesetfile WHERE changesetID =@changesetID and FileID=@FileID ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@changesetID", ChangesetID);
                myCommand.Parameters.AddWithValue("@FileID", FileID);

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




    }

}
