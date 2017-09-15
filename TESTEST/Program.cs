using System;
using Cdiscount.Export;
using Microsoft.Extensions.Configuration;
using System.IO;
using DataAccess.Insert;
using System.Collections.Generic;

namespace TESTEST
{
    class Program
    {
        static void Main(string[] args)
        {

            IConfigurationRoot configuration = GetConfig();

            //TreatCodeReview.GenerateExcel(configuration);
            List<MetricViewModel>  models = DataServiceMetrics.GetLastestMetrics(configuration);

            string fini = "fini";
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