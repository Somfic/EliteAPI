using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderShip : IInaraEventData
    {
        public SetCommanderShip(string shipType, long shipGameId)
        {
            ShipType = shipType;
            ShipGameId = shipGameId;
        }
        [JsonProperty("shipType")]
        public string ShipType { get; set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; set; }
        [JsonProperty("shipName")]
        public string ShipName { get; set; }
        [JsonProperty("shipIdent")]
        public string ShipIdent { get; set; }
        [JsonProperty("isCurrentShip")]
        public bool IsCurrentShip { get; set; }
        [JsonProperty("isMainShip")]
        public bool IsMainShip { get; set; }
        [JsonProperty("isHot")]
        public bool IsHot { get; set; }
        [JsonProperty("shipHullValue")]
        public long ShipHullValue { get; set; }
        [JsonProperty("shipModulesValue")]
        public long ShipModulesValue { get; set; }
        [JsonProperty("shipRebuyCost")]
        public long ShipRebuyCost { get; set; }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }
        [JsonProperty("stationName")]
        public string StationName { get; set; }
    }
}
