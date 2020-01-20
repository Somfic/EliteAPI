using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SelfDestructInfo : EventBase
    {
        internal static SelfDestructInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSelfDestructEvent(JsonConvert.DeserializeObject<SelfDestructInfo>(json, JsonSettings.Settings));

    }
}
