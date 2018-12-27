using System;

namespace EliteAPI
{
    public class StartJumpInfo
    {
        public DateTime timestamp { get; set; }
        public string JumpType { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string StarClass { get; set; }
    }
}
