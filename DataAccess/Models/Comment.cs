using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? CodeReviewRequestId { get; set; }
        public string Content { get; set; }
        public int? DevelopperId { get; set; }
        public int? FileId { get; set; }
        public int? ParentId { get; set; }
        public DateTime? PublishDate { get; set; }

        public virtual Codereviewrequest CodeReviewRequest { get; set; }
        public virtual Developper Developper { get; set; }
        public virtual File File { get; set; }
    }
}
