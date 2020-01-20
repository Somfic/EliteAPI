using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayJoinInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        internal static PowerplayJoinInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayJoinEvent(JsonConvert.DeserializeObject<PowerplayJoinInfo>(json, JsonSettings.Settings));
        }
    }
}