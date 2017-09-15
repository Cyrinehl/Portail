using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Insert
{
    public class MetricViewModel
    {
        public string ServiceName { get; set; }       
        public int? Complexity { get; set; }
        public decimal? Coverage { get; set; }
        public decimal? Documentation { get; set; }
        public decimal? Duplication { get; set; }        
        public int? NumberBugs { get; set; }
        public int? NumberCodeSmells { get; set; }
        public int? NumberVulnerabilities { get; set; }    
        public string ServiceProfile { get; set; }
        public int? Size { get; set; }
        public int PassedTests { get; set; }      
        public int TotalTests { get; set; }




    }
}
