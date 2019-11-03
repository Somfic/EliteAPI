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
        public string ShipType { get; internal set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; internal set; }
        [JsonProperty("shipName")]
        public string ShipName { get; internal set; }
        [JsonProperty("shipIdent")]
        public string ShipIdent { get; internal set; }
        [JsonProperty("isCurrentShip")]
        public bool IsCurrentShip { get; internal set; }
        [JsonProperty("isMainShip")]
        public bool IsMainShip { get; internal set; }
        [JsonProperty("isHot")]
        public bool IsHot { get; internal set; }
        [JsonProperty("shipHullValue")]
        public long ShipHullValue { get; internal set; }
        [JsonProperty("shipModulesValue")]
        public long ShipModulesValue { get; internal set; }
        [JsonProperty("shipRebuyCost")]
        public long ShipRebuyCost { get; internal set; }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }
        [JsonProperty("stationName")]
        public string StationName { get; internal set; }
    }
}
