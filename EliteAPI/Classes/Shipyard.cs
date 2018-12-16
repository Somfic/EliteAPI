using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class Shipyard
    {
        public DateTime timestamp { get; set; }
        public long MarketID { get; set; }
        public string StationName { get; set; }
        public string StarSystem { get; set; }
        public bool Horizons { get; set; }
        public bool AllowCobraMkIV { get; set; }
        public List<Pricelist> PriceList { get; set; }
    }

    public class Pricelist
    {
        public int id { get; set; }
        public string ShipType { get; set; }
        public int ShipPrice { get; set; }
        public string ShipType_Localised { get; set; }
    }

}
