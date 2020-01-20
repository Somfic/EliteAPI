using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ModuleSellRemoteInfo : EventBase
    {
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

        internal static ModuleSellRemoteInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeModuleSellRemoteEvent(JsonConvert.DeserializeObject<ModuleSellRemoteInfo>(json, JsonSettings.Settings));
        }
    }
}