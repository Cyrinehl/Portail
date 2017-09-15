using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Issue
    {
        public string IssueId { get; set; }
        public string Type { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? DevelopperId { get; set; }
        public int? FileId { get; set; }
        public int? Line { get; set; }
        public string Resolved { get; set; }
        public string RuleKey { get; set; }
        public int? ServiceId { get; set; }
        public string Severity { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Developper Developper { get; set; }
        public virtual File File { get; set; }

        

    }
}
