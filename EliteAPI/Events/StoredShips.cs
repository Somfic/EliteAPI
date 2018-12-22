using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class StoredShipsInfo
    {
        public class ShipHereInfo
        {
            public int ShipID { get; }
            public string ShipType { get; }
            public int Value { get; }
            public bool Hot { get; }
        }

        public class ShipRemoteInfo
        {
            public int ShipID { get; }
            public string ShipType { get; }
            public string ShipType_Localised { get; }
            public string StarSystem { get; }
            public long ShipMarketID { get; }
            public int TransferPrice { get; }
            public int TransferTime { get; }
            public int Value { get; }
            public bool Hot { get; }
        }

        public DateTime timestamp { get; }
        public string StationName { get; }
        public long MarketID { get; }
        public string StarSystem { get; }
        public List<ShipHereInfo> ShipsHere { get; }
        public List<ShipRemoteInfo> ShipsRemote { get; }
    }   
}
