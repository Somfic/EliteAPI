using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class AsteroidCrackedInfo : EventBase
    {
        [JsonProperty("Body")]
        public string Body { get; internal set; }

        internal static AsteroidCrackedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeAsteroidCrackedEvent(JsonConvert.DeserializeObject<AsteroidCrackedInfo>(json, JsonSettings.Settings));
        }
    }
}