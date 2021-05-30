using System;

using EliteAPI.Configuration.Abstractions;

namespace EliteAPI.Configuration
{
    /// <summary>
    /// Standard implementation of the <see cref="IEliteDangerousApiConfiguration" /> configuration class
    /// </summary>
    public class EliteDangerousApiConfiguration : IEliteDangerousApiConfiguration
    {
        internal EliteDangerousApiConfiguration() { }

        /// <inheritdoc />
        public string JournalPath { get; init; }
        
        /// <inheritdoc />
        public string OptionsPath { get; init; }

        /// <inheritdoc />
        public string JournalFile { get; init; }

        /// <inheritdoc />
        public TimeSpan TickFrequency { get; init; }

        /// <inheritdoc />
        public string BindingsFile { get; set; }
    }
}