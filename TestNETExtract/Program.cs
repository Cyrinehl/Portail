using System;
using System.Collections.Generic;
using NETExtractComments;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TestNETExtract
{
    class Program
    {
        static void Main(string[] args)
        {

            //int Id = 1292500;
            //IConfigurationRoot configuration = GetConfig();

            //List<CodeReviewComment> comments = ExtractCrComments.CountComments(Id, configuration);


        }


        public static IConfigurationRoot GetConfig()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .Build();

            return configuration;
        }
    }
}