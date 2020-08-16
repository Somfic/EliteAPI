using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class BuyAmmoEvent : EventBase
    {
        internal BuyAmmoEvent() { }

        public static BuyAmmoEvent FromJson(string json) => JsonConvert.DeserializeObject<BuyAmmoEvent>(json);



        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        
    }
}