using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Team
    {
        public Team()
        {
            Userteam = new HashSet<Userteam>();
        }

        public int TeamId { get; set; }
        public int? ManagerActiveDirectoryId { get; set; }
        public string TeamName { get; set; }

        public virtual ICollection<Userteam> Userteam { get; set; }
    }
}
