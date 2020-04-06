using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class AddCommanderTravelFSDJump : IInaraEventData
    {
        public AddCommanderTravelFSDJump(string starsystemName)
        {
            StarsystemName = starsystemName;
        }
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }
        [JsonProperty("jumpDistance")]
        public double JumpDistance { get; set; }
        [JsonProperty("shipType")]
        public string ShipType { get; set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; set; }
    }
}
