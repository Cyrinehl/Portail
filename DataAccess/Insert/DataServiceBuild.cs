using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public static class DataServicesBuild
    {

        public static void InsertData(Servicebuild Servicesbuild, MySqlConnection myConnection)
        {
           
            try
            {
                             
                string query = "INSERT IGNORE INTO servicebuild (ServiceId, BuildName, DevelopperId, StartTime, FinishTime, IncompleteTests, NotApplicableTests, PassedTests, TotalTests, Result, UnanalyzedTests)";
                query += " VALUES (@ServiceId, @BuildName, @DevelopperId, @StartTime, @FinishTime, @IncompleteTests, @NotApplicableTests, @PassedTests, @TotalTests, @Result, @UnanalyzedTests)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceId", Servicesbuild.ServiceId);
                myCommand.Parameters.AddWithValue("@BuildName", Servicesbuild.BuildName);
                myCommand.Parameters.AddWithValue("@DevelopperId", Servicesbuild.DevelopperId);
                myCommand.Parameters.AddWithValue("@StartTime", Servicesbuild.StartTime);
                myCommand.Parameters.AddWithValue("@FinishTime", Servicesbuild.FinishTime);
                myCommand.Parameters.AddWithValue("@IncompleteTests", Servicesbuild.IncompleteTests);
                myCommand.Parameters.AddWithValue("@NotApplicableTests", Servicesbuild.NotApplicableTests);
                myCommand.Parameters.AddWithValue("@PassedTests", Servicesbuild.PassedTests);
                myCommand.Parameters.AddWithValue("@TotalTests", Servicesbuild.TotalTests);
                myCommand.Parameters.AddWithValue("@Result", Servicesbuild.Result);
                myCommand.Parameters.AddWithValue("@UnanalyzedTests", Servicesbuild.UnanalyzedTests);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table servicebuild:" + e.Message + "\t" + e.GetType();
            }


        }




    }
}
