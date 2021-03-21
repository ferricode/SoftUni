
using CommandPattern.Core;
using CommandPattern.Core.Contracts;


namespace CommandPattern
{
    public class StartUp
    {
        public static void Main()
        {
            //ICommandFactory commandFactory = new CommandFactory();

            //ICommand command = commandFactory.CreateCommand("Hello");

            //System.Console.WriteLine(command.Execute(new string[] {"Feride"}));
            
            
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
