using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Servicebuild
    {
        public string BuildName { get; set; }
        public int? DevelopperId { get; set; }
        public DateTime? FinishTime { get; set; }
        public int? IncompleteTests { get; set; }
        public int? NotApplicableTests { get; set; }
        public int? PassedTests { get; set; }
        public string Result { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? StartTime { get; set; }
        public int? TotalTests { get; set; }
        public int? UnanalyzedTests { get; set; }

        public virtual Developper Developper { get; set; }
    }
}
