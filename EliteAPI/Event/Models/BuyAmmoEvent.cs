using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyAmmoEvent : EventBase
    {
        internal BuyAmmoEvent() { }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}