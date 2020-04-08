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
        public string StarsystemName { get; set; }
        [JsonProperty("stationName")]
        public string StationName { get; set; }
        [JsonProperty("marketID")]
        public long MarketID { get; set; }
        [JsonProperty("shipType")]
        public string ShipType { get; set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; set; }
    }
}
