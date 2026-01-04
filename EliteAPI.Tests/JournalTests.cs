using EliteAPI.Journals;

namespace EliteAPI.Tests;

public class JournalTests
{
    public static IEnumerable<object[]> GetFiles(string pattern)
    {
        var directory = new DirectoryInfo("../../../TestFiles");
        var files = directory.GetFiles(pattern, SearchOption.AllDirectories);

        foreach (var file in files)
        {
            yield return new object[] { file };
        }
    }

    public static IEnumerable<object[]> GetJournalFiles() => GetFiles("*.log");
    public static IEnumerable<object[]> GetStatusFiles() => GetFiles("*.json");

    [Theory]
    [MemberData(nameof(GetStatusFiles))]
    public async Task StatusFile(FileInfo file)
    {
        var json = await File.ReadAllTextAsync(file.FullName);

        try
        {
            JournalUtils.ToPaths(json);
        }
        catch (Exception ex)
        {
            Assert.Fail($"{ex.Message}\n{json}");
        }
    }

    [Theory]
    [MemberData(nameof(GetJournalFiles))]
    public async Task JournalFile(FileInfo file)
    {
        var jsons = await File.ReadAllLinesAsync(file.FullName);

        foreach (var json in jsons)
        {
            try
            {
                JournalUtils.ToPaths(json);
            }
            catch (Exception ex)
            {
                Xunit.Assert.Fail($"{ex.Message}\n{json}");
            }
        }
    }

    // [Test]
    // [MethodDataSource(nameof(GetStatusFiles))]
    // public async Task StatusFile(FileInfo file)
    // {
    //     var json = await File.ReadAllTextAsync(file.FullName);
    //     await Assert.That(json).IsEqualTo("poop");
    // }
}
