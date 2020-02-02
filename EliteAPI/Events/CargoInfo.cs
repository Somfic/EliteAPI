using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CargoInfo : EventBase
    {
        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Inventory")]
        public List<Inventory> Inventory { get; internal set; }

        internal static CargoInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCargoEvent(JsonConvert.DeserializeObject<CargoInfo>(json, JsonSettings.Settings));
        }
    }
}