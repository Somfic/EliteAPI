using System;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Event.Models
{
    /// <summary>
    /// An empty event, for when the original event has not been implemented
    /// </summary>
    public class NotImplementedEvent : EventBase<NotImplementedEvent>
    {
        internal NotImplementedEvent(string json, JObject original)
        {
            Json = json;
            Timestamp = ((dynamic) original).timestamp;
            Event = ((dynamic) original).@event;
        }
        
        /// <summary>
        /// The original JSON entry
        /// </summary>
        public string Json { get; }
    }
}


namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<NotImplementedEvent> NotImplementedEvent;

        internal void InvokeNotImplementedEvent(NotImplementedEvent arg)
        {
            NotImplementedEvent?.Invoke(this, arg);
        }
    }
}