using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    //{ "timestamp":"2019-10-15T17:50:50Z", "event":"FSDTarget", "Name":"Crucis Sector JC-V b2-5", "SystemAddress":11666607580601, "RemainingJumpsInRoute":2 }

    public class FSDTargetEvent : EventBase
    {
        internal FSDTargetEvent() { }

        public static FSDTargetEvent FromJson(string json) => JsonConvert.DeserializeObject<FSDTargetEvent>(json);


        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("RemainingJumpsInRoute")]
        public int RemainingJumpsInRoute { get; internal set; }

        
    }
}