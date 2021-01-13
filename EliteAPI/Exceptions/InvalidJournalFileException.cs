using EliteAPI.Exceptions.Abstractions;

using System;

namespace EliteAPI.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an invalid Journal file is being targeted
    /// </summary>
    public class InvalidJournalFileException : EliteDangerousApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidJournalFileException"/> class
        /// </summary>
        public InvalidJournalFileException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidJournalFileException"/> class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public InvalidJournalFileException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidJournalFileException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        /// <param name="innerException">The inner exception that caused this exception</param>
        public InvalidJournalFileException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
