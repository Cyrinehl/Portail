using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
    public static class test
    {
        public static void InsertData(IConfigurationRoot configuration)
        {


            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            try
            {
                myConnection.Open();
                ConnectionState State = myConnection.State;
                string query = "INSERT INTO serviceinformation (ServiceTfsKey, ServiceSonarKey, ServiceName)";
                query += " VALUES (@ServiceTfsKey, @ServiceSonarKey, @ServiceName)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceTfsKey", "TFSKEEEEY" );
                myCommand.Parameters.AddWithValue("@ServiceSonarKey","SONAR KEEEEYY" );
                myCommand.Parameters.AddWithValue("@ServiceName", "NAAAAMEEE" );
                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }

    }
}
