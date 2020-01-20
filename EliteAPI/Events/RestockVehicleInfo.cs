using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class RestockVehicleInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static RestockVehicleInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeRestockVehicleEvent(JsonConvert.DeserializeObject<RestockVehicleInfo>(json, JsonSettings.Settings));
        }
    }
}