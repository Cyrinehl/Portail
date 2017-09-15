using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Shelveset
    {
        public int ShelvesetId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShelvesetName { get; set; }
        public int ShelvesetOwner { get; set; }
        public int CodeReviewRequestID { get; set; }

        public virtual Developper ShelvesetOwnerNavigation { get; set; }
    }
}
