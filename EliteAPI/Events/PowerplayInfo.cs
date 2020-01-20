using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Rank")]
        public long Rank { get; internal set; }

        [JsonProperty("Merits")]
        public long Merits { get; internal set; }

        [JsonProperty("Votes")]
        public long Votes { get; internal set; }

        [JsonProperty("TimePledged")]
        public long TimePledged { get; internal set; }

        internal static PowerplayInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayEvent(JsonConvert.DeserializeObject<PowerplayInfo>(json, JsonSettings.Settings));
        }
    }
}