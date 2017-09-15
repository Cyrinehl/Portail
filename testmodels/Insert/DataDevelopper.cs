using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class DataDevelopper
    {
        public static void InsertData(IConfigurationRoot configuration, Developper Developper, MySqlConnection myConnection)
        {
           
            try
            {
                               
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                string query = "INSERT IGNORE INTO developper (Email, StartDate, EndDate, Login, Name)";
                query += " VALUES (@Email, @StartDate, @EndDate, @Login, @Name)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@Email", Developper.Email);
                myCommand.Parameters.AddWithValue("@StartDate", Developper.StartDate);
                myCommand.Parameters.AddWithValue("@EndDate", Developper.EndDate);
                myCommand.Parameters.AddWithValue("@Login", Developper.Login);
                myCommand.Parameters.AddWithValue("@Name", Developper.Name);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int GetDevelopperInformation(IConfigurationRoot configuration, string DevelopperLogin, MySqlConnection myConnection)
        {

            try
            {
                ConnectionState State = myConnection.State;
                if (State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                int r = 0;
                string query = "SELECT DevelopperID from developper WHERE Login =@Login";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@Login", DevelopperLogin);

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



    }
}
