using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class DataCodeReviewRequest
    {

        public static void InsertData(Codereviewrequest Codereviewrequest, MySqlConnection myConnection)
        {
          
            try
            {
              
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                string query = "INSERT IGNORE INTO codereviewrequest (CodeReviewRequestID, CreatedDate, ClosedDate, ChangedDate, CreatedBy, ClosedBy, Title, State, ContexteType, CodeReviewClosedStatus, CodeReviewContext )";
                query += " VALUES (@CodeReviewRequestID, @CreatedDate, @ClosedDate, @ChangedDate, @CreatedBy, @ClosedBy, @Title, @State, @ContexteType, @CodeReviewClosedStatus, @CodeReviewContext)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestID", Codereviewrequest.CodeReviewRequestId);
                myCommand.Parameters.AddWithValue("@CreatedDate", Codereviewrequest.CreatedDate);
                myCommand.Parameters.AddWithValue("@ClosedDate", Codereviewrequest.ClosedDate);
                myCommand.Parameters.AddWithValue("@ChangedDate", Codereviewrequest.ChangedDate);
                myCommand.Parameters.AddWithValue("@CreatedBy", Codereviewrequest.CreatedBy);
                myCommand.Parameters.AddWithValue("@ClosedBy", Codereviewrequest.ClosedBy);
                myCommand.Parameters.AddWithValue("@Title", Codereviewrequest.Title);
                myCommand.Parameters.AddWithValue("@State", Codereviewrequest.State);
                myCommand.Parameters.AddWithValue("@ContexteType", Codereviewrequest.ContexteType);
                myCommand.Parameters.AddWithValue("@CodeReviewContext", Codereviewrequest.Context);
                myCommand.Parameters.AddWithValue("@CodeReviewClosedStatus", Codereviewrequest.CodeReviewClosedStatus);


                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }


        public static int ExistsCodeReview(int CodeReviewRequestID, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                int r = 0;
                string query = "SELECT * from codereviewrequest WHERE CodeReviewRequestID =@CodeReviewRequestID";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestID", CodeReviewRequestID);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = Convert.ToInt32(result);
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table:" + e.Message + "\t" + e.GetType();
                return 0;
            }



        }

        public static void UpdateCodeReview(int CodeReviewRequestID, Codereviewrequest Codereviewrequest, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
             
                string query = "UPDATE codereviewrequest SET ClosedDate=@ClosedDate, ChangedDate=@ChangedDate, State=@State, ClosedBy=@ClosedBy, CodeReviewClosedStatus=@CodeReviewClosedStatus WHERE CodeReviewRequestID = @CodeReviewRequestID";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@CodeReviewRequestID", CodeReviewRequestID);              
               
                myCommand.Parameters.AddWithValue("@ClosedDate", Codereviewrequest.ClosedDate);
                myCommand.Parameters.AddWithValue("@ChangedDate", Codereviewrequest.ChangedDate);              
                myCommand.Parameters.AddWithValue("@ClosedBy", Codereviewrequest.ClosedBy);             
                myCommand.Parameters.AddWithValue("@State", Codereviewrequest.State);             
                myCommand.Parameters.AddWithValue("@CodeReviewClosedStatus", Codereviewrequest.CodeReviewClosedStatus);



                object result = myCommand.ExecuteScalar();
                            

            }
            catch (Exception e)
            {
                string error = "Exception Occre while updating from table:" + e.Message + "\t" + e.GetType();
              
            }



        }

    }
}
