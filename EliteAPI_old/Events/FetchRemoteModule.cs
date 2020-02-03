using System; 


namespace EliteAPI
{
    public class FetchRemoteModuleInfo
    {
        public DateTime timestamp { get; set; }
        public int StorageSlot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public int ServerId { get; set; }
        public int TransferCost { get; set; }
        public int TransferTime { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
    }
}
