using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCore
{
   public class Profile
    {

        public string profileKey { get; set; }
        public string ProfileName { get; set; }
        public List<service> profileServices = new List<service>();

    }
}
