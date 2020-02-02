using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CockpitBreachedInfo : EventBase
    {
        internal static CockpitBreachedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCockpitBreachedEvent(JsonConvert.DeserializeObject<CockpitBreachedInfo>(json, JsonSettings.Settings));
        }
    }
}