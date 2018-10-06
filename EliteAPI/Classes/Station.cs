using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EliteAPI.DockedInfo;

namespace EliteAPI
{
    public class Station
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public long MarketID { get; set; }
        public string Faction { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public string Government_Localised { get; set; }
        public string Allegiance { get; set; }
        public List<string> Services { get; set; }
        public string Economy { get; set; }
        public string Economy_Localised { get; set; }
        public List<StationEconomyInfo> Economies { get; set; }
        public double DistFromStarLS { get; set; }
        public System System { get; set; }
    }
}
