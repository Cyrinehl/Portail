using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Export
{
    public class Profile
    {
        public string profileKey { get; set; }
        public string ProfileName { get; set; }
        public List<Build> profileBuilds = new List<Build>();
    }
}
