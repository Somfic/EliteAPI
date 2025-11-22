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
    public async Task EntireFile_Create_ReturnsInitialContent()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllTextAsync(testFile.FullName, "Initial content");

        var (watcher, initialContent) = FileWatcher.Create(testFile, FileWatchMode.EntireFile);

        initialContent.Should().Be("Initial content");
        watcher.Should().NotBeNull();
    }

    [Test]
    public async Task EntireFile_OnChange_EmitsEntireFileContent()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllTextAsync(testFile.FullName, "Initial content");

        var (watcher, _) = FileWatcher.Create(testFile, FileWatchMode.EntireFile);
        var changedContent = "";
        var tcs = new TaskCompletionSource<bool>();

        watcher.OnContentChanged(content =>
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
    public async Task LineByLine_Create_ReturnsInitialContent()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);

        var (watcher, initialContent) = FileWatcher.Create(testFile, FileWatchMode.LineByLine);

        initialContent.Should().Contain("Line");
        watcher.Should().NotBeNull();
    }

    [Test]
    public async Task LineByLine_OnChange_EmitsOnlyNewLines()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        var (watcher, _) = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
        var newLines = new List<string>();
        var tcs = new TaskCompletionSource<bool>();
        var expectedNewLines = 2;

        watcher.OnContentChanged(line =>
        {
            newLines.Add(line);
            if (newLines.Count >= expectedNewLines)
                tcs.TrySetResult(true);
        });

        await Task.Delay(100); // Give watcher time to start
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);

        // Wait for change event (with timeout)
        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        newLines.Should().BeEquivalentTo(["Line 3", "Line 4"]);
    }

    [Test]
    public async Task LineByLine_OnChange_HandlesMultipleChanges()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);

        var (watcher, _) = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
        var allNewLines = new List<string>();
        var tcs = new TaskCompletionSource<bool>();
        var expectedTotalLines = 3; // Line 2, Line 3, Line 4

        watcher.OnContentChanged(line =>
        {
            allNewLines.Add(line);
            if (allNewLines.Count >= expectedTotalLines)
                tcs.TrySetResult(true);
        });

        await Task.Delay(100);
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        await Task.Delay(200);
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);

        // Wait for change event (with timeout)
        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        allNewLines.Should().BeEquivalentTo(["Line 2", "Line 3", "Line 4"]);
    }

    [Test]
    public async Task LineByLine_OnChange_DoesNotEmitWhenNoNewLines()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        var (watcher, _) = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
        var newLines = new List<string>();

        watcher.OnContentChanged(line =>
        {
            newLines.Add(line);
        });

        await Task.Delay(100);
        // Trigger file change but don't add new lines
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);

        await Task.Delay(500);

        newLines.Should().BeEmpty();
    }

    [Test]
    public async Task LineByLine_CreateWithDirectory_ReturnsInitialContentFromLatestFile()
    {
        var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
        var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));

        await File.WriteAllLinesAsync(file1.FullName, ["Old line 1", "Old line 2"]);
        await Task.Delay(10); // Ensure file2 has a later timestamp
        await File.WriteAllLinesAsync(file2.FullName, ["New line 1", "New line 2"]);

        var (watcher, initialContent) = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);

        initialContent.Should().Contain("New line");
        watcher.Should().NotBeNull();
        watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T110000.01.log");
    }

    [Test]
    public async Task LineByLine_CreateWithDirectory_SwitchesToNewFile()
    {
        var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
        await File.WriteAllLinesAsync(file1.FullName, ["Line 1"]);

        var (watcher, _) = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
        var allLines = new List<string>();
        var tcs = new TaskCompletionSource<bool>();

        watcher.OnContentChanged(line =>
        {
            allLines.Add(line);
            if (allLines.Count >= 3) // Expecting 3 total lines
                tcs.TrySetResult(true);
        });

        await Task.Delay(100); // Give watcher time to start

        // Add line to first file
        await File.WriteAllLinesAsync(file1.FullName, ["Line 1", "Line 2"]);
        await Task.Delay(200);

        // Create a new journal file
        var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
        await File.WriteAllLinesAsync(file2.FullName, ["New file line 1"]);
        await Task.Delay(300); // Give watcher time to detect and switch

        // Add another line to the new file
        await File.WriteAllLinesAsync(file2.FullName, ["New file line 1", "New file line 2"]);

        // Wait for all expected lines
        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        allLines.Should().Contain("Line 2");
        allLines.Should().Contain("New file line 2");
    }

    [Test]
    public async Task LineByLine_CreateWithDirectory_IgnoresIrrelevantFiles()
    {
        var journalFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
        await File.WriteAllLinesAsync(journalFile.FullName, ["Journal line 1"]);

        var (watcher, _) = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
        var allLines = new List<string>();

        watcher.OnContentChanged(line =>
        {
            allLines.Add(line);
        });

        await Task.Delay(100); // Give watcher time to start

        // Create and write to an irrelevant file (doesn't match pattern)
        var irrelevantFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Status.json"));
        await File.WriteAllTextAsync(irrelevantFile.FullName, "{ \"status\": \"test\" }");
        await Task.Delay(300);

        // Write to another irrelevant file
        var anotherIrrelevant = new FileInfo(Path.Combine(_testDirectory.FullName, "SomeOtherFile.txt"));
        await File.WriteAllTextAsync(anotherIrrelevant.FullName, "Irrelevant content");
        await Task.Delay(300);

        // Write to the journal file
        await File.WriteAllLinesAsync(journalFile.FullName, ["Journal line 1", "Journal line 2"]);
        await Task.Delay(300);

        watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T100000.01.log");
        allLines.Should().ContainSingle();
        allLines.Should().Contain("Journal line 2");
    }

    [Test]
    public async Task LineByLine_OnFileChanged_InvokesCallbackWhenSwitchingFiles()
    {
        var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
        await File.WriteAllLinesAsync(file1.FullName, ["Line 1"]);

        var (watcher, _) = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
        var fileChanges = new List<string>();
        var tcs = new TaskCompletionSource<bool>();

        watcher.OnFileChanged(newFile =>
        {
            fileChanges.Add(newFile.Name);
            tcs.TrySetResult(true);
        });

        watcher.OnContentChanged(line => { /* Do nothing, just need to start watching */ });

        await Task.Delay(100); // Give watcher time to start

        // Create and write to a new journal file
        var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
        await File.WriteAllLinesAsync(file2.FullName, ["New file line 1"]);
        await Task.Delay(300); // Give watcher time to detect and switch

        // Wait for file change callback
        await Task.WhenAny(tcs.Task, Task.Delay(5000));

        fileChanges.Should().ContainSingle();
        fileChanges[0].Should().Be("Journal.2025-11-22T110000.01.log");
        watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T110000.01.log");
    }

    [Test]
    public async Task LineByLine_OnFileChanged_NotInvokedWhenNoFileSwitching()
    {
        var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);

        var (watcher, _) = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
        var fileChanges = new List<string>();

        watcher.OnFileChanged(newFile =>
        {
            fileChanges.Add(newFile.Name);
        });

        watcher.OnContentChanged(line => { /* Do nothing */ });

        await Task.Delay(100); // Give watcher time to start

        // Write to the same file (no file switching)
        await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);
        await Task.Delay(300);

        fileChanges.Should().BeEmpty();
        watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T100000.01.log");
    }
}
