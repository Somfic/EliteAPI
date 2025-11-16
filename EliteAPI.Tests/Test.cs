namespace EliteAPI.Tests;

public class Test
{
    public static IEnumerable<FileInfo> GetFiles(string pattern)
    {
        var directory = new DirectoryInfo("../../../TestFiles");
        var files = directory.GetFiles(pattern, SearchOption.AllDirectories);

        foreach (var file in files)
            yield return file;
    }

    public static IEnumerable<FileInfo> GetJournalFiles() => GetFiles("*.log");
    public static IEnumerable<FileInfo> GetStatusFiles() => GetFiles("*.json");

    [Test]
    [MethodDataSource(nameof(GetJournalFiles))]
    public async Task JournalFile(FileInfo file)
    {
        var jsons = await File.ReadAllLinesAsync(file.FullName);

        foreach (var json in jsons)
            await Assert.That(json).IsEqualTo("poop");
    }

    [Test]
    [MethodDataSource(nameof(GetStatusFiles))]
    public async Task StatuslFile(FileInfo file)
    {
        var json = await File.ReadAllTextAsync(file.FullName);
        await Assert.That(json).IsEqualTo("poop");
    }
}
