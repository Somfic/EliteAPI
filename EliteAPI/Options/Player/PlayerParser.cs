using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EliteAPI.Options.Player;

public static class PlayerParser
{
    public static IReadOnlyCollection<PlayerSetting> Parse(string xml)
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

    private static PlayerSetting? ParseElement(XElement element)
    {
        var value = GetAttribute(element, "Value");
        if (value is null)
            return null;

        return new PlayerSetting
        {
            Name = element.Name.LocalName,
            Value = value
        };
    }

    private static string? GetAttribute(XElement? element, string name)
    {
        if (element is null)
            return null;

        return element.Attributes()
            .FirstOrDefault(a => string.Equals(a.Name.LocalName, name, StringComparison.OrdinalIgnoreCase))
            ?.Value;
    }
}
