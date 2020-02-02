using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayFastTrackInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static PowerplayFastTrackInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayFastTrackEvent(JsonConvert.DeserializeObject<PowerplayFastTrackInfo>(json, JsonSettings.Settings));
        }
    }
}