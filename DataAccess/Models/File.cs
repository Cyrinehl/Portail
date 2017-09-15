using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class File
    {
        public File()
        {
            Changesetfile = new HashSet<Changesetfile>();
            Comment = new HashSet<Comment>();
            Issue = new HashSet<Issue>();
        }

        public int FileId { get; set; }
        public string FileKey { get; set; }
        public int? ServiceId { get; set; }

        public virtual ICollection<Changesetfile> Changesetfile { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
    }
}
