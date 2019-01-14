using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class SetCommanderTravelLocation : IInaraEventData
    {
        public SetCommanderTravelLocation(string starSystemName)
        {
            StarSystemName = starSystemName;
        }

        [JsonProperty("starsystemName")]
        public string StarSystemName { get; set; }

        [JsonProperty("stationName")]
        public string StationName { get; set; }

        [JsonProperty("marketID")]
        public long MarketId { get; set; }
    }
}
