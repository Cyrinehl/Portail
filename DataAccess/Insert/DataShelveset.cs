using DataAccess.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Insert
{
    public class DataShelveset
    {

        public static void InsertData( Shelveset Shelveset, MySqlConnection myConnection)
        {

            try
            {
               
                string query = "INSERT IGNORE INTO shelveset (ShelvesetName, ShelvesetOwner, CreatedDate, Comment, CodeReviewRequestID)";
                query += " VALUES (@ShelvesetName, @ShelvesetOwner, @CreatedDate, @Comment, @CodeReviewRequestID)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ShelvesetName", Shelveset.ShelvesetName);
                myCommand.Parameters.AddWithValue("@ShelvesetOwner", Shelveset.ShelvesetOwner);
                myCommand.Parameters.AddWithValue("@CreatedDate", Shelveset.CreatedDate);
                myCommand.Parameters.AddWithValue("@Comment", Shelveset.Comment);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestID", Shelveset.CodeReviewRequestID);


                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table shelveset :" + e.Message + "\t" + e.GetType();
            }


        }




        public static int Exist(string ShelvesetName, int ShelvesetOwner, MySqlConnection myConnection)
        {

            try
            { 
               int r = 0;

                string query = "SELECT * from shelveset WHERE ShelvesetName =@ShelvesetName and ShelvesetOwner=@ShelvesetOwner  ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ShelvesetName", ShelvesetName);
                myCommand.Parameters.AddWithValue("@ShelvesetOwner", ShelvesetOwner);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = 1;
                }

                return r;
            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table shelveset:" + e.Message + "\t" + e.GetType();
                return -1;
            }

        }



        public static int GetShelvesetId(string ShelvesetName, int Owner, MySqlConnection myConnection)
        {

            try
            {
               
                int r = 0;
                string query = "SELECT ShelvesetID from shelveset WHERE (ShelvesetName =@ShelvesetName and  ShelvesetOwner=@ShelvesetOwner )";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ShelvesetName", ShelvesetName);
                myCommand.Parameters.AddWithValue("@ShelvesetOwner", Owner);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToInt32(result);
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table shelveset:" + e.Message + "\t" + e.GetType();
                return 0;
            }



        }




    }
}
