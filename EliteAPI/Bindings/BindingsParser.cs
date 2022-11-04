using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using EliteAPI.Abstractions.Bindings;
using EliteAPI.Abstractions.Bindings.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Bindings;

public class BindingsParser : IBindingsParser
{
    private readonly ILogger<BindingsParser>? _log;
    private readonly List<(Delegate d, bool hasContext)> _loadedHandlers = new();

    public BindingsParser(ILogger<BindingsParser>? log)
    {
        _log = log;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<Binding> Parse(string xml)
    {
        try
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            var root = document.DocumentElement;

            var bindings = new List<Binding>();

            for (var i = 0; i < root?.ChildNodes.Count; i++)
            {
                var node = root.ChildNodes.Item(i);

                bindings.Add(ParseNode(node));
            }

            return bindings;
        }
        catch (Exception ex)
        {
            _log?.LogError(ex, "Failed to parse bindings");
            return Array.Empty<Binding>();
        }
    }

    private Binding ParseNode(XmlNode node)
    {
        var subBindings = new List<ISubBinding>();

        var bindingNode = GetChild(node, "Binding");
        if (bindingNode != null)
        {
            var binding = ParseBinding(bindingNode);
            subBindings.Add(new PrimarySubBinding(binding));
        }
        
        var primaryNode = GetChild(node, "Primary");
        if (primaryNode != null)
        {
            var binding = ParseBinding(primaryNode);
            subBindings.Add(new PrimarySubBinding(binding));
        }

        var secondaryNode = GetChild(node, "Secondary");
        if (secondaryNode != null)
        {
            var binding = ParseBinding(secondaryNode);
            subBindings.Add(new PrimarySubBinding(binding));
        }

        var invertedNode = GetChild(node, "Inverted");
        if (invertedNode != null)
        {
            var inverted = new InvertedSubBinding(invertedNode.Attributes["Value"].Value.Equals("1"));
            subBindings.Add(inverted);
        }

        var deadzoneNode = GetChild(node, "Deadzone");
        if (deadzoneNode != null)
        {
            var deadZone = new DeadzoneSubBinding(float.Parse(deadzoneNode.Attributes["Value"].Value));
            subBindings.Add(deadZone);
        }
        
        var name = node.Name;
        var builtBinding = BuildBindings(name, subBindings);
        
        return builtBinding;
    }

    private (string key, string device, ModifierBinding[] modifiers) ParseBinding(XmlNode node)
    {
        var modifierNodes = GetChildren(node, "Modifier");
        var modifiers = modifierNodes.Any() ? modifierNodes.Select(modifierNode => new ModifierBinding(modifierNode.Attributes?["Key"].Value,modifierNode.Attributes?["Device"].Value)) : Array.Empty<ModifierBinding>();

        return (
            node.Attributes["Key"].Value,
            node.Attributes["Device"].Value,
            modifiers.ToArray()
        );
    }
    
    private IReadOnlyCollection<XmlNode> GetChildren(XmlNode node, string name)
    {
        var children = new List<XmlNode>();

        for (var i = 0; i < node.ChildNodes.Count; i++)
        {
            var child = node.ChildNodes[i];
            if (child.Name == name)
            {
                children.Add(child);
            }
        }

        return children;
    }

    private XmlNode? GetChild(XmlNode node, string name)
    {
        var index = GetChildIndex(node, name);
        return !index.HasValue ? null : node.ChildNodes.Item(index.Value);
    }
    
    private int? GetChildIndex(XmlNode node, string name)
    {
        for (var i = 0; i < node.ChildNodes.Count; i++)
        {
            var child = node.ChildNodes[i];
            if (child.Name == name)
            {
                return i;
            }
        }

        return null;
    }

    private Binding BuildBindings(string name, List<ISubBinding> subBindings)
    {
        return new Binding
        {
            Name = name,
            Primary = subBindings.OfType<PrimarySubBinding>().FirstOrDefault(),
            Secondary = subBindings.OfType<SecondarySubBinding>().FirstOrDefault(),
            IsToggle = subBindings.OfType<ToggleSubBinding>().Any()
                ? subBindings.OfType<ToggleSubBinding>().First().Value
                : null,
            IsInverted = subBindings.OfType<InvertedSubBinding>().Any()
                ? subBindings.OfType<InvertedSubBinding>().First().Value
                : null,
            Deadzone = subBindings.OfType<DeadzoneSubBinding>().Any()
                ? subBindings.OfType<DeadzoneSubBinding>().First().Value : null
        };
    }
}

internal static class Helper
{
    public static void SetValue<T>(this T sender, string propertyName, object value)
    {
        var propertyInfo = sender.GetType().GetProperty(propertyName);
 
        if (propertyInfo is null) {}
 
        var type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
     
        if (propertyInfo.PropertyType.IsEnum)
        {
            propertyInfo.SetValue(sender, Enum.Parse(propertyInfo.PropertyType, value.ToString()!));
        }
        else
        {
            var safeValue = (value == null) ? null : Convert.ChangeType(value, type);
            propertyInfo.SetValue(sender, safeValue, null);
        }
    }
}