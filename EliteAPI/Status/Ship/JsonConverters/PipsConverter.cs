using System;
using System.Collections;
using System.Linq;
using EliteAPI.Status.Models;
using Newtonsoft.Json;

namespace EliteAPI.Status.Ship.JsonConverters
{
    internal class PipsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
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
            var systems = reader.ReadAsInt32().Value;
            var engines = reader.ReadAsInt32().Value;
            var weapons = reader.ReadAsInt32().Value;

            reader.Read();

            return new ShipPips(new[] {systems, engines, weapons});
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(ICollection));
        }
    }
}