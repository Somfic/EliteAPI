using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ModuleInfoInfo : EventBase
    {
        internal static ModuleInfoInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeModuleInfoEvent(JsonConvert.DeserializeObject<ModuleInfoInfo>(json, JsonSettings.Settings));

    }
}
