using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SRVDestroyedInfo : EventBase
    {
        internal static SRVDestroyedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSRVDestroyedEvent(JsonConvert.DeserializeObject<SRVDestroyedInfo>(json, JsonSettings.Settings));
        }
    }
}