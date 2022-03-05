using System.Collections;
using EliteAPI.Events.Status.Ship;
using Newtonsoft.Json;

namespace EliteAPI.Events.Status.Converters;

internal class PipsConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
            return;
            
        var pips = (ShipPips) value;

        writer.WriteStartArray();
        writer.WriteValue(pips.System);
        writer.WriteValue(pips.Engines);
        writer.WriteValue(pips.Weapons);
        writer.WriteEndArray();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var systems = reader.ReadAsInt32();
        var engines = reader.ReadAsInt32();
        var weapons = reader.ReadAsInt32();

        reader.Read();

        return new ShipPips(new[] {systems ?? 0, engines ?? 0, weapons ?? 0});
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType.GetInterfaces().Contains(typeof(ICollection));
    }
}