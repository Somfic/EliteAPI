using System; 


namespace EliteAPI
{
    public class MissionAcceptedInfo
    {
        public DateTime timestamp { get; set; }
        public string Faction { get; set; }
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public string TargetFaction { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public DateTime Expiry { get; set; }
        public bool Wing { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }
        public int Reward { get; set; }
        public int MissionID { get; set; }
    }
}
