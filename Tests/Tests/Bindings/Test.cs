using EliteAPI.Bindings;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Bindings;

public class Test
{
    [Fact]
    public void Parsing()
    {
        var parser = new BindingsParser(Mock.Of<ILogger<BindingsParser>>());
        // Read embedded file
        var xml = Helper.GetResource( "Tests.Bindings.Bindings");

        var parsed = parser.Parse(xml).Where(x => x.Primary?.Device == "Keyboard" || x.Secondary?.Device == "Keyboard");
        
        parsed.Should().NotBeNull();
        parsed.Count().Should().Be(138);
    }

    [Fact]
    public void Finding()
    {
        var parser = new BindingsParser(Mock.Of<ILogger<BindingsParser>>());
        // Read embedded file
        var xml = Helper.GetResource( "Tests.Bindings.Bindings");

        var parsed = parser.Parse(xml).Where(x => x.Primary?.Device == "Keyboard" || x.Secondary?.Device == "Keyboard");
        
        parsed.Should().NotBeNull();
        parsed.FirstOrDefault(x => x.Name == "PitchUpButton").Secondary.Should().NotBeNull();
    }
}