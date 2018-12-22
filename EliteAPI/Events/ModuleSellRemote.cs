using System;

namespace EliteAPI
{
    public class ModuleSellRemoteInfo
    {
        public DateTime timestamp { get; }
        public int StorageSlot { get; }
        public string SellItem { get; }
        public string SellItem_Localised { get; }
        public int ServerId { get; }
        public int SellPrice { get; }
        public string Ship { get; }
        public int ShipID { get; }
    }
}
