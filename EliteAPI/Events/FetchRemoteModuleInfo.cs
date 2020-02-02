using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FetchRemoteModuleInfo : EventBase
    {
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

        internal static FetchRemoteModuleInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFetchRemoteModuleEvent(JsonConvert.DeserializeObject<FetchRemoteModuleInfo>(json, JsonSettings.Settings));
        }
    }
}