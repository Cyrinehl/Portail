using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class DataChangeset
    {


        public static void InsertData(IConfigurationRoot configuration, Changeset Changeset, MySqlConnection myConnection)
        {

            try
            {

                ConnectionState State = myConnection.State;
                string query = "INSERT IGNORE INTO changeset (ChangesetId, Comment, CreatedDate, DevelopperId, FileId)";
                query += " VALUES (@ChangesetId, @Comment, @CreatedDate, @DevelopperId, @FileId)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ChangesetId", Changeset.ChangesetId);
                myCommand.Parameters.AddWithValue("@Comment", Changeset.Comment);
                myCommand.Parameters.AddWithValue("@CreatedDate", Changeset.CreatedDate);
                myCommand.Parameters.AddWithValue("@DevelopperId", Changeset.DevelopperId);
                myCommand.Parameters.AddWithValue("@FileId", Changeset.FileId);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }


        public static int CheckEmpty(MySqlConnection myConnection)
        {
            try
            {
                int r = -1;               
                string query = "SELECT COUNT(*) FROM changeset"; 
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


        public static int GetLatestChangesetId(MySqlConnection myConnection)
        {
            try
            {
                int r = 0;
                string query = "SELECT max(ChangesetID) FROM changeset";
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


    }
}