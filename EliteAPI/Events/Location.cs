using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class LocationInfo
    {
        public class RecoveringStateInfo
        {
            public string State { get; }
            public int Trend { get; }
        }

        public class FactionInfo
        {
            public string Name { get; }
            public string FactionState { get; }
            public string Government { get; }
            public double Influence { get; }
            public string Allegiance { get; }
            public List<RecoveringStateInfo> RecoveringStates { get; }
        }

        public DateTime timestamp { get; }
        public bool Docked { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StationType { get; }
        public string StarSystem { get; }
        public long SystemAddress { get; }
        public List<double> StarPos { get; }
        public string SystemAllegiance { get; }
        public string SystemEconomy { get; }
        public string SystemEconomy_Localised { get; }
        public string SystemSecondEconomy { get; }
        public string SystemSecondEconomy_Localised { get; }
        public string SystemGovernment { get; }
        public string SystemGovernment_Localised { get; }
        public string SystemSecurity { get; }
        public string SystemSecurity_Localised { get; }
        public ulong Population { get; }
        public string Body { get; }
        public int BodyID { get; }
        public string BodyType { get; }
        public List<FactionInfo> Factions { get; }
        public string SystemFaction { get; }
        public string FactionState { get; }
    }
}
