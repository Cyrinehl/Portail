using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    class DataTeamDirection
    {


        public static void InsertData(IConfigurationRoot configuration, Teamdirection Teamdirection)
        {

            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            try
            {
                myConnection.Open();
                ConnectionState State = myConnection.State;
                string query = "INSERT INTO teamdirection (DirectionId, DirectionteamName)";
                query += " VALUES (@DirectionId, @DirectionteamName)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@DirectionId", Teamdirection.DirectionId);
                myCommand.Parameters.AddWithValue("@DirectionteamName", Teamdirection.DirectionteamName);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }


    }
}
