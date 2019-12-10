using System; 


namespace EliteAPI
{
    public class ModuleSellRemoteInfo
    {
        public DateTime timestamp { get; set; }
        public int StorageSlot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public int ServerId { get; set; }
        public int SellPrice { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
    }
}
