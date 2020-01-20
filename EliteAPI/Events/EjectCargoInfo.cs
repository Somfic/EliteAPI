using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class EjectCargoInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("Abandoned")]
        public bool Abandoned { get; internal set; }

        internal static EjectCargoInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeEjectCargoEvent(JsonConvert.DeserializeObject<EjectCargoInfo>(json, JsonSettings.Settings));
        }
    }
}