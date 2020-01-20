using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class HeatWarningInfo : EventBase
    {
        internal static HeatWarningInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeHeatWarningEvent(JsonConvert.DeserializeObject<HeatWarningInfo>(json, JsonSettings.Settings));
        }
    }
}