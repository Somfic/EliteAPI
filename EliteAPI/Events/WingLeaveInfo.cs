using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WingLeaveInfo : EventBase
    {
        internal static WingLeaveInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingLeaveEvent(JsonConvert.DeserializeObject<WingLeaveInfo>(json, JsonSettings.Settings));

    }
}
