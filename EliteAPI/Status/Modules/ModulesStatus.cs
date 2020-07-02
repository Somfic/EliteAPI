﻿using System;
using System.Collections.Generic;
using System.Text;
using EliteAPI.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status.Modules
{
    public class ModulesStatus : StatusBase
    {
        internal ModulesStatus() { }

        [JsonProperty("Modules")]
        public IReadOnlyList<Module> Modules { get; internal set; }

        internal override StatusBase Default => new ModulesStatus();
    }
}