using System;

namespace EliteAPI
{
    public class FetchRemoteModuleInfo
    {
        public DateTime timestamp { get; }
        public int StorageSlot { get; }
        public string StoredItem { get; }
        public string StoredItem_Localised { get; }
        public int ServerId { get; }
        public int TransferCost { get; }
        public int TransferTime { get; }
        public string Ship { get; }
        public int ShipID { get; }
    }
}
