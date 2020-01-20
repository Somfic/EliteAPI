using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FriendsInfo : EventBase
    {
        [JsonProperty("Status")]
        public string Status { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static FriendsInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFriendsEvent(JsonConvert.DeserializeObject<FriendsInfo>(json, JsonSettings.Settings));
        }
    }
}