using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class BuyAmmoInfo : EventBase
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyAmmoInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeBuyAmmoEvent(JsonConvert.DeserializeObject<BuyAmmoInfo>(json, JsonSettings.Settings));
        }
    }
}