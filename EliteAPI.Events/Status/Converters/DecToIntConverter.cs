using Newtonsoft.Json;

namespace EliteAPI.Events.Status.Converters;

internal class DecToIntConverter : JsonConverter
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
        switch (value)
        {
            case decimal decimalValue:
            {
                var precision = (decimal.GetBits(decimalValue)[3] >> 16) & 0x000000FF;
                return precision == 0;
            }
            case float or double:
            {
                var doubleValue = (double) value;
                return Math.Abs(doubleValue - Math.Truncate(doubleValue)) < 0.00001;
            }
            default:
                return false;
        }
    }
}