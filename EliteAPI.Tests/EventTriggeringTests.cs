namespace EliteAPI.Tests;

public class EventTriggeringTests
{
    [Test]
    public async Task StatusInCombat()
    {
        // var json = await File.ReadAllTextAsync("../../../TestFiles/Status/StatusCombat.json");
        // var paths = JournalUtils.ToPaths(json);

        // JsonPath[] expectedPaths = [
        //     new JsonPath("EliteAPI.event",  "Status",  JsonType.String),
        //     new JsonPath("EliteAPI.Status",  262144,  JsonType.Number),
        // ];

        // foreach (var expectedPath in expectedPaths)
        // {
        //     paths.Should().ContainEquivalentOf(expectedPath);
        // }
    }

    // [Test]
    // [MethodDataSource(nameof(GetStatusFiles))]
    // public async Task StatusFile(FileInfo file)
    // {
    //     var json = await File.ReadAllTextAsync(file.FullName);
    //     await Assert.That(json).IsEqualTo("poop");
    // }
}
