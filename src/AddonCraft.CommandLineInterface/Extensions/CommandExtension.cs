using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;
using System.Text.RegularExpressions;
using AddonCraft.CommandLineInterface.Exceptions;

namespace AddonCraft.CommandLineInterface.Extensions
{
    public static class CommandExtension
    {
        public static Command WithDefaultHandler(this Command command)
        {
            const String namespaceTemplate = "{0}.Handlers.{1}Handler";
            var baseNamespace = typeof(Program).Namespace;
            
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var symbolTitle = command.GetSymbolTitle();
            var type = Type.GetType(String.Format(namespaceTemplate, baseNamespace, symbolTitle));
            var method = type?.GetMethod(symbolTitle, bindingFlags) ?? throw new InvalidCommandMethodException();
 
            var commandHandler = CommandHandler.Create(method);
            command.Handler = commandHandler;
            
            return command;
        }

        public static String GetSymbolTitle(this ISymbol symbol)
        {
            const String pattern = @"-\w{1}|^\w";
            
            return Regex.Replace(symbol.Name, pattern, match => match.Value.Replace("-", String.Empty).ToUpperInvariant());
        }
    }
}