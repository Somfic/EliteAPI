using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SystemsShutdownInfo : EventBase
    {
        internal static SystemsShutdownInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSystemsShutdownEvent(JsonConvert.DeserializeObject<SystemsShutdownInfo>(json, JsonSettings.Settings));
        }
    }
}