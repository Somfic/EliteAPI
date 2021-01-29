using System;

using Newtonsoft.Json;

namespace EliteAPI.Status.Ship.JsonConverters
{
    internal class DecimalToIntConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanRead => false;

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (IsWholeValue(value))
                writer.WriteRawValue(JsonConvert.ToString(Convert.ToInt64(value)));
            else
                writer.WriteRawValue(JsonConvert.ToString(value));
        }


        /// <inheritdoc />
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal) || objectType == typeof(float) || objectType == typeof(double);
        }

        private static bool IsWholeValue(object value)
        {
            if (value is decimal)
            {
                var decimalValue = (decimal) value;
                var precision = (decimal.GetBits(decimalValue)[3] >> 16) & 0x000000FF;
                return precision == 0;
            }

            if (value is float || value is double)
            {
                var doubleValue = (double) value;
                return doubleValue == Math.Truncate(doubleValue);
            }

            return false;
        }
    }
}