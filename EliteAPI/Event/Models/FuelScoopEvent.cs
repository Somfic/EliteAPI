using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FuelScoopEvent : EventBase
    {
        internal FuelScoopEvent() { }

        public static FuelScoopEvent FromJson(string json) => JsonConvert.DeserializeObject<FuelScoopEvent>(json);


        [JsonProperty("Scooped")]
        public float Scooped { get; internal set; }

        [JsonProperty("Total")]
        public float Total { get; internal set; }

        
    }
}