using System.Globalization;
using System.IO;
using System.Threading;
using OnlineShop.Core;
using OnlineShop.IO;

namespace OnlineShop
{
    public class StartUp
    {

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
