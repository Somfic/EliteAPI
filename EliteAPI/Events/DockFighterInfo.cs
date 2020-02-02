using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DockFighterInfo : EventBase
    {
        internal static DockFighterInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDockFighterEvent(JsonConvert.DeserializeObject<DockFighterInfo>(json, JsonSettings.Settings));
        }
    }
}