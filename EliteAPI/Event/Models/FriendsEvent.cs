
namespace EliteAPI.Event.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Abstractions;


    public partial class FriendsEvent : EventBase
    {
        internal FriendsEvent() { }

        [JsonProperty("Status")]
        public string Status { get; private set; }

        [JsonProperty("Name")]
        public string Name { get; private set; }
    }

    public partial class FriendsEvent
    {
        public static FriendsEvent FromJson(string json) => JsonConvert.DeserializeObject<FriendsEvent>(json);
    }

    
}

namespace EliteAPI.Event.Handler
{
    using System;
    using Models;

    public partial class EventHandler
    {
        public event EventHandler<FriendsEvent> FriendsEvent;
        internal void InvokeFriendsEvent(FriendsEvent arg) => FriendsEvent?.Invoke(this, arg);
    }
}
