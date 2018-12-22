using System;

namespace EliteAPI
{
    public class MissionAcceptedInfo
    {
        public DateTime timestamp { get; }
        public string Faction { get; }
        public string Name { get; }
        public string LocalisedName { get; }
        public string TargetFaction { get; }
        public string DestinationSystem { get; }
        public string DestinationStation { get; }
        public DateTime Expiry { get; }
        public bool Wing { get; }
        public string Influence { get; }
        public string Reputation { get; }
        public int Reward { get; }
        public int MissionID { get; }
    }
}
