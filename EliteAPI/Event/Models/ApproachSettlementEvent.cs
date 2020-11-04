using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ApproachSettlementEvent : EventBase
    {
        internal ApproachSettlementEvent() { }

        public static ApproachSettlementEvent FromJson(string json) => JsonConvert.DeserializeObject<ApproachSettlementEvent>(json);



        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("BodyID")]
        public int BodyId { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; internal set; }


    }
}