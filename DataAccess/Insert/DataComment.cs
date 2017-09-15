using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class DataComment
    {

        public static void InsertData(Comment Comment, MySqlConnection myConnection)
        {
          
            try
            {               
               
                string query = "INSERT INTO comment (CodeReviewRequestId, Comment, DevelopperId, FileId, ParentId, PublishDate)";
                query += " VALUES (@CodeReviewRequestId, @Comment, @DevelopperId, @FileId, @ParentId, @PublishDate)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestId", Comment.CodeReviewRequestId);
                myCommand.Parameters.AddWithValue("@Comment", Comment.Content);
                myCommand.Parameters.AddWithValue("@DevelopperId", Comment.DevelopperId);
                myCommand.Parameters.AddWithValue("@FileId", Comment.FileId);
                myCommand.Parameters.AddWithValue("@ParentId", Comment.ParentId);
                myCommand.Parameters.AddWithValue("@PublishDate", Comment.PublishDate);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table comment:" + e.Message + "\t" + e.GetType();
            }

        }

        public static int GetLastID(MySqlConnection myConnection)
        {
            try
            {
                int r = 0;
                ConnectionState State = myConnection.State;
                string query = "SELECT LAST_INSERT_ID()";

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
                string error = "Exception Occre while getting last inserted ID:" + e.Message + "\t" + e.GetType();
                return 0;

            }

        }

        public static int CountRows(MySqlConnection myConnection)
        {
            try
            {
                int r = -1;
                ConnectionState State = myConnection.State;
                string query = "SELECT COUNT(*) FROM comment";

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
                string error = "Exception Occre while counting rows:" + e.Message + "\t" + e.GetType();
                return -1;

            }
        }


        public static void DeleteComments(int CodeReviewRequestID, MySqlConnection myConnection)
        {
            try
            {
                              
                string query = "Delete FROM comment where CodeReviewRequestId = @CodeReviewRequestId ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestId", CodeReviewRequestID);

                int row = myCommand.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                string error = "Exception Occre while deleting comments:" + e.Message + "\t" + e.GetType();               
            }
        }


    }
}
