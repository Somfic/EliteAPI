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
        public string StarsystemName { get; internal set; }
        [JsonProperty("jumpDistance")]
        public float JumpDistance { get; internal set; }
        [JsonProperty("shipType")]
        public string ShipType { get; internal set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; internal set; }
    }
}
