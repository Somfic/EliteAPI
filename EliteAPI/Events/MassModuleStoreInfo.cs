using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MassModuleStoreInfo : EventBase
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("Items")]
        public List<Item> Items { get; internal set; }

        internal static MassModuleStoreInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMassModuleStoreEvent(JsonConvert.DeserializeObject<MassModuleStoreInfo>(json, JsonSettings.Settings));
        }
    }
}