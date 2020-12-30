using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the NavRoute.json file could not be found
    /// </summary>
    public class NavRouteFileNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketFileNotFoundException"/> class
        /// </summary>
        public NavRouteFileNotFoundException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavRouteFileNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public NavRouteFileNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavRouteFileNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public NavRouteFileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}