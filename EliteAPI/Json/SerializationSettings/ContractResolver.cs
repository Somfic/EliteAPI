using System;
using System.Collections.Generic;
using System.Linq;
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

        // Fall back to the C# member name only when the member does not
        // declare an explicit [JsonProperty("...")] name. Honouring the
        // attribute is what lets renamed members (e.g. Modifications ->
        // "Modifiers", IsOn -> "On") bind to their journal keys.
        foreach (var prop in list)
        {
            var hasExplicitName = prop.AttributeProvider?
                .GetAttributes(typeof(JsonPropertyAttribute), true)
                .OfType<JsonPropertyAttribute>()
                .Any(a => a.PropertyName != null) ?? false;

            if (!hasExplicitName)
                prop.PropertyName = prop.UnderlyingName;
        }

        return list;
    }
}
