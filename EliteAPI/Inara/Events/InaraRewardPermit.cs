using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class InaraRewardPermit
    {
        [JsonProperty("starsystemName")]
        public string StarsystemName { get; set; }
    }
}