using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PowerplaySalaryEvent : EventBase
    {
        internal PowerplaySalaryEvent() { }
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        
    }
}