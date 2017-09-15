using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Changesetfile
    {
        public int ChangesetId { get; set; }
        public int FileId { get; set; }

        public virtual Changeset Changeset { get; set; }
        public virtual File File { get; set; }
    }
}
