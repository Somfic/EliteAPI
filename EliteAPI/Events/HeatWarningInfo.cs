using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HeatWarningInfo : EventBase
    {
        internal static HeatWarningInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHeatWarningEvent(JsonConvert.DeserializeObject<HeatWarningInfo>(json, JsonSettings.Settings));

    }
}
