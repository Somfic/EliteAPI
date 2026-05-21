using EliteAPI.Options.Audio;
using FluentAssertions;

namespace EliteAPI.Tests.Audio;

public class AudioParserTests
{
    [Fact]
    public void Parse_Sample_File()
    {
        string xml = File.ReadAllText("TestFiles/Audio/Custom.4.3.audio");

        var content = AudioParser.Parse(xml);

        content.Should().NotBeNull();
        content.Should().NotBeEmpty();
    }

    [Fact]
    public void Parse_Should_Read_Volume_Settings()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
            <Root PresetName=""Custom"" MajorVersion=""4"" MinorVersion=""3"">
                <SoundEffectsVolume Value=""83.03371429"" Muted=""0"" />
                <MusicVolume Value=""35.53370667"" Muted=""1"" />
            </Root>";

        var settings = AudioParser.Parse(xml).ToDictionary(s => s.Name);

        settings.Should().ContainKeys("SoundEffectsVolume", "MusicVolume");

        var effects = settings["SoundEffectsVolume"];
        effects.IsVolume.Should().BeTrue();
        effects.IsToggle.Should().BeFalse();
        effects.Value.Should().BeApproximately(83.03f, 0.01f);
        effects.IsMuted.Should().BeFalse();
        effects.IsEnabled.Should().BeNull();

        var music = settings["MusicVolume"];
        music.IsVolume.Should().BeTrue();
        music.Value.Should().BeApproximately(35.53f, 0.01f);
        music.IsMuted.Should().BeTrue();
    }

    [Fact]
    public void Parse_Should_Read_Toggle_Settings()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
            <Root>
                <CombatMusicEnabled Enabled=""1"" />
                <StreamerModeEnabled Enabled=""0"" />
            </Root>";

        var settings = AudioParser.Parse(xml).ToDictionary(s => s.Name);

        var combat = settings["CombatMusicEnabled"];
        combat.IsToggle.Should().BeTrue();
        combat.IsVolume.Should().BeFalse();
        combat.IsEnabled.Should().BeTrue();
        combat.Value.Should().BeNull();
        combat.IsMuted.Should().BeNull();

        var streamer = settings["StreamerModeEnabled"];
        streamer.IsToggle.Should().BeTrue();
        streamer.IsEnabled.Should().BeFalse();
    }

    [Fact]
    public void Parse_Should_Skip_Unknown_Element_Shapes()
    {
        const string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
            <Root>
                <MusicVolume Value=""50"" Muted=""0"" />
                <SomeUnknownThing Foo=""bar"" />
                <CombatMusicEnabled Enabled=""1"" />
            </Root>";

        var settings = AudioParser.Parse(xml).ToArray();

        settings.Should().HaveCount(2);
        settings.Select(s => s.Name).Should().NotContain("SomeUnknownThing");
    }

    [Fact]
    public void Parse_Should_Return_Empty_For_Malformed_Xml()
    {
        var settings = AudioParser.Parse("not valid xml <<<");

        settings.Should().NotBeNull();
        settings.Should().BeEmpty();
    }

    [Fact]
    public void Parse_Real_Preset_Contains_Known_Settings()
    {
        string xml = File.ReadAllText("TestFiles/Audio/Custom.4.3.audio");

        var settings = AudioParser.Parse(xml).ToDictionary(s => s.Name);

        settings.Should().ContainKey("MusicVolume");
        settings.Should().ContainKey("SoundEffectsVolume");
        settings.Should().ContainKey("CombatMusicEnabled");

        settings["MusicVolume"].IsVolume.Should().BeTrue();
        settings["MusicVolume"].IsMuted.Should().BeTrue();
        settings["SoundEffectsVolume"].IsMuted.Should().BeFalse();
        settings["CombatMusicEnabled"].IsEnabled.Should().BeTrue();
    }
}
