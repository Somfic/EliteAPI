using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using ProtoBuf;

namespace EliteAPI.Event.Models.Abstractions
{
    /// <summary>
    /// An in-game event
    /// </summary>
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public abstract class EventBase<T> : IEvent where T : IEvent
    {
        /// <inheritdoc />
        public DateTime Timestamp { get; protected set; } = DateTime.Now;

        /// <inheritdoc />
        public string Event { get; protected set; }

        /// <summary>
        /// Generates an event entry from Json
        /// </summary>
        /// <param name="json">The json string</param>
        public static T FromJson(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <inheritdoc />
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings {ContractResolver = new JsonContractResolver()});
        }
    }

}