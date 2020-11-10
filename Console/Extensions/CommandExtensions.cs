using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;

namespace Console.Extensions
{
    public static class CommandExtensions
    {
        /// <summary>
        /// Attaches an handler to a command object
        /// </summary>
        /// <param name="command">The command to attach an handleer to</param>
        /// <param name="methodInfo">Details about the method to use for handler</param>
        /// <returns></returns>
        public static Command WithHandler(this Command command, MethodInfo methodInfo)
        { 
            var handler = CommandHandler.Create(methodInfo);
            command.Handler = handler;

            return command;
        }
    }
}
