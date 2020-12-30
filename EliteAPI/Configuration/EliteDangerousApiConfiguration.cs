using System.IO;
using EliteAPI.Configuration.Abstractions;

namespace EliteAPI.Configuration
{
    /// <summary>
    /// Standard implementation of the <see cref="IEliteDangerousApiConfiguration"/> configuration class
    /// </summary>
    public class EliteDangerousApiConfiguration : IEliteDangerousApiConfiguration
    {
        internal EliteDangerousApiConfiguration()
        {

        }

        /// <inheritdoc />
        public string JournalPath { get; init; }

        /// <inheritdoc />
        public string Journal { get; init; }
    }
}