using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace DataAccess.Insert
{
    public class DataCodeReviewResponse
    {



        public static void InsertData(IConfigurationRoot configuration, Codereviewresponse Codereviewresponse, MySqlConnection myConnection)
        {

           
            try
            {
               
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                string query = "INSERT INTO codereviewresponse (CodeReviewResponseID, ChangedDate, ClosedBy, ClosedDate, ClosedStatus, CodeReviewRequestId, CreatedDate, ReviewedBy, State, Title)";
                query += " VALUES (@CodeReviewResponseID, @ChangedDate, @ClosedBy, @ClosedDate, @ClosedStatus, @CodeReviewRequestId, @CreatedDate, @ReviewedBy, @State, @Title)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewResponseID", Codereviewresponse.CodeReviewResponseId);
                myCommand.Parameters.AddWithValue("@ChangedDate", Codereviewresponse.ChangedDate);
                myCommand.Parameters.AddWithValue("@ClosedBy", Codereviewresponse.ClosedBy);
                myCommand.Parameters.AddWithValue("@ClosedDate", Codereviewresponse.ClosedDate);
                myCommand.Parameters.AddWithValue("@ClosedStatus", Codereviewresponse.ClosedStatus);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestId", Codereviewresponse.CodeReviewRequestId);
                myCommand.Parameters.AddWithValue("@CreatedDate", Codereviewresponse.CreatedDate);
                myCommand.Parameters.AddWithValue("@ReviewedBy", Codereviewresponse.ReviewedBy);
                myCommand.Parameters.AddWithValue("@State", Codereviewresponse.State);
                myCommand.Parameters.AddWithValue("@Title", Codereviewresponse.Title);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }


        public static void UpdateCodeReview(IConfigurationRoot configuration, int CodeReviewResponseID, Codereviewresponse Codereviewresponse, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                string query = "UPDATE codereviewresponse SET ClosedDate=@ClosedDate, ChangedDate=@ChangedDate, State=@State, ClosedBy=@ClosedBy, ClosedStatus=@ClosedStatus WHERE CodeReviewResponseID = @CodeReviewResponseID";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewResponseID", CodeReviewResponseID);


                myCommand.Parameters.AddWithValue("@State", Codereviewresponse.State);
                myCommand.Parameters.AddWithValue("@ClosedDate", Codereviewresponse.ClosedDate);
                myCommand.Parameters.AddWithValue("@ChangedDate", Codereviewresponse.ChangedDate);
                myCommand.Parameters.AddWithValue("@ClosedStatus", Codereviewresponse.ClosedStatus);
                myCommand.Parameters.AddWithValue("@ClosedBy", Codereviewresponse.ClosedBy);
                              
                object result = myCommand.ExecuteScalar();


            }
            catch (Exception e)
            {
                string error = "Exception Occre while updating from table:" + e.Message + "\t" + e.GetType();

            }



        }




    }
}
