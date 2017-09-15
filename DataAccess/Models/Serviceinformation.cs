using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Serviceinformation
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int? DirectionTeamId { get; set; }
        public string ServiceSonarKey { get; set; }
        public string ServiceTfsKey { get; set; }

        public virtual Teamdirection DirectionTeam { get; set; }
    }
}
