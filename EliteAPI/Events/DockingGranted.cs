using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class DockingGrantedInfo
    {
        public DateTime timestamp { get; set; }

        public int LandingPad { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
    }
}
