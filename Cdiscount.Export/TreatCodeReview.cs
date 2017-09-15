using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace Cdiscount.Export
{
    public class TreatCodeReview
    {
        public static List<CodeReviewExport> CodeReviewChangeset = new List<CodeReviewExport>();
        private const string generalFile = @"C:\Users\cyrine.hlioui\Desktop\CodeReviewChangeset.csv";



        public static void GenerateExcel(IConfigurationRoot configuration)
        {
            TreatReview(configuration);
            Treat();
            Console.WriteLine("Excel SILO Code Review DONE !!");
            
        }








        public static void TreatReview(IConfigurationRoot configuration)
        {
            MySqlConnection myConnection = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionReview = new MySqlConnection(configuration["connectionString"]);
            MySqlConnection myConnectionChangeset = new MySqlConnection(configuration["connectionString"]);
            myConnection.Open();
            myConnectionReview.Open();
            myConnectionChangeset.Open();


            DbDataReader reader = null;
            string query = "SELECT * FROM file";

            MySqlCommand command = new MySqlCommand(query, myConnection);
           
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                CodeReviewExport CodeReviewExport = new CodeReviewExport();

                int FileID = reader.GetInt32(0);
               

                string queryChangeset = "SELECT count(*) FROM changesetfile join changeset cs on cs.ChangesetID = changesetfile.changesetID where cs.CreatedDate >= '2017-09-01' and changesetfile.FileID =  @FileID";
                //string queryCodeReview = "SELECT count(distinct CodeReviewRequestID) FROM comment where  FileID = @FileID and PublishDate >= '2017-08-22' ";
                string queryCodeReview = "SELECT count(*) FROM shelvesetfile join shelveset cs on cs.ShelvesetID = shelvesetfile.ShelvesetID where cs.CreatedDate >= '2017-09-01' and shelvesetfile.FileID = @FileID ";


                MySqlCommand commandChangeset = new MySqlCommand(queryChangeset, myConnectionChangeset);
                MySqlCommand commandCodeReview = new MySqlCommand(queryCodeReview, myConnectionReview);

                commandChangeset.Parameters.AddWithValue("@FileID", FileID);              
                commandCodeReview.Parameters.AddWithValue("@FileID", FileID);


                object resultChangeset = commandChangeset.ExecuteScalar();
                object resultCodeReview = commandCodeReview.ExecuteScalar();

                if (resultChangeset != null)
                {                  

                    CodeReviewExport.fileName = reader.GetString(2);
                    CodeReviewExport.NbChangeset = Convert.ToString(resultChangeset);
                }

                if (resultCodeReview != null)
                {
                    CodeReviewExport.NbCodeReview = Convert.ToString(resultCodeReview);
                }

                if (Int32.Parse(CodeReviewExport.NbChangeset) != 0 || Int32.Parse(CodeReviewExport.NbCodeReview) != 0)
                {
                    CodeReviewChangeset.Add(CodeReviewExport);
                }
               


            }
            reader.Dispose();


        }


        public static void AddTitles()
        {
            CodeReviewExport CodeReviewExport = new CodeReviewExport();
            CodeReviewExport.fileName = "FileName";
            CodeReviewExport.NbChangeset = "NbChangesets";
            CodeReviewExport.NbCodeReview = "NbCodeReview";


            CodeReviewChangeset.Insert(0, CodeReviewExport);


        }

        public static void Treat()
        {
            AddTitles();
            GenerateFile(CodeReviewChangeset.Select(r => $"{r.fileName};{r.NbChangeset};{r.NbCodeReview}"));
        }

        public static void GenerateFile(IEnumerable<string> lines)
        {
            try
            {
                File.Delete(generalFile);
                File.WriteAllLines(generalFile, lines);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem during file generation.");
            }
        }
    }
}
