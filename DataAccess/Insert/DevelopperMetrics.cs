using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace DataAccess.Insert
{
    public class DevelopperMetrics
    {
        public List<IssueDevelopper> developpersIssues = new List<IssueDevelopper>();
        public int NbIssues { get; set; }

        public List<IssuesPerService> IssuesPerService = new List<IssuesPerService>();

        public List<ChangesetPerService> ChangesetPerService = new List<ChangesetPerService>();

        public int NbCodeReviewRequested { get; set; }
        public int NbComments { get; set; }

        public int NbChangesets { get; set; }

        public List<Build> Builds = new List<Build>();

        public int BuildFailed { get; set; }
        public int BuildSucceded { get; set; }
        public int BuildPartiallySuccedeed { get; set; }
        public int BuildCancelled { get; set; }
    }

}
