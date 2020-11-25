
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class StoredShipsEvent : EventBase
    {
        internal StoredShipsEvent() { }

        [JsonProperty("StationName")]
        public string StationName { get; private set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; private set; }

        [JsonProperty("ShipsHere")]
        public IReadOnlyList<ShipsHere> ShipsHere { get; private set; }

        [JsonProperty("ShipsRemote")]
        public IReadOnlyList<object> ShipsRemote { get; private set; }
    }

    public partial class ShipsHere
    {
        internal ShipsHere() { }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; private set; }

        [JsonProperty("Value")]
        public long Value { get; private set; }

        [JsonProperty("Hot")]
        public bool Hot { get; private set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; private set; }
    }

    public partial class StoredShipsEvent
    {
        public static StoredShipsEvent FromJson(string json) => JsonConvert.DeserializeObject<StoredShipsEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<StoredShipsEvent> StoredShipsEvent;
        internal void InvokeStoredShipsEvent(StoredShipsEvent arg) => StoredShipsEvent?.Invoke(this, arg);
    }
}
