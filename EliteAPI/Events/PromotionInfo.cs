using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PromotionInfo : EventBase
    {
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }

        internal static PromotionInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePromotionEvent(JsonConvert.DeserializeObject<PromotionInfo>(json, JsonSettings.Settings));
        }
    }
}