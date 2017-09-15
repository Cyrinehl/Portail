using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Teamdirection
    {
        public Teamdirection()
        {
            Serviceinformation = new HashSet<Serviceinformation>();
        }

        public int DirectionTeamId { get; set; }
        public int? DirectionId { get; set; }
        public string DirectionteamName { get; set; }

        public virtual ICollection<Serviceinformation> Serviceinformation { get; set; }
        public virtual Direction Direction { get; set; }
    }
}
