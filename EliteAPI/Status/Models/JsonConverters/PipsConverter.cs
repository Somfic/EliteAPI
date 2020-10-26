using System;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;

namespace EliteAPI.Status.Models.JsonConverters
{
    internal class PipsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            ShipPips pips = (ShipPips) value;

            writer.WriteStartArray();
            writer.WriteValue(pips.System);
            writer.WriteValue(pips.Engines);
            writer.WriteValue(pips.Weapons);
            writer.WriteEndArray();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            int systems = reader.ReadAsInt32().Value;
            int engines = reader.ReadAsInt32().Value;
            int weapons = reader.ReadAsInt32().Value;

            reader.Read();

            return new ShipPips(new [] {systems, engines, weapons});
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(ICollection));
        }
    }
}