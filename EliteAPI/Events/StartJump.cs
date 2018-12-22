using System;

namespace EliteAPI
{
    public class StartJumpInfo
    {
        public DateTime timestamp { get; }
        public string JumpType { get; }
        public string StarSystem { get; }
        public long SystemAddress { get; }
        public string StarClass { get; }
    }
}
