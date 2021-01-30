using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the options directory could not be found
    /// </summary>
    public class OptionsDirectoryNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsDirectoryNotFoundException" /> class
        /// </summary>
        public OptionsDirectoryNotFoundException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsDirectoryNotFoundException" /> class with a specified error message
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        public OptionsDirectoryNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsDirectoryNotFoundException" /> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        /// <param name="innerException"> The inner exception that caused this exception </param>
        public OptionsDirectoryNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}