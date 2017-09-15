using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Changeset
    {
        public Changeset()
        {
            Changesetfile = new HashSet<Changesetfile>();
        }

        public int ChangesetId { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DevelopperId { get; set; }

        public virtual ICollection<Changesetfile> Changesetfile { get; set; }
        public virtual Developper Developper { get; set; }
    }
}
