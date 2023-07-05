using System.Xml;
using EliteAPI.Abstractions.Bindings;
using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Bindings;
using Microsoft.Extensions.Logging;
using Moq;

namespace EliteAPI.Tests;

[TestFixture]
public class Bindings
{
    private static IBindingsParser _parser;

    [OneTimeSetUp]
    public void Setup()
    {
        _parser = new BindingsParser(Mock.Of<ILogger<BindingsParser>>());
    }
    
    [Test]
    public void Parsing()
    {
        var xml = File.ReadAllText("Bindings.xml");
        var bindings = _parser.Parse(xml);
    }
    
    [Test]
    [TestCaseSource(nameof(GetKeybindingNames))]
    public void Enum(string keybindingName)
    {
        Assert.That(System.Enum.TryParse(keybindingName, out KeyBinding keybinding), Is.True);
    }

    public static IEnumerable<string> GetKeybindingNames()
    {
        var bindings = File.ReadAllText("Bindings.xml");
        var xml = new XmlDocument();
        xml.LoadXml(bindings);
        
        var root = xml.DocumentElement;
        var nodes = root?.ChildNodes;
        
        for (var i = 0; i < nodes?.Count; i++)
        {
            var node = nodes.Item(i);
            var name = node?.Name;
            if (name != null) yield return name;
        }
    }
}