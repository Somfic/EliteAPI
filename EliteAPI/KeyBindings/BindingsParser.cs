using System;
using System.IO;
using System.Xml.Serialization;
using EliteAPI.Abstractions.KeyBindings;
using Microsoft.Extensions.Logging;

namespace EliteAPI.KeyBindings;

public class BindingsParser : IBindingsParser
{
    private readonly ILogger<BindingsParser>? _log;

    public BindingsParser(ILogger<BindingsParser>? log)
    {
        _log = log;
    }

    /// <inheritdoc />
    public Bindings ToBindings(string xml)
    {
        var serializer = new XmlSerializer(typeof(Bindings));
        using var reader = new StringReader(xml);

        if (serializer.Deserialize(reader) is not Bindings bindings)
        {
            _log?.LogWarning("Failed to deserialize bindings");
            return new Bindings();
        }
        
        return bindings;
    }
}