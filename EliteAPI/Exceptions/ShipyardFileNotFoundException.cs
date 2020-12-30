using System;

using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the Shipyard.json file could not be found
    /// </summary>
    public class ShipyardFileNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipyardFileNotFoundException"/> class
        /// </summary>
        public ShipyardFileNotFoundException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipyardFileNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public ShipyardFileNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipyardFileNotFound"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public ShipyardFileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}