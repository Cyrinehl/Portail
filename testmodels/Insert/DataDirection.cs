using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace DataAccess.Insert
{
    class DataDirection
    {
        public static void InsertData(IConfigurationRoot configuration, Direction Direction)
        {

            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            try
            {
                myConnection.Open();
                ConnectionState State = myConnection.State;
                string query = "INSERT INTO direction (DirectionName)";
                query += " VALUES (@DirectionName)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@DirectionName", Direction.DirectionName);
               
                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }

    }
}
