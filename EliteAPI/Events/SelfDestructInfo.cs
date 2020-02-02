using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SelfDestructInfo : EventBase
    {
        internal static SelfDestructInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSelfDestructEvent(JsonConvert.DeserializeObject<SelfDestructInfo>(json, JsonSettings.Settings));
        }
    }
}