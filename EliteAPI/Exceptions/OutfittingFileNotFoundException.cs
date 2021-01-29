using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the Status.json file could not be found
    /// </summary>
    public class OutfittingFileNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutfittingFileNotFoundException" /> class
        /// </summary>
        public OutfittingFileNotFoundException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutfittingFileNotFoundException" /> class with a specified error message
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        public OutfittingFileNotFoundException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutfittingFileNotFoundException" /> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message"> The message that describes the error </param>
        /// <param name="innerException"> The inner exception that caused this exception </param>
        public OutfittingFileNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}