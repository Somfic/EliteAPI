using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class UnderAttackInfo : EventBase
    {
        [JsonProperty("Target")]
        public string Target { get; internal set; }

        internal static UnderAttackInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeUnderAttackEvent(JsonConvert.DeserializeObject<UnderAttackInfo>(json, JsonSettings.Settings));
        }
    }
}