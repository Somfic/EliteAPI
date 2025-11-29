using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace EliteAPI.Bindings;

public static class BindingParser
{
    public static IReadOnlyCollection<Control> Parse(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            var root = doc.Root;

            var controls = root.Elements()
                .Select(ParseElement)
                .ToArray();

            return controls;
        }
        catch (Exception e)
        {
            return [];
        }
    }

    private static Control ParseElement(XElement element)
    {
        var primaryElement = GetChildElement(element, "Primary") ?? GetChildElement(element, "Binding");
        var secondaryElement = GetChildElement(element, "Secondary");

        var deadzoneRaw = GetAttribute(GetChildElement(element, "Deadzone"), "Value");
        var invertedRaw = GetAttribute(GetChildElement(element, "Inverted"), "Value");
        var toggleRaw = GetAttribute(GetChildElement(element, "ToggleOn"), "Value");

        return new Control
        {
            Name = element.Name.LocalName,
            Primary = ParseBinding(primaryElement),
            Secondary = ParseBinding(secondaryElement),
            Deadzone = ParseFloat(deadzoneRaw),
            IsToggle = ParseBool(toggleRaw),
            IsInverted = ParseBool(invertedRaw)
        };
    }

    /// <summary>
    /// Parse a single binding element (Binding/Primary/Secondary), including Modifiers,
    /// handling casing and "unbound" semantics.
    /// </summary>
    private static Binding? ParseBinding(XElement? element)
    {
        if (element is null)
            return null;

        var device = GetAttribute(element, "Device") ?? string.Empty;
        var key = GetAttribute(element, "Key") ?? string.Empty;

        // Treat unbound bindings (NoDevice / empty key) as null
        if (IsUnbound(device, key))
            return null;

        // Parse child <Modifier> elements (case-insensitive)
        var modifiers = element
            .Elements()
            .Where(e => string.Equals(e.Name.LocalName, "Modifier", StringComparison.OrdinalIgnoreCase))
            .Select(m =>
            {
                var mDevice = GetAttribute(m, "Device") ?? string.Empty;
                var mKey = GetAttribute(m, "Key") ?? string.Empty;
                return (IBinding)new Binding(mDevice, mKey);
            })
            .ToArray();

        return new Binding(device, key, modifiers.Length == 0 ? null : modifiers);
    }

    /// <summary>
    /// Decide when a binding is "unbound" and should be treated as null.
    /// </summary>
    private static bool IsUnbound(string device, string key)
    {
        // Classic ED unbound pattern: {NoDevice} + empty key
        if (string.Equals(device, "{NoDevice}", StringComparison.OrdinalIgnoreCase))
            return true;

        // No key at all = unbound (even if device is set)
        if (string.IsNullOrWhiteSpace(key))
            return true;

        // Super defensive: both empty
        if (string.IsNullOrWhiteSpace(device) && string.IsNullOrWhiteSpace(key))
            return true;

        return false;
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

    private static XElement? GetChildElement(XElement parent, string name) =>
        parent.Elements()
            .FirstOrDefault(e => string.Equals(e.Name.LocalName, name, StringComparison.OrdinalIgnoreCase));

    private static string? GetAttribute(XElement? element, string name)
    {
        if (element is null)
            return null;

        return element.Attributes()
            .FirstOrDefault(a => string.Equals(a.Name.LocalName, name, StringComparison.OrdinalIgnoreCase))
            ?.Value;
    }
}
