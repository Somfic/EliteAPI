using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the Market.json file could not be found
    /// </summary>
    public class MarketFileNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketFileNotFoundException"/> class
        /// </summary>
        public MarketFileNotFoundException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketFileNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public MarketFileNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketFileNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public MarketFileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}