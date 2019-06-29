using System;

namespace EliteAPI
{
    public class SupercruiseExitInfo
    {
        public DateTime timestamp { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public string BodyType { get; set; }
    }
}
