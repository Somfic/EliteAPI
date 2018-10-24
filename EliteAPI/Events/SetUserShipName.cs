using System;

namespace EliteAPI
{
    public class SetUserShipNameInfo
    {
        public DateTime timestamp { get; set; }

        public string Ship { get; set; }
        public int ShipID { get; set; }
        public string UserShipName { get; set; }
        public string UserShipId { get; set; }
    }
}
