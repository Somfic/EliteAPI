using System.Collections.Generic;

namespace EliteAPI
{
    public class System
    {
        public string Name { get; set; }
        public List<double> Position { get; set; }
        public long Address { get; set; }
        public string Allegiance { get; set; }
        public string Economy { get; set; }
        public string Economy_Localised { get; set; }
        public string SecondEconomy { get; set; }
        public string SecondEconomy_Localised { get; set; }
        public string Government { get; set; }
        public string Government_Localised { get; set; }
        public string Security { get; set; }
        public string Security_Localised { get; set; }
        public int Population { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }
    }
}
