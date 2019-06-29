using System;

namespace EliteAPI
{
    public class FileheaderInfo
    {
        public DateTime timestamp { get; set; }
        public int part { get; set; }
        public string language { get; set; }
        public string gameversion { get; set; }
        public string build { get; set; }
    }
}
