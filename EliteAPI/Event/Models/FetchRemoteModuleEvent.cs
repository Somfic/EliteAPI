using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FetchRemoteModuleEvent : EventBase
    {
        internal FetchRemoteModuleEvent() { }

        public static FetchRemoteModuleEvent FromJson(string json) => JsonConvert.DeserializeObject<FetchRemoteModuleEvent>(json);


        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("StoredItem")]
        public string StoredItem { get; internal set; }

        [JsonProperty("StoredItem_Localised")]
        public string StoredItemLocalised { get; internal set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; internal set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        
    }
}