using DataAccess.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Insert
{
    public class DataShelvsetFile
    {



        public static void InsertData(Shelvesetfile Shelvesetfile, MySqlConnection myConnection)
        {

            try
            {
                
                string query = "INSERT INTO shelvesetfile (ShelvesetID, FileID)";
                query += " VALUES (@ShelevesetID, @FileID)";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ShelevesetID", Shelvesetfile.ShelevesetId);
                myCommand.Parameters.AddWithValue("@FileID", Shelvesetfile.FileId);

                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table shelvesetfile:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int Exist(int ShelvesetID, int FileID, MySqlConnection myConnection)
        {
            try
            {
                         
                int r = 0;

                string query = "SELECT * from shelvesetfile WHERE ShelvesetID =@ShelvesetID and FileID=@FileID ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ShelvesetID", ShelvesetID);
                myCommand.Parameters.AddWithValue("@FileID", FileID);

                object result = myCommand.ExecuteScalar();

                if (result != null)
                {
                    r = 1;
                }


                return r;

            }
            catch (Exception e)
            {
                string error = "Exception Occre while selecting from table shelvesetfile :" + e.Message + "\t" + e.GetType();
                return -1;
            }

        }






    }
}
