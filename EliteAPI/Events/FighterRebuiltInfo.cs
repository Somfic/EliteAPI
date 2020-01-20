using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FighterRebuiltInfo : EventBase
    {
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        internal static FighterRebuiltInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFighterRebuiltEvent(JsonConvert.DeserializeObject<FighterRebuiltInfo>(json, JsonSettings.Settings));
        }
    }
}