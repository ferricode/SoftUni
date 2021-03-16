using SOLID.Appenders;
using SOLID.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Error(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Error, message);
        }

        public void Info(string date, string message)
        {
            this.appender.Append(date, ReportLevel.Info, message);
        }
    }
}
