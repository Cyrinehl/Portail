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


        public static void InsertData(Teamdirection Teamdirection, MySqlConnection myConnection)
        {            
            try
            {               
                string query = "INSERT INTO teamdirection (DirectionId, DirectionteamName)";
                query += " VALUES (@DirectionId, @DirectionteamName)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@DirectionId", Teamdirection.DirectionId);
                myCommand.Parameters.AddWithValue("@DirectionteamName", Teamdirection.DirectionteamName);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table teamdirection :" + e.Message + "\t" + e.GetType();
            }


        }


    }
}
