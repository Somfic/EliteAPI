using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FighterDestroyedInfo : EventBase
    {
        internal static FighterDestroyedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFighterDestroyedEvent(JsonConvert.DeserializeObject<FighterDestroyedInfo>(json, JsonSettings.Settings));
        }
    }
}