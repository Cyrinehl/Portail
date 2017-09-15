using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Insert
{
    class DataUserTeam
    {
        public static void InsertData(IConfigurationRoot configuration, Userteam Userteam)
        {

            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            try
            {
                myConnection.Open();
                ConnectionState State = myConnection.State;
                string query = "INSERT INTO userteam (TeamId, DevelopperId)";
                query += " VALUES (@TeamId, @DevelopperId)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@TeamId", Userteam.TeamId);
                myCommand.Parameters.AddWithValue("@DevelopperId", Userteam.DevelopperId);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }


    }
}
