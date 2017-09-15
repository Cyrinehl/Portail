using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Codereviewresponse
    {
        public int CodeReviewResponseId { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int? ClosedBy { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string ClosedStatus { get; set; }
        public int? CodeReviewRequestId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ReviewedBy { get; set; }
        public string State { get; set; }
        public string Title { get; set; }

        public virtual Developper ClosedByNavigation { get; set; }
        public virtual Developper ReviewedByNavigation { get; set; }
    }
}
