using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AddonCraft.Application.UnitTests")]
namespace AddonCraft.Application.Common.Models
{
    /// <summary>
    /// Represents the result of an operation.
    /// </summary>
    public class Result
    {
        private readonly ICollection<String> _messages;

        /// <summary>
        /// Initializes the Result.
        /// </summary>
        /// <param name="isSuccessful">Indicates whether the result is successful or not.</param>
        internal Result(Boolean isSuccessful)
        {
            this._messages = new List<String>();

            this.IsSuccessful = isSuccessful;
        }

        /// <summary>
        /// Initializes the Result with messages.
        /// </summary>
        /// <param name="isSuccessful">Indicates whether the result is successful or not.</param>
        /// <param name="messages">The messages for the result.</param>
        internal Result(Boolean isSuccessful, IEnumerable<String> messages)
        {
            this.IsSuccessful = isSuccessful;
            this._messages = messages.ToList();
        }

        /// <summary>
        /// Result's indicator for success.
        /// </summary>
        public Boolean IsSuccessful { get; }

        /// <summary>
        /// Result's messages.
        /// </summary>
        public IEnumerable<String> Messages => this._messages;

        /// <summary>
        /// Adds a message to the Result.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(String message) => this._messages.Add(message);

        /// <summary>
        /// Adds multiple messages to the Result.
        /// </summary>
        /// <param name="messages"></param>
        public void AddMessages(IEnumerable<String> messages)
        {
            foreach (var message in messages)
            {
                this._messages.Add(message);
            }
        }
    }
}