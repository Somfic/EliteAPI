using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ModuleSellRemoteEvent : EventBase
    {
        internal ModuleSellRemoteEvent() { }

        public static ModuleSellRemoteEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleSellRemoteEvent>(json);


        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("SellItem")]
        public string SellItem { get; internal set; }

        [JsonProperty("SellItem_Localised")]
        public string SellItemLocalised { get; internal set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        
    }
}