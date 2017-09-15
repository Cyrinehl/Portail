using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace DataAccess.Insert
{
    class dataEvent
    {

        public static void InsertData( Event Event, MySqlConnection myConnection)
        {
         
            try
            {
              
                string query = "INSERT INTO event (DevelopperId, Description)";
                query += " VALUES (@DevelopperId, @Description)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@DevelopperId", Event.DevelopperId);
                myCommand.Parameters.AddWithValue("@Description", Event.Description);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table event:" + e.Message + "\t" + e.GetType();
            }


        }


    }
}
