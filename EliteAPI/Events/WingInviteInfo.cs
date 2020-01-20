using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class WingInviteInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static WingInviteInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeWingInviteEvent(JsonConvert.DeserializeObject<WingInviteInfo>(json, JsonSettings.Settings));
        }
    }
}