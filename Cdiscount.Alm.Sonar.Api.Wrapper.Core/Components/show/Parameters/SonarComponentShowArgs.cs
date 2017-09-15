using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Parameters
{
    public class SonarComponentShowArgs
    {
      
        public string ComponentKey { get; set; }
        public string ComponentId { get; set; }

      

        public override string ToString()
        {
            var result = new StringBuilder();
           
            SonarHelpers.AppendUrl(result, "key", ComponentKey);
            SonarHelpers.AppendUrl(result, "id", ComponentId);
            
            return result.Length > 0 ? "?" + result : string.Empty;
        }
    }
}
