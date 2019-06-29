using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class StoredShipsInfo
    {
        public class ShipHereInfo
        {
            public int ShipID { get; set; }
            public string ShipType { get; set; }
            public int Value { get; set; }
            public bool Hot { get; set; }
        }

        public class ShipRemoteInfo
        {
            public int ShipID { get; set; }
            public string ShipType { get; set; }
            public string ShipType_Localised { get; set; }
            public string StarSystem { get; set; }
            public long ShipMarketID { get; set; }
            public int TransferPrice { get; set; }
            public int TransferTime { get; set; }
            public int Value { get; set; }
            public bool Hot { get; set; }
        }

        public DateTime timestamp { get; set; }
        public string StationName { get; set; }
        public long MarketID { get; set; }
        public string StarSystem { get; set; }
        public List<ShipHereInfo> ShipsHere { get; set; }
        public List<ShipRemoteInfo> ShipsRemote { get; set; }
    }   
}
