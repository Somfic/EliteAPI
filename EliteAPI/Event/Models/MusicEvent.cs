using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public partial class MusicEvent : EventBase
    {
        internal MusicEvent()
        {
        }

        [JsonProperty("MusicTrack")] public string MusicTrack { get; private set; }
    }

    public partial class MusicEvent
    {
        public static MusicEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MusicEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<MusicEvent> MusicEvent;

        internal void InvokeMusicEvent(MusicEvent arg)
        {
            MusicEvent?.Invoke(this, arg);
        }
    }
}