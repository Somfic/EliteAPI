using System.Collections.Generic;

using Newtonsoft.Json;

namespace EliteAPI.Status.Modules.Raw
{
    internal class RawModules
    {
        [JsonProperty("Modules")]
        public IReadOnlyList<Module> Installed { get; set; }
    }
}