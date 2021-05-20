using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the Backpack.json file could not be found
    /// </summary>
    public class BackpackFileNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackpackFileNotFoundException" /> class
        /// </summary>
        public BackpackFileNotFoundException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackpackFileNotFoundException" /> class with a specified error message
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        public BackpackFileNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackpackFileNotFoundException" /> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        /// <param name="innerException"> The inner exception that caused this exception </param>
        public BackpackFileNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}