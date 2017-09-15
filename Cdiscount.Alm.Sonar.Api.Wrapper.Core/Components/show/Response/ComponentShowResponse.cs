using System;
using System.Collections.Generic;
using System.Text;

namespace Cdiscount.Alm.Sonar.Api.Wrapper.Core.Components.show.Response
{
    public class ComponentShowResponse
    {
        public Component Component { get; set; }

        public List<Component> Ancestors { get; set; }

    }
}
