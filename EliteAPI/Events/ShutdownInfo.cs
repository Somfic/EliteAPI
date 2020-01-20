using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ShutdownInfo : EventBase
    {
        internal static ShutdownInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeShutdownEvent(JsonConvert.DeserializeObject<ShutdownInfo>(json, JsonSettings.Settings));

    }
}
