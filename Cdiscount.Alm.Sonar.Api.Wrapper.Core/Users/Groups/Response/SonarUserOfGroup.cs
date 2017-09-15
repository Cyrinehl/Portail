using Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Users.Groups.Response
{
    public class SonarUserOfGroup: SonarUserBase
    {
        /// <summary>
        /// is user selected
        /// </summary>
        [JsonProperty(PropertyName = "selected")]
        public bool Selected { get; set; }
    }
}