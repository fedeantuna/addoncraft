using System;
using System.Diagnostics.CodeAnalysis;

namespace AddonCraft.CommandLineInterface.Exceptions
{
    // ExcludeFromCodeCoverage: There is no value in testing this.
    [ExcludeFromCodeCoverage]
    public class InvalidCommandMethodException : Exception
    {
        private const String InvalidCommandMethodExceptionMessage = "The command title does not match with any method";
        
        public InvalidCommandMethodException()
            : base(InvalidCommandMethodExceptionMessage)
        {
        }
    }
}