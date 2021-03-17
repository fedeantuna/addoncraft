using System;
using System.Diagnostics.CodeAnalysis;
using AddonCraft.Application.Common.Models;
using Xunit;

namespace AddonCraft.Application.UnitTests.Common.Models
{
    [ExcludeFromCodeCoverage]
    public class ResultTests
    {
        private readonly String _messageA;
        private readonly String _messageB;
        private readonly String _messageC;
        private readonly String[] _messages;
        
        public ResultTests()
        {
            this._messageA = "Test Message A";
            this._messageB = "Test Message B";
            this._messageC = "Test Message C";
            this._messages = new[]
            {
                this._messageA,
                this._messageB,
                this._messageC
            };
        }
        
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WhenResultIsCreated_WithIsSuccessfulParameter_SetsIsSuccessfulToCorrespondingValue(Boolean isSuccessful)
        {
            // Arrange
            // Act
            var sut = new Result(isSuccessful);

            // Assert
            Assert.Equal(isSuccessful, sut.IsSuccessful);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WhenResultIsCreated_WithIsSuccessfulAndMessagesParameters_SetsIsSuccessfulAndMessagesToCorrespondingValues(Boolean isSuccessful)
        {
            // Arrange
            // Act
            var sut = new Result(isSuccessful, this._messages);

            // Assert
            Assert.Equal(isSuccessful, sut.IsSuccessful);
            Assert.Collection(sut.Messages,
                item => Assert.Equal(this._messageA, item),
                item => Assert.Equal(this._messageB, item),
                item => Assert.Equal(this._messageC, item));
        }

        [Fact]
        public void AddMessage_AddsAMessageToResult()
        {
            // Arrange
            var sut = new Result(true);

            // Act
            sut.AddMessage(this._messageA);

            // Assert
            Assert.Single(sut.Messages);
            Assert.Collection(sut.Messages,
                item => Assert.Equal(this._messageA, item));
        }

        [Fact]
        public void AddMessages_AddsAllMessagesToResult()
        {
            // Arrange
            var sut = new Result(true);

            // Act
            sut.AddMessages(this._messages);

            // Assert
            Assert.NotEmpty(sut.Messages);
            Assert.Collection(sut.Messages,
                item => Assert.Equal(this._messageA, item),
                item => Assert.Equal(this._messageB, item),
                item => Assert.Equal(this._messageC, item));
        }
    }
}