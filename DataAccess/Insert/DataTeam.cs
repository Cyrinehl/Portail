using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    class DataTeam
    {

        public static void InsertData(Team Team, MySqlConnection myConnection)
        {
           
            try
            {               
                string query = "INSERT INTO team (ManagerActiveDirectoryId, TeamName)";
                query += " VALUES (@ManagerActiveDirectoryId, @TeamName)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ManagerActiveDirectoryId", Team.ManagerActiveDirectoryId);
                myCommand.Parameters.AddWithValue("@TeamName", Team.TeamName);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table team :" + e.Message + "\t" + e.GetType();
            }


        }



    }
}
