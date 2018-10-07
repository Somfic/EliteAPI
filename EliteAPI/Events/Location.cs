using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class LocationInfo
    {
        public class RecoveringStateInfo
        {
            public string State { get; set; }
            public int Trend { get; set; }
        }

        public class FactionInfo
        {
            public string Name { get; set; }
            public string FactionState { get; set; }
            public string Government { get; set; }
            public double Influence { get; set; }
            public string Allegiance { get; set; }
            public List<RecoveringStateInfo> RecoveringStates { get; set; }
        }

        public DateTime timestamp { get; set; }
        public bool Docked { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public List<double> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public int Population { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public string BodyType { get; set; }
        public List<FactionInfo> Factions { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }
    }
}
