using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Developper
    {
        public Developper()
        {
            Changeset = new HashSet<Changeset>();
            CodereviewrequestClosedByNavigation = new HashSet<Codereviewrequest>();
            CodereviewrequestCreatedByNavigation = new HashSet<Codereviewrequest>();
            CodereviewresponseClosedByNavigation = new HashSet<Codereviewresponse>();
            CodereviewresponseReviewedByNavigation = new HashSet<Codereviewresponse>();
            Comment = new HashSet<Comment>();
            Event = new HashSet<Event>();
            Issue = new HashSet<Issue>();
            Servicebuild = new HashSet<Servicebuild>();
            Userteam = new HashSet<Userteam>();
        }

        public int DevelopperId { get; set; }
        public string Email { get; set; }
        public DateTime? EndDate { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual ICollection<Changeset> Changeset { get; set; }
        public virtual ICollection<Codereviewrequest> CodereviewrequestClosedByNavigation { get; set; }
        public virtual ICollection<Codereviewrequest> CodereviewrequestCreatedByNavigation { get; set; }
        public virtual ICollection<Codereviewresponse> CodereviewresponseClosedByNavigation { get; set; }
        public virtual ICollection<Codereviewresponse> CodereviewresponseReviewedByNavigation { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
        public virtual ICollection<Servicebuild> Servicebuild { get; set; }
        public virtual ICollection<Userteam> Userteam { get; set; }
    }
}
