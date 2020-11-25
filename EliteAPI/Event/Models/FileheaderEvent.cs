
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FileheaderEvent : EventBase
    {
        internal FileheaderEvent() { }

        [JsonProperty("part")]
        public long Part { get; private set; }

        [JsonProperty("language")]
        public string Language { get; private set; }

        [JsonProperty("gameversion")]
        public string Gameversion { get; private set; }

        [JsonProperty("build")]
        public string Build { get; private set; }
    }

    public partial class FileheaderEvent
    {
        public static FileheaderEvent FromJson(string json) => JsonConvert.DeserializeObject<FileheaderEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FileheaderEvent> FileheaderEvent;
        internal void InvokeFileheaderEvent(FileheaderEvent arg) => FileheaderEvent?.Invoke(this, arg);
    }
}
