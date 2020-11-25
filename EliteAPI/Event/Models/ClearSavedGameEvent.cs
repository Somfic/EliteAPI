
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class ClearSavedGameEvent : EventBase
    {
        internal ClearSavedGameEvent() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("FID")]
        public string Fid { get; private set; }
    }

    public partial class ClearSavedGameEvent
    {
        public static ClearSavedGameEvent FromJson(string json) => JsonConvert.DeserializeObject<ClearSavedGameEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<ClearSavedGameEvent> ClearSavedGameEvent;
        internal void InvokeClearSavedGameEvent(ClearSavedGameEvent arg) => ClearSavedGameEvent?.Invoke(this, arg);
    }
}
