using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SRVDestroyedInfo : EventBase
    {
        internal static SRVDestroyedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSRVDestroyedEvent(JsonConvert.DeserializeObject<SRVDestroyedInfo>(json, JsonSettings.Settings));

    }
}
