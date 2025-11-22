using EliteAPI.Watcher;
using FluentAssertions;

namespace EliteAPI.Tests;

public class FileWatcherTests
{
    private DirectoryInfo _testDirectory = null!;

    [Before(HookType.Test)]
    public async Task Setup()
    {
        _testDirectory = Directory.CreateTempSubdirectory("EliteAPI_FileWatcher_Tests");
    }

    [After(HookType.Test)]
    public async Task Cleanup()
    {
        if (_testDirectory.Exists)
            _testDirectory.Delete(recursive: true);
    }

    [Test]
    public async Task EntireFileWatcher_Create_ReturnsInitialContent()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllTextAsync(testFile.FullName, "Initial content");

        var (watcher, initialContent) = EntireFileWatcher.Create(testFile);

        initialContent.Should().Be("Initial content");
        watcher.Should().NotBeNull();
    }

    [Test]
    public async Task EntireFileWatcher_OnChange_EmitsEntireFileContent()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllTextAsync(testFile.FullName, "Initial content");

        var (watcher, _) = EntireFileWatcher.Create(testFile);
        var changedContent = "";
        var tcs = new TaskCompletionSource<bool>();

        watcher.OnChange(content =>
        {
            changedContent = content;
            tcs.TrySetResult(true);
        });

        await Task.Delay(100); // Give watcher time to start
        await File.WriteAllTextAsync(testFile.FullName, "Updated content");

        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        changedContent.Should().Be("Updated content");
    }

    [Test]
    public async Task LineByLineFileWatcher_Create_ReturnsInitialLines()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);

        var (watcher, initialContent) = LineByLineFileWatcher.Create(testFile);

        initialContent.Should().BeEquivalentTo(["Line 1", "Line 2", "Line 3"]);
        watcher.Should().NotBeNull();
    }

    [Test]
    public async Task LineByLineFileWatcher_OnChange_EmitsOnlyNewLines()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        var (watcher, _) = LineByLineFileWatcher.Create(testFile);
        var newLines = new List<string>();
        var tcs = new TaskCompletionSource<bool>();
        var expectedNewLines = 2;

        watcher.OnChange(line =>
        {
            newLines.Add(line);
            if (newLines.Count >= expectedNewLines)
                tcs.TrySetResult(true);
        });

        await Task.Delay(100); // Give watcher time to start
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);

        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        newLines.Should().BeEquivalentTo(["Line 3", "Line 4"]);
    }

    [Test]
    public async Task LineByLineFileWatcher_OnChange_HandlesMultipleChanges()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);

        var (watcher, _) = LineByLineFileWatcher.Create(testFile);
        var allNewLines = new List<string>();
        var tcs = new TaskCompletionSource<bool>();
        var expectedTotalLines = 3; // Line 2, Line 3, Line 4

        watcher.OnChange(line =>
        {
            allNewLines.Add(line);
            if (allNewLines.Count >= expectedTotalLines)
                tcs.TrySetResult(true);
        });

        await Task.Delay(100);
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        await Task.Delay(200);
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);

        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        allNewLines.Should().BeEquivalentTo(["Line 2", "Line 3", "Line 4"]);
    }

    [Test]
    public async Task LineByLineFileWatcher_OnChange_DoesNotEmitWhenNoNewLines()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        var (watcher, _) = LineByLineFileWatcher.Create(testFile);
        var newLines = new List<string>();

        watcher.OnChange(line =>
        {
            newLines.Add(line);
        });

        await Task.Delay(100);
        // Trigger file change but don't add new lines
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        await Task.Delay(500);

        newLines.Should().BeEmpty();
    }
}
