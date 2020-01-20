using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CockpitBreachedInfo : EventBase
    {
        internal static CockpitBreachedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCockpitBreachedEvent(JsonConvert.DeserializeObject<CockpitBreachedInfo>(json, JsonSettings.Settings));

    }
}
