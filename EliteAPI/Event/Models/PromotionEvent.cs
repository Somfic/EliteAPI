using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PromotionEvent : EventBase
    {
        internal PromotionEvent() { }
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }

        
    }
}