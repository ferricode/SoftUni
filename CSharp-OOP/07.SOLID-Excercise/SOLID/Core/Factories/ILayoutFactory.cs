using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core.Factories
{
   public  interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
