using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class HeatDamageInfo : EventBase
    {
        internal static HeatDamageInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeHeatDamageEvent(JsonConvert.DeserializeObject<HeatDamageInfo>(json, JsonSettings.Settings));

    }
}
