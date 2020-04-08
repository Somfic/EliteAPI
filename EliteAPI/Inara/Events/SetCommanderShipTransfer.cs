using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderShipTransfer : IInaraEventData
    {
        public SetCommanderShipTransfer(string shipType, long shipGameId, string starsystemName, string stationName)
        {
            ShipType = shipType;
            ShipGameId = shipGameId;
            StarsystemName = starsystemName;
            StationName = stationName;
        }
        [JsonProperty("shipType")]
        public string ShipType { get; set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; set; }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }
        [JsonProperty("stationName")]
        public string StationName { get; set; }
        [JsonProperty("marketID")]
        public long MarketID { get; set; }
        [JsonProperty("transferTime")]
        public long TransferTime { get; set; }
    }
}
