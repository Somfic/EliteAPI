using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplaySalaryEvent : EventBase
    {
        internal PowerplaySalaryEvent() { }

        public static PowerplaySalaryEvent FromJson(string json) => JsonConvert.DeserializeObject<PowerplaySalaryEvent>(json);


        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        
    }
}