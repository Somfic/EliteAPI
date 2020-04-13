using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Modules
{
    public class ModulesStatus : EventBase
    {
        internal ModulesStatus() { }

        [JsonProperty("Modules")]
        public IReadOnlyList<Module> Modules { get; internal set; }
    }
}
