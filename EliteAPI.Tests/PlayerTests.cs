using EliteAPI.Options.Player;
using FluentAssertions;

namespace EliteAPI.Tests.Player;

public class PlayerParserTests
{
    [Fact]
    public void Parse_Sample_File()
    {
        string xml = File.ReadAllText("TestFiles/Player/Custom.4.3.misc");

        var content = PlayerParser.Parse(xml);

        content.Should().NotBeNull();
        content.Should().NotBeEmpty();
    }

    [Fact]
    public void Parse_Should_Read_String_And_Numeric_Values_As_Raw_Strings()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
            <Root PresetName=""Custom"" MajorVersion=""4"" MinorVersion=""3"">
                <GunsightMode Value=""Bindings_TraditionalGunsights"" />
                <DashboardGUIBrightness Value=""0.69000000"" />
                <ClockEnabled Value=""1"" />
            </Root>";

        var settings = PlayerParser.Parse(xml).ToDictionary(s => s.Name);

        settings["GunsightMode"].Value.Should().Be("Bindings_TraditionalGunsights");
        settings["DashboardGUIBrightness"].Value.Should().Be("0.69000000");
        settings["ClockEnabled"].Value.Should().Be("1");
    }

    [Fact]
    public void Parse_Should_Skip_Elements_Without_Value_Attribute()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
            <Root>
                <ClockEnabled Value=""1"" />
                <VisibilityFlags />
                <QuickItems></QuickItems>
                <Language Value=""English"" />
            </Root>";

        var settings = PlayerParser.Parse(xml).ToArray();

        settings.Should().HaveCount(2);
        settings.Select(s => s.Name).Should().BeEquivalentTo(new[] { "ClockEnabled", "Language" });
    }

    [Fact]
    public void Parse_Should_Return_Empty_For_Malformed_Xml()
    {
        var settings = PlayerParser.Parse("not valid xml <<<");

        settings.Should().NotBeNull();
        settings.Should().BeEmpty();
    }

    [Fact]
    public void Parse_Real_Preset_Contains_Known_Settings()
    {
        string xml = File.ReadAllText("TestFiles/Player/Custom.4.3.misc");

        var settings = PlayerParser.Parse(xml).ToDictionary(s => s.Name);

        settings.Should().ContainKey("Language");
        settings.Should().ContainKey("ClockEnabled");
        settings.Should().ContainKey("GunsightMode");
    }
}
