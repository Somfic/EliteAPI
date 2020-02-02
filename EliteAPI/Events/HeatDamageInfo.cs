using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class HeatDamageInfo : EventBase
    {
        internal static HeatDamageInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeHeatDamageEvent(JsonConvert.DeserializeObject<HeatDamageInfo>(json, JsonSettings.Settings));
        }
    }
}