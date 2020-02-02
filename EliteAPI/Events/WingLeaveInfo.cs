using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class WingLeaveInfo : EventBase
    {
        internal static WingLeaveInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeWingLeaveEvent(JsonConvert.DeserializeObject<WingLeaveInfo>(json, JsonSettings.Settings));
        }
    }
}