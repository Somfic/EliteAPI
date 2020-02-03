using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FuelScoopInfo : EventBase
    {
        [JsonProperty("Scooped")]
        public float Scooped { get; internal set; }

        [JsonProperty("Total")]
        public float Total { get; internal set; }

        internal static FuelScoopInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFuelScoopEvent(JsonConvert.DeserializeObject<FuelScoopInfo>(json, JsonSettings.Settings));
        }
    }
}