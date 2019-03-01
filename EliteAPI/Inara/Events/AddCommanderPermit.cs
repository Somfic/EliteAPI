using Newtonsoft.Json;

namespace EliteAPI.Inara.Events
{
    public class AddCommanderPermit : IInaraEventData
    {
        public AddCommanderPermit(string starSystemName)
        {
            StarSystemName = starSystemName;
        }

        [JsonProperty("starsystemName")]
        public string StarSystemName { get; internal set; }
    }
}
