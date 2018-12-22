using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class DockedInfo
    {
        public class StationEconomyInfo
        {
            public string Name { get; }
            public string Name_Localised { get; }
            public double Proportion { get; }
        }

        public DateTime timestamp { get; }
        public string StationName { get; }
        public string StationType { get; }
        public string StarSystem { get; }
        public long SystemAddress { get; }
        public long MarketID { get; }
        public string StationFaction { get; }
        public string FactionState { get; }
        public string StationGovernment { get; }
        public string StationGovernment_Localised { get; }
        public string StationAllegiance { get; }
        public List<string> StationServices { get; }
        public string StationEconomy { get; }
        public string StationEconomy_Localised { get; }
        public List<StationEconomyInfo> StationEconomies { get; }
        public double DistFromStarLS { get; }
    }
}
