using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class UnderAttackEvent : EventBase
    {
        internal UnderAttackEvent() { }

        public static UnderAttackEvent FromJson(string json) => JsonConvert.DeserializeObject<UnderAttackEvent>(json);


        [JsonProperty("Target")]
        public string Target { get; internal set; }

        
    }
}