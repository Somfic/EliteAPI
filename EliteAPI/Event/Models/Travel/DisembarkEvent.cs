﻿using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DisembarkEvent : EventBase<DisembarkEvent>
    {
        internal DisembarkEvent() { }

        [JsonProperty("SRV")]
        public bool SRV { get; private set; }

        [JsonProperty("Taxi")]
        public bool Taxi { get; private set; }

        [JsonProperty("Multicrew")]
        public bool Multicrew { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")]
        public string SystemAddress { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

        [JsonProperty("BodyID")]
        public string BodyID { get; private set; }

        [JsonProperty("OnStation")]
        public bool OnStation { get; private set; }

        [JsonProperty("OnPlanet")]
        public bool OnPlanet { get; private set; }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("StationType")]
        public string StationType { get; private set; }

        [JsonProperty("MarketID")]
        public string MarketID { get; private set; }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DisembarkEvent> DisembarkEvent;

        internal void InvokeDisembarkEvent(DisembarkEvent arg)
        {
            DisembarkEvent?.Invoke(this, arg);
        }
    }
}