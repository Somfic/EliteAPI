using System;

namespace EliteAPI
{
    public class LeaveBodyInfo
    {
        public DateTime timestamp { get; }
        public string StarSystem { get; }
        public long SystemAddress { get; }
        public string Body { get; }
        public int BodyID { get; }
    }
}
