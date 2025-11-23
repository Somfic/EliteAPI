using EliteAPI.Journals;

namespace EliteAPI.Tests;

public class JournalTests
{
    public static IEnumerable<Func<FileInfo>> GetFiles(string pattern)
    {
        var directory = new DirectoryInfo("../../../TestFiles");
        var files = directory.GetFiles(pattern, SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var capturedFile = file;
            yield return () => capturedFile;
        }
    }

    public static IEnumerable<Func<FileInfo>> GetJournalFiles() => GetFiles("*.log");
    public static IEnumerable<Func<FileInfo>> GetStatusFiles() => GetFiles("*.json");

    [Test]
    [MethodDataSource(nameof(GetStatusFiles))]
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

    [Test]
    [MethodDataSource(nameof(GetJournalFiles))]
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
                Assert.Fail($"{ex.Message}\n{json}");
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
