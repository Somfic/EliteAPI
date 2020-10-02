using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PromotionEvent : EventBase
    {
        internal PromotionEvent() { }

        public static PromotionEvent FromJson(string json) => JsonConvert.DeserializeObject<PromotionEvent>(json);


        [JsonProperty("Federation")]
        public long Federation { get; internal set; }

        
    }
}