using System.Collections.Generic;

using static EliteAPI.DockedInfo;

namespace EliteAPI
{
    public class Station
    {
        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public long MarketID { get; internal set; }
        public string Faction { get; internal set; }
        public string FactionState { get; internal set; }
        public string Government { get; internal set; }
        public string Government_Localised { get; internal set; }
        public string Allegiance { get; internal set; }
        public List<string> Services { get; internal set; }
        public string Economy { get; internal set; }
        public string Economy_Localised { get; internal set; }
        public List<StationEconomyInfo> Economies { get; internal set; }
        public double DistFromStarLS { get; internal set; }
        public System System { get; internal set; }
    }
}
