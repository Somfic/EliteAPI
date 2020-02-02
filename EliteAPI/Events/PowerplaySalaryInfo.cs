using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplaySalaryInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        internal static PowerplaySalaryInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplaySalaryEvent(JsonConvert.DeserializeObject<PowerplaySalaryInfo>(json, JsonSettings.Settings));
        }
    }
}