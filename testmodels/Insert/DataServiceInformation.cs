using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;

namespace DataAccess.Insert
{
     static public class DataServiceInformation
    {

        public static void InsertData(IConfigurationRoot configuration, Serviceinformation Serviceinformation,MySqlConnection myConnection)
        {


            
            try
            {                
                ConnectionState State = myConnection.State;
                string query = "INSERT IGNORE INTO serviceinformation (ServiceTfsKey, ServiceSonarKey, ServiceName)";
                query += " VALUES (@ServiceTfsKey, @ServiceSonarKey, @ServiceName) ";

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceTfsKey", Serviceinformation.ServiceTfsKey);
                myCommand.Parameters.AddWithValue("@ServiceSonarKey", Serviceinformation.ServiceSonarKey);
                myCommand.Parameters.AddWithValue("@ServiceName", Serviceinformation.ServiceName);
                int row = myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
            }


        }

        public static int GetServiceInformation(IConfigurationRoot configuration, string ServiceName, MySqlConnection myConnection)
        {
            
            try
            {
                int ServiceID = 0;

                string query = "SELECT ServiceID from serviceinformation WHERE ServiceName =@ServiceName" ;

                MySqlCommand myCommand = new MySqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@ServiceName", ServiceName);
                object result = myCommand.ExecuteScalar();

        
                if (result != null)
                {
                    ServiceID = Convert.ToInt32(result);

                }
                return ServiceID;

            }
            catch (Exception e)
            {

                string error = "Exception Occre while Inserting in table:" + e.Message + "\t" + e.GetType();
                return -1;
            }



        } 


    }
}
