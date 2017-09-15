using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class File
    {
        public File()
        {
            Changeset = new HashSet<Changeset>();
            Changesetfile = new HashSet<Changesetfile>();
            Comment = new HashSet<Comment>();
            Issue = new HashSet<Issue>();
        }

        public int FileId { get; set; }
        public string FileKey { get; set; }
        public string FilePath { get; set; }
        public int? ServiceId { get; set; }

        public virtual ICollection<Changeset> Changeset { get; set; }
        public virtual ICollection<Changesetfile> Changesetfile { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
        public virtual Serviceinformation Service { get; set; }
    }
}
