using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = input[0];

            string[] commandArgs = input.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new ArgumentException("Command not found");
            }

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;

            return commandInstance.Execute(commandArgs);
        }
    }
}
