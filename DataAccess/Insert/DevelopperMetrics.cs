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

    }

}
