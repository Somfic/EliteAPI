using System;
using System.Linq;
using EliteAPI.Abstractions.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Events;

// Converts "Message": "symbol", "Message_Localised": "value"
//       to "Message": { Symbol: "symbol", "Local": "value" }

public class LocalisedConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? rawValue, JsonSerializer serializer)
    {
        if (rawValue == null)
            return;

        var value = (Localised) rawValue;
        writer.WriteValue(value.Symbol);

        var name = writer.Path.Split('.').Last();

        writer.WritePropertyName($"{name}_Localised");
        writer.WriteValue(value.Local);
    }

    /// <inheritdoc />
    public override object? ReadJson(JsonReader reader, Type objectType, object? rawValue, JsonSerializer serializer)
    {
        var symbol = JToken.Load(reader).ToString();
        return new Localised(symbol);
    }

    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Localised);
    }
}