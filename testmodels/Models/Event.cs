using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public int? DevelopperId { get; set; }

        public virtual Developper Developper { get; set; }
    }
}
