using System;

namespace EliteAPI.Events
{
    public class StatusEvent : EventBase
    {
        public StatusEvent(string @event, object value)
        {
            this.Event = @event;
            this.@event = @event;
            this.Value = value;
            this.value = value;

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