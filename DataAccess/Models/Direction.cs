using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Direction
    {
        public Direction()
        {
            Teamdirection = new HashSet<Teamdirection>();
        }

        public int DirectionId { get; set; }
        public string DirectionName { get; set; }

        public virtual ICollection<Teamdirection> Teamdirection { get; set; }
    }
}
