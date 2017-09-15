using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Codereviewrequest
    {
        public Codereviewrequest()
        {
            Comment = new HashSet<Comment>();
        }

        public int CodeReviewRequestId { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int? ClosedBy { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string CodeReviewClosedStatus { get; set; }
        public string ContexteType { get; set; }

        public string Context { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string State { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual Developper ClosedByNavigation { get; set; }
        public virtual Developper CreatedByNavigation { get; set; }
    }
}
