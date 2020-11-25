
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class MusicEvent : EventBase
    {
        internal MusicEvent() { }

        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; private set; }
    }

    public partial class MusicEvent
    {
        public static MusicEvent FromJson(string json) => JsonConvert.DeserializeObject<MusicEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<MusicEvent> MusicEvent;
        internal void InvokeMusicEvent(MusicEvent arg) => MusicEvent?.Invoke(this, arg);
    }
}
