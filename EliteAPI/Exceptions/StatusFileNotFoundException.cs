using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the Status.json file could not be found
    /// </summary>
    public class StatusFileNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusFileNotFoundException"/> class
        /// </summary>
        public StatusFileNotFoundException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusFileNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public StatusFileNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusFileNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public StatusFileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
