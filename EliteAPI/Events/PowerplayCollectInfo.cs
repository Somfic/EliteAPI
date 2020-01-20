using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayCollectInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static PowerplayCollectInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayCollectEvent(JsonConvert.DeserializeObject<PowerplayCollectInfo>(json, JsonSettings.Settings));
        }
    }
}