
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class CommanderEvent : EventBase
    {
        internal CommanderEvent() { }

        [JsonProperty("FID")]
        public string Fid { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

    public partial class CommanderEvent
    {
        public static CommanderEvent FromJson(string json) => JsonConvert.DeserializeObject<CommanderEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<CommanderEvent> CommanderEvent;
        internal void InvokeCommanderEvent(CommanderEvent arg) => CommanderEvent?.Invoke(this, arg);
    }
}
