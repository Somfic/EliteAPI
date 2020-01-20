using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CollectCargoInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Stolen")]
        public bool Stolen { get; internal set; }

        internal static CollectCargoInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCollectCargoEvent(JsonConvert.DeserializeObject<CollectCargoInfo>(json, JsonSettings.Settings));
        }
    }
}