using System; 


namespace EliteAPI
{
    public class InterdictedInfo
    {
        public DateTime timestamp { get; set; }
        public bool Submitted { get; set; }
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
    }
}
