using System;
using System.Linq;
using EliteAPI.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.Json.SerializationSettings;

// Converts "Message": "symbol", "Message_Localised": "value"
//       to "Message": { Symbol: "symbol", "Local": "value" }
public class LocalisedConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? rawValue, JsonSerializer serializer)
    {
        if (rawValue == null)
            return;

        var value = (LocalisedField)rawValue;
        writer.WriteValue(value.Symbol);

        var name = writer.Path.Split('.').Last();

        writer.WritePropertyName($"{name}_Localised");
        writer.WriteValue(value.Local);
    }

    /// <inheritdoc />
    public override object? ReadJson(JsonReader reader, Type objectType, object? rawValue, JsonSerializer serializer)
    {
        var symbol = JToken.Load(reader).ToString();
        return new LocalisedField(symbol);
    }

    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(LocalisedField);
    }
}

