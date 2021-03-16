using SOLID.Enums;
using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date, reportLevel, message)+Environment.NewLine;

            File.AppendAllText("../../../log.txt", content);
        }
    }
}
