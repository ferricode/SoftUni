using SOLID.Appenders;
using SOLID.Core;
using SOLID.Core.Factories;
using SOLID.Core.IO;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;

namespace SOLID
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //// //ILayout simpleLayout = new SimpleLayout();
            //// //IAppender consoleAppender =
            //// //new FileAppender(simpleLayout);
            //// //ILogger logger = new Logger(consoleAppender);

            //// //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //// //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //// var layout = new XmlLayout();
            ////// var simpleLayout = new SimpleLayout();
            //// var consoleAppender = new ConsoleAppender(layout);

            //// var file = new LogFile();
            //// var fileAppender = new FileAppender(layout, file);

            //// var logger = new Logger(consoleAppender, fileAppender);
            //// //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //// //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //// logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            ////logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            //var simpleLayout = new JsonLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            IAppenderFactory appenderFactory = new AppenderFactory();
            ILayoutFactory layoutFactory = new LayoutFactory();
            IReader reader = new FileReader();

            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);

            engine.Run();


        }
    }
}