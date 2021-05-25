using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class BookTaxiEvent : EventBase<BookTaxiEvent>
    {
        internal BookTaxiEvent() { }

        [JsonProperty("Cost")]
        public long Cost { get; private set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; private set; }

        [JsonProperty("DestinationLocation")]
        public string DestinationLocation { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<BookTaxiEvent> BookTaxiEvent;

        internal void InvokeBookTaxiEvent(BookTaxiEvent arg)
        {
            BookTaxiEvent?.Invoke(this, arg);
        }
    }
}