using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EliteAPI.Status.Modules.Raw
{
    internal class RawModules
    {
        [JsonProperty("Modules")]
        public IReadOnlyList<Module> Installed { get; set; }
    }
}
