using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ModuleInfoInfo : EventBase
    {
        internal static ModuleInfoInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeModuleInfoEvent(JsonConvert.DeserializeObject<ModuleInfoInfo>(json, JsonSettings.Settings));
        }
    }
}