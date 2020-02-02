using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayLeaveInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        internal static PowerplayLeaveInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayLeaveEvent(JsonConvert.DeserializeObject<PowerplayLeaveInfo>(json, JsonSettings.Settings));
        }
    }
}