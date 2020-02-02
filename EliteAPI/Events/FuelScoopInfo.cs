using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FuelScoopInfo : EventBase
    {
        [JsonProperty("Scooped")]
        public double Scooped { get; internal set; }

        [JsonProperty("Total")]
        public double Total { get; internal set; }

        internal static FuelScoopInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFuelScoopEvent(JsonConvert.DeserializeObject<FuelScoopInfo>(json, JsonSettings.Settings));
        }
    }
}