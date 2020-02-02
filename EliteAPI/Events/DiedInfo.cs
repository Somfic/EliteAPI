using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DiedInfo : EventBase
    {
        [JsonProperty("KillerName")]
        public string KillerName { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        public string KillerNameLocalised { get; internal set; }

        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }

        [JsonProperty("KillerRank")]
        public string KillerRank { get; internal set; }

        internal static DiedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDiedEvent(JsonConvert.DeserializeObject<DiedInfo>(json, JsonSettings.Settings));
        }
    }
}