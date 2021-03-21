using SOLID.Appenders;
using SOLID.Core.Factories;
using SOLID.Core.IO;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;
        private ILogger logger;
        private readonly IReader reader;
        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, IReader reader)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
            this.reader = reader;
        }

        public void Run()
        {
            

            int n = int.Parse(this.reader.ReadLine());

            IAppender[] appenders = ReadAppenders(n);

            this.logger = new Logger(appenders);

            string line = this.reader.ReadLine();
            while (line != "END")
            {
                string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                this.ProcessCommand(reportLevel, date, message);
                line = this.reader.ReadLine();
            }

            Console.WriteLine(logger);
        }

        private void ProcessCommand(object reportLevel, string date, string message)
        {
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    this.logger.Info(date, message);
                    break;
                case ReportLevel.Warning:
                    this.logger.Warning(date, message);
                    break;
                case ReportLevel.Error:
                    this.logger.Error(date, message);
                    break;
                case ReportLevel.Critical:
                    this.logger.Critical(date, message);
                    break;
                case ReportLevel.Fatal:
                    this.logger.Fatal(date, message);
                    break;
                default:
                    break;
            }
        }

        private IAppender[] ReadAppenders(int n)
        {
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appenderParts = this.reader.ReadLine()
                    .Split();

                string appenderType = appenderParts[0];
                string layoutType = appenderParts[1];
                ReportLevel reportLevel = appenderParts.Length == 3 ?
                    Enum.Parse<ReportLevel>(appenderParts[2], true)
                    : ReportLevel.Info;

                ILayout layout = this.layoutFactory.CreateLayout(layoutType);

                IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders[i] = appender;
            }
            return appenders;
        }

    }
}

