using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Layouts
{
    public class SimpleLayout : ILayout
    {
        string ILayout.Template => "{0} - {1} - {2}";
    }
}
