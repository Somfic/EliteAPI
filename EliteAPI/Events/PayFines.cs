using System;

namespace EliteAPI
{
    public class PayFinesInfo
    {
        public DateTime timestamp { get; }
        public int Amount { get; }
        public bool AllFines { get; }
        public int ShipID { get; }
    }
}
