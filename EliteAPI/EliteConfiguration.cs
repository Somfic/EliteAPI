using System.IO;

namespace EliteAPI
{
    public class EliteConfiguration
    {
        public EliteConfiguration()
        {

        }

        public EliteConfiguration(string journalDirectory)
        {
            JournalDirectory = new DirectoryInfo(journalDirectory);
        }

        /// <summary>
        /// Whether to use Discord's rich presence feature.
        /// </summary>
        public bool UseDiscordRichPresence { get; set; } = true;

        /// <summary>
        /// Whether to process and raise previous events from the current game session while catching up.
        /// </summary>
        public bool CatchupOnPastEvents { get; set; }

        /// <summary>
        /// Whether to throw an error when not all the event's fields could be filled in.
        /// </summary>
        public bool WarnOnIncomplete { get; set; }

        /// <summary>
        /// Whether to throw a warning when the event has not been implemented into EliteAPI.
        /// </summary>
        public bool WarnOnMissing { get; set; }

        /// <summary>
        /// The directory in which the Journals and status files are located.
        /// </summary>
        public DirectoryInfo JournalDirectory { get; set; } = EliteDangerousAPI.StandardDirectory;
    }
}