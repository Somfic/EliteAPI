using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EliteAPI.Json.SerializationSettings;

public class EventContractResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        // Let the base class create all the JsonProperties 
        // using the short names
        var list = base.CreateProperties(type, memberSerialization);

        // Now inspect each property and replace the 
        // short name with the real property name
        foreach (var prop in list) prop.PropertyName = prop.UnderlyingName;

        return list;
    }
}
