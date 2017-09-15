using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Serviceinformation
    {
        public Serviceinformation()
        {
            File = new HashSet<File>();
            Servicebuild = new HashSet<Servicebuild>();
            Servicemetrics = new HashSet<Servicemetrics>();
        }

        public int ServiceId { get; set; }
        public int? DirectionTeamId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceSonarKey { get; set; }
        public string ServiceTfsKey { get; set; }

        public virtual ICollection<File> File { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual ICollection<Servicebuild> Servicebuild { get; set; }
        public virtual ICollection<Servicemetrics> Servicemetrics { get; set; }
        public virtual Teamdirection DirectionTeam { get; set; }
    }
}
