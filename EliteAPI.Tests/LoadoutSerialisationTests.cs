using EliteAPI.Events.Game;
using EliteAPI.Json;
using FluentAssertions;
using Newtonsoft.Json;

namespace EliteAPI.Tests;

public class LoadoutSerialisationTests
{
    [Fact]
    public void EngineeredModule_BindsModifiersToModifications()
    {
        var json = File.ReadAllText("../../../TestFiles/Status/Loadout.json");

        var loadout = JsonConvert.DeserializeObject<LoadoutEvent>(json, JsonUtils.SerializerSettings);

        var frameShiftDrive = loadout.Modules.Single(module =>
            string.Equals(module.Slot, "FrameShiftDrive", StringComparison.OrdinalIgnoreCase));

        frameShiftDrive.Engineering.Modifications.Should().NotBeNull();
    }
}
