using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FighterDestroyedInfo : EventBase
    {
        internal static FighterDestroyedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFighterDestroyedEvent(JsonConvert.DeserializeObject<FighterDestroyedInfo>(json, JsonSettings.Settings));

    }
}
