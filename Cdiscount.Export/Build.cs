using System;

namespace Cdiscount.Export
{
    public class Build
    {
        public string buildKey { get; set; }
        public string buildName { get; set; }
        public string ProfileName { get; set; }
        public string commentLinesDensity { get; set; }
        public string numberBug { get; set; }
        public string numberVulnerabilities { get; set; }
        public string numberCodeSmells { get; set; }
        public string coverage { get; set; }
        public string duplication { get; set; }
        public string size { get; set; }
        public string securityRating { get; set; }
        public string sqaleRating { get; set; }

        public string reliabilityRating { get; set; }
        public string complexity { get; set; }

        public string Totaltests { get; set; }    

       public string IncompleteTests { get; set; }
        public string NotApplicableTests { get; set; }   
        
        public string PassedTests { get; set; }    
        
        public string UnanalyzedTests { get; set; }




    }


    
}
