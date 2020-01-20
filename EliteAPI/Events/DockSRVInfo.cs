using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockSRVInfo : EventBase
    {
        internal static DockSRVInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockSRVEvent(JsonConvert.DeserializeObject<DockSRVInfo>(json, JsonSettings.Settings));
        }
    }
}