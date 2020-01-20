using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShutdownInfo : EventBase
    {
        internal static ShutdownInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShutdownEvent(JsonConvert.DeserializeObject<ShutdownInfo>(json, JsonSettings.Settings));
        }
    }
}