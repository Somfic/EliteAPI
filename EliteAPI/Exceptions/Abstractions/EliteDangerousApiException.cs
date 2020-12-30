using System;

namespace EliteAPI.Exceptions.Abstractions
{
    /// <summary>
    /// Base class for all EliteAPI's exceptions
    /// </summary>
    public class EliteDangerousApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EliteDangerousApiException"/> class
        /// </summary>
        protected EliteDangerousApiException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EliteDangerousApiException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        protected EliteDangerousApiException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EliteDangerousApiException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        protected EliteDangerousApiException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}