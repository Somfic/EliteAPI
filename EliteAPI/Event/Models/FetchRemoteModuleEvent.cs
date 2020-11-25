
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FetchRemoteModuleEvent : EventBase
    {
        internal FetchRemoteModuleEvent() { }

        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; private set; }

        [JsonProperty("StoredItem")]
        public string StoredItem { get; private set; }

        [JsonProperty("StoredItem_Localised")]
        public string StoredItemLocalised { get; private set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; private set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; private set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; private set; }

        [JsonProperty("Ship")]
        public string Ship { get; private set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; private set; }
    }

    public partial class FetchRemoteModuleEvent
    {
        public static FetchRemoteModuleEvent FromJson(string json) => JsonConvert.DeserializeObject<FetchRemoteModuleEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FetchRemoteModuleEvent> FetchRemoteModuleEvent;
        internal void InvokeFetchRemoteModuleEvent(FetchRemoteModuleEvent arg) => FetchRemoteModuleEvent?.Invoke(this, arg);
    }
}
