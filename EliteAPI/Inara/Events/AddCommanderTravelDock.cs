using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class AddCommanderTravelDock : IInaraEventData
    {
        public AddCommanderTravelDock(string starsystemName, string stationName)
        {
            StarsystemName = starsystemName;
            StationName = stationName;
        }

        [JsonProperty("starsystemName")]
        public string StarsystemName { get; internal set; }

        [JsonProperty("stationName")]
        public string StationName { get; internal set; }

        [JsonProperty("marketID")]
        public long MarketID { get; internal set; }

        [JsonProperty("shipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("shipGameID")]
        public long ShipGameId { get; internal set; }
    }
}
