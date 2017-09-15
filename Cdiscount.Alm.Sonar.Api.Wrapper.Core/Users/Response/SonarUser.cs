using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Response
{
    public class SonarUser: SonarUserBase
    {
        /// <summary>
        /// email of the user
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// is user active
        /// </summary>
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }
    }
}