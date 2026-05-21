using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace EliteAPI.Options.Audio;

public static class AudioParser
{
    public static IReadOnlyCollection<AudioSetting> Parse(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            var root = doc.Root;

            if (root is null)
                return [];

            var settings = root.Elements()
                .Select(ParseElement)
                .Where(s => s.HasValue)
                .Select(s => s!.Value)
                .ToArray();

            return settings;
        }
        catch
        {
            return [];
        }
    }

    private static AudioSetting? ParseElement(XElement element)
    {
        var valueRaw = GetAttribute(element, "Value");
        var mutedRaw = GetAttribute(element, "Muted");
        var enabledRaw = GetAttribute(element, "Enabled");

        if (valueRaw is not null)
        {
            var value = ParseFloat(valueRaw);
            if (value is null)
                return null;

            return new AudioSetting
            {
                Name = element.Name.LocalName,
                Value = value,
                IsMuted = ParseBool(mutedRaw)
            };
        }

        if (enabledRaw is not null)
        {
            return new AudioSetting
            {
                Name = element.Name.LocalName,
                IsEnabled = ParseBool(enabledRaw)
            };
        }

        return null;
    }

    private static float? ParseFloat(string? raw) =>
        float.TryParse(raw, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
            ? value
            : null;

    private static bool? ParseBool(string? raw) => raw switch
    {
        "1" => true,
        "0" => false,
        null => null,
        _ => null
    };

    private static string? GetAttribute(XElement? element, string name)
    {
        if (element is null)
            return null;

        return element.Attributes()
            .FirstOrDefault(a => string.Equals(a.Name.LocalName, name, StringComparison.OrdinalIgnoreCase))
            ?.Value;
    }
}
