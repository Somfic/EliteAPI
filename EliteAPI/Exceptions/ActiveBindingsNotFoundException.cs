using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the active binding could not be found
    /// </summary>
    public class ActiveBindingsNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveBindingsNotFoundException"/> class
        /// </summary>
        public ActiveBindingsNotFoundException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveBindingsNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public ActiveBindingsNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveBindingsNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public ActiveBindingsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}