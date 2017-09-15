using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Userteam
    {
        public int TeamId { get; set; }
        public int DevelopperId { get; set; }

        public virtual Developper Developper { get; set; }
        public virtual Team Team { get; set; }
    }
}
