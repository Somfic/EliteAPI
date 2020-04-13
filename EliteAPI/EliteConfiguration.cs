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

        public bool UseDiscordRichPresence { get; set; } = true;
        public bool TriggerFromBeginSession { get; set; }

        public DirectoryInfo JournalDirectory { get; set; }
    }
}