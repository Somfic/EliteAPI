using System;

namespace EliteAPI
{
    public class FileheaderInfo
    {
        public DateTime timestamp { get; }
        public int part { get; }
        public string language { get; }
        public string gameversion { get; }
        public string build { get; }
    }
}
