using System.IO;

namespace EliteAPI.Configuration.Abstractions
{
    /// <summary>
    /// Interface for the <see cref="IEliteDangerousApiConfiguration"/> configuration class
    /// </summary>
    public interface IEliteDangerousApiConfiguration
    {
        /// <summary>
        /// The active journal directory path
        /// </summary>
        public string JournalPath { get; }

        /// <summary>
        /// The targeted journal file
        /// </summary>
        public string Journal { get; }
    }
}