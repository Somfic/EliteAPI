using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayDefectInfo : EventBase
    {
        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }

        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }

        internal static PowerplayDefectInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayDefectEvent(JsonConvert.DeserializeObject<PowerplayDefectInfo>(json, JsonSettings.Settings));
        }
    }
}