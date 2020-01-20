using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockFighterInfo : EventBase
    {
        internal static DockFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockFighterEvent(JsonConvert.DeserializeObject<DockFighterInfo>(json, JsonSettings.Settings));

    }
}
