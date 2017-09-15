using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Servicemetrics
    {
        public int ServiceMetricId { get; set; }
        public int? Complexity { get; set; }
        public decimal? Coverage { get; set; }
        public decimal? Documentation { get; set; }
        public decimal? Duplication { get; set; }
        public DateTime? InterrogationDate { get; set; }
        public int? NumberBugs { get; set; }
        public int? NumberCodeSmells { get; set; }
        public int? NumberVulnerabilities { get; set; }
        public int? ServiceId { get; set; }
        public string ServiceProfile { get; set; }
        public int? Size { get; set; }
    }
}
