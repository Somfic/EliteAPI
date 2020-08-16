using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ModuleRetrieveEvent : EventBase
    {
        internal ModuleRetrieveEvent() { }

        public static ModuleRetrieveEvent FromJson(string json) => JsonConvert.DeserializeObject<ModuleRetrieveEvent>(json);


        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("RetrievedItem")]
        public string RetrievedItem { get; internal set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public float Quality { get; internal set; }

        [JsonProperty("SwapOutItem")]
        public string SwapOutItem { get; internal set; }

        [JsonProperty("SwapOutItem_Localised")]
        public string SwapOutItemLocalised { get; internal set; }

        
    }
}