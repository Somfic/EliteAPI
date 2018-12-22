using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class Shipyard
    {
        public DateTime timestamp { get; }
        public long MarketID { get; }
        public string StationName { get; }
        public string StarSystem { get; }
        public bool Horizons { get; }
        public bool AllowCobraMkIV { get; }
        public List<Pricelist> PriceList { get; }
    }

    public class Pricelist
    {
        public int id { get; }
        public string ShipType { get; }
        public int ShipPrice { get; }
        public string ShipType_Localised { get; }
    }

}
