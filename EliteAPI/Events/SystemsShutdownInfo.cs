using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SystemsShutdownInfo : EventBase
    {
        internal static SystemsShutdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSystemsShutdownEvent(JsonConvert.DeserializeObject<SystemsShutdownInfo>(json, JsonSettings.Settings));

    }
}
