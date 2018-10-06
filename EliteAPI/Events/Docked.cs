using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class Docked
    {
        public class cStationEconomy
        {
            public string Name { get; set; }
            public string Name_Localised { get; set; }
            public double Proportion { get; set; }
        }

        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public long MarketID { get; set; }
        public string StationFaction { get; set; }
        public string FactionState { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<cStationEconomy> StationEconomies { get; set; }
        public double DistFromStarLS { get; set; }
    }
}
