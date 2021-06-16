using System.Collections.Generic;

using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Market.Raw;

using Newtonsoft.Json;

namespace EliteAPI.Status.Modules.Raw
{
    public class RawModules : EventBase<RawModules>, IRawStatus
    {
        [JsonProperty("Modules")]
        public IReadOnlyList<Module> Installed { get; set; }
    }
}