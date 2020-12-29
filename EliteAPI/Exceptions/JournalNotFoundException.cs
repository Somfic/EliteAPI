using System;
using EliteAPI.Exceptions.Abstractions;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an event is not implemented
    /// </summary>
    public class JournalNotFoundException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalNotFoundException"/> class
        /// </summary>
        public JournalNotFoundException()
        { 

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalNotFoundException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public JournalNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public JournalNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}