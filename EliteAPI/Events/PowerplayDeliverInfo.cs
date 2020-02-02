using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayDeliverInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static PowerplayDeliverInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayDeliverEvent(JsonConvert.DeserializeObject<PowerplayDeliverInfo>(json, JsonSettings.Settings));
        }
    }
}