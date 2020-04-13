using System;

namespace EliteAPI.Events
{
    public class StatusEvent : EventBase
    {
        public StatusEvent(string Event, dynamic Value)
        {
            this.Event = Event;
            @event = Event;
            this.Value = Value;
            value = Value;
            this.Timestamp = DateTime.Now;
        }

        public string Event { get; set; }

        public string @event
        {
            get => Event;
            set => Event = value;
        }

        public dynamic Value { get; set; }

        public dynamic value
        {
            get => Value;
            set => Value = value;
        }
    }
}