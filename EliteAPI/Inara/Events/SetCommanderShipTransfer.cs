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
        public string ShipType { get; internal set; }

        [JsonProperty("shipGameID")]
        public long ShipGameId { get; internal set; }

        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }

        [JsonProperty("stationName")]
        public string StationName { get; internal set; }

        [JsonProperty("marketID")]
        public long MarketID { get; internal set; }

        [JsonProperty("transferTime")]
        public long TransferTime { get; internal set; }
    }
}
