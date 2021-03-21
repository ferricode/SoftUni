using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;


namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSufix = "Command";
        public ICommand CreateCommand(string commandType)
        {
           Type type= Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandType}{CommandSufix}");

            if (type==null)
            {
                throw new ArgumentException($"{commandType} is invalid command type");
            }

            ICommand instance =(ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
