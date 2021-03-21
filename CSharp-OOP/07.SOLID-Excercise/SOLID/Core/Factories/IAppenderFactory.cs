using SOLID.Appenders;
using SOLID.Enums;
using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core.Factories
{
   public  interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout,ReportLevel reportLevel );
    }
}
