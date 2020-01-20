using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class DockSRVInfo : EventBase
    {
        internal static DockSRVInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDockSRVEvent(JsonConvert.DeserializeObject<DockSRVInfo>(json, JsonSettings.Settings));

    }
}
