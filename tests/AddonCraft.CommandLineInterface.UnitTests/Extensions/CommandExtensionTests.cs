using System;
using System.CommandLine;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.CommandLineInterface.Exceptions;
using AddonCraft.CommandLineInterface.Extensions;
using Xunit;

namespace AddonCraft.CommandLineInterface.UnitTests.Extensions
{
    [ExcludeFromCodeCoverage]
    public class CommandExtensionTests
    {
        [Fact]
        public void WithDefaultHandler_WhenHandlerExists_Returns_CommandWithHandler()
        {
            // Arrange
            const String commandName = "install";
            var command = new Command(commandName);
            
            // Act
            var result = command.WithDefaultHandler();
            
            // Assert
            Assert.NotNull(result.Handler);
        }
        
        [Fact]
        public void WithDefaultHandler_WhenHandlerDoesNotExists_Throws_InvalidCommandMethodException()
        {
            // Arrange
            const String commandName = "nonexistent-command";
            var command = new Command(commandName);
            
            // Act
            // Assert
            Assert.Throws<InvalidCommandMethodException>(() => command.WithDefaultHandler());
        }
        
        [Fact]
        public void GetSymbolTitle_Returns_NamePascalCased()
        {
            // Arrange
            const String commandName = "test-command";
            var command = new Command(commandName);
            const String expectedTitle = "TestCommand";
            
            // Act
            var result = command.GetSymbolTitle();
            
            // Assert
            Assert.Equal(expectedTitle, result);
        }
    }
}