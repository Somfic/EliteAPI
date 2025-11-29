// using EliteAPI.Watcher;
// using FluentAssertions;
//
// namespace EliteAPI.Tests;
//
// public class FileWatcherTests
// {
//     private DirectoryInfo _testDirectory = null!;
//
//     [Before(HookType.Test)]
//     public async Task Setup()
//     {
//         _testDirectory = Directory.CreateTempSubdirectory("EliteAPI_FileWatcher_Tests");
//     }
//
//     [After(HookType.Test)]
//     public async Task Cleanup()
//     {
//         if (_testDirectory.Exists)
//             _testDirectory.Delete(recursive: true);
//     }
//
//     [Test]
//     public async Task EntireFile_Create_ReturnsInitialContent()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllTextAsync(testFile.FullName, "Initial content");
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.EntireFile);
//         watcher.OnContentChanged(content => { /* No-op for this test */ });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().Be("Initial content");
//         watcher.Should().NotBeNull();
//     }
//
//     [Test]
//     public async Task EntireFile_OnChange_EmitsEntireFileContent()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllTextAsync(testFile.FullName, "Initial content");
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.EntireFile);
//         var changedContent = "";
//         var tcs = new TaskCompletionSource<bool>();
//
//         watcher.OnContentChanged(content =>
//         {
//             changedContent = content;
//             tcs.TrySetResult(true);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100); // Give watcher time to start
//         await File.WriteAllTextAsync(testFile.FullName, "Updated content");
//
//         await Task.WhenAny(tcs.Task, Task.Delay(5000));
//
//         changedContent.Should().Be("Updated content");
//     }
//
//     [Test]
//     public async Task LineByLine_Create_ReturnsInitialContent()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         watcher.OnContentChanged(line => { /* No-op for this test */ });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().Contain("Line");
//         watcher.Should().NotBeNull();
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_EmitsOnlyNewLines()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//         var expectedNewLines = 2;
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//             if (newLines.Count >= expectedNewLines)
//                 tcs.TrySetResult(true);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100); // Give watcher time to start
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);
//
//         // Wait for change event (with timeout)
//         await Task.WhenAny(tcs.Task, Task.Delay(5000));
//
//         newLines.Should().BeEquivalentTo(["Line 3", "Line 4"]);
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesMultipleChanges()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var allNewLines = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//         var expectedTotalLines = 3; // Line 2, Line 3, Line 4
//
//         watcher.OnContentChanged(line =>
//         {
//             allNewLines.Add(line);
//             if (allNewLines.Count >= expectedTotalLines)
//                 tcs.TrySetResult(true);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//
//         await Task.Delay(300);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);
//
//         // Wait for change event (with timeout)
//         await Task.WhenAny(tcs.Task, Task.Delay(5000));
//
//         allNewLines.Should().BeEquivalentTo(["Line 2", "Line 3", "Line 4"]);
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_DoesNotEmitWhenNoNewLines()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         watcher.StartWatching();
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//
//         await Task.Delay(100);
//         // Trigger file change but don't add new lines
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//
//         await Task.Delay(500);
//
//         newLines.Should().BeEmpty();
//     }
//
//     [Test]
//     public async Task LineByLine_CreateWithDirectory_ReturnsInitialContentFromLatestFile()
//     {
//         var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
//
//         await File.WriteAllLinesAsync(file1.FullName, ["Old line 1", "Old line 2"]);
//         await Task.Delay(10); // Ensure file2 has a later timestamp
//         await File.WriteAllLinesAsync(file2.FullName, ["New line 1", "New line 2"]);
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//         watcher.OnContentChanged(line => { /* No-op for this test */ });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().Contain("New line");
//         watcher.Should().NotBeNull();
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T110000.01.log");
//     }
//
//     [Test]
//     public async Task LineByLine_CreateWithDirectory_SwitchesToNewFile()
//     {
//         var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(file1.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//
//         var allLines = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//
//         watcher.OnContentChanged(line =>
//         {
//             allLines.Add(line);
//             if (allLines.Count >= 3) // Expecting 3 total lines
//                 tcs.TrySetResult(true);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100); // Give watcher time to start
//
//         // Add line to first file
//         await File.WriteAllLinesAsync(file1.FullName, ["Line 1", "Line 2"]);
//         await Task.Delay(300);
//
//         // Create a new journal file
//         var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
//         await File.WriteAllLinesAsync(file2.FullName, ["New file line 1"]);
//         await Task.Delay(300); // Give watcher time to detect and switch
//
//         // Add another line to the new file
//         await File.WriteAllLinesAsync(file2.FullName, ["New file line 1", "New file line 2"]);
//
//         // Wait for all expected lines
//         await Task.WhenAny(tcs.Task, Task.Delay(5000));
//
//         allLines.Should().Contain("Line 2");
//         allLines.Should().Contain("New file line 2");
//     }
//
//     [Test]
//     public async Task LineByLine_CreateWithDirectory_IgnoresIrrelevantFiles()
//     {
//         var journalFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(journalFile.FullName, ["Journal line 1"]);
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//
//         var allLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             allLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300); // Give watcher time to start
//
//         // Create and write to an irrelevant file (doesn't match pattern)
//         var irrelevantFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Status.json"));
//         await File.WriteAllTextAsync(irrelevantFile.FullName, "{ \"status\": \"test\" }");
//         await Task.Delay(300);
//
//         // Write to another irrelevant file
//         var anotherIrrelevant = new FileInfo(Path.Combine(_testDirectory.FullName, "SomeOtherFile.txt"));
//         await File.WriteAllTextAsync(anotherIrrelevant.FullName, "Irrelevant content");
//         await Task.Delay(300);
//
//         // Write to the journal file
//         await File.WriteAllLinesAsync(journalFile.FullName, ["Journal line 1", "Journal line 2"]);
//         await Task.Delay(600); // Wait for debounce + processing
//
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T100000.01.log");
//         allLines.Should().ContainSingle();
//         allLines.Should().Contain("Journal line 2");
//     }
//
//     [Test]
//     public async Task LineByLine_OnFileChanged_InvokesCallbackWhenSwitchingFiles()
//     {
//         var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(file1.FullName, ["Line 1"]);
//         File.SetLastWriteTimeUtc(file1.FullName, DateTime.UtcNow.AddHours(-1));
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//
//         var fileChanges = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//
//         watcher.OnFileChanged(newFile =>
//         {
//             fileChanges.Add(newFile.Name);
//             tcs.TrySetResult(true);
//         });
//
//         watcher.OnContentChanged(line => { /* Do nothing, just need to start watching */ });
//         watcher.StartWatching();
//
//         await Task.Delay(300); // Give watcher time to start
//
//         // Create and write to a new journal file with newer timestamp
//         var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
//         await File.WriteAllLinesAsync(file2.FullName, ["New file line 1"]);
//         File.SetLastWriteTimeUtc(file2.FullName, DateTime.UtcNow);
//         await Task.Delay(600); // Give watcher time to detect and switch
//
//         // Wait for file change callback
//         await Task.WhenAny(tcs.Task, Task.Delay(5000));
//
//         fileChanges.Should().ContainSingle();
//         fileChanges[0].Should().Be("Journal.2025-11-22T110000.01.log");
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T110000.01.log");
//     }
//
//     [Test]
//     public async Task LineByLine_OnFileChanged_NotInvokedWhenNoFileSwitching()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//         watcher.StartWatching();
//
//         var fileChanges = new List<string>();
//
//         watcher.OnFileChanged(newFile =>
//         {
//             fileChanges.Add(newFile.Name);
//         });
//
//         watcher.OnContentChanged(line => { /* Do nothing */ });
//
//         await Task.Delay(100); // Give watcher time to start
//
//         // Write to the same file (no file switching)
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);
//         await Task.Delay(300);
//
//         fileChanges.Should().BeEmpty();
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T100000.01.log");
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesEmptyFile()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         // Create an actual empty file
//         await using (File.Create(testFile.FullName)) { }
//         await Task.Delay(100); // Ensure file is created
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//         await File.WriteAllLinesAsync(testFile.FullName, ["First line", "Second line"]);
//         await Task.Delay(600); // 200ms debounce + 250ms buffer
//
//         newLines.Should().BeEquivalentTo(["First line", "Second line"]);
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesFileTruncation()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100);
//         // Truncate file to fewer lines than it started with
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//         await Task.Delay(300);
//
//         // Should not emit any lines since file was truncated
//         newLines.Should().BeEmpty();
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesSingleLineAddition()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//         await Task.Delay(600);
//
//         newLines.Should().ContainSingle();
//         newLines.Should().Contain("Line 2");
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesEmptyLines()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "", "Line 3"]);
//         await Task.Delay(600);
//
//         newLines.Should().HaveCount(2);
//         newLines.Should().ContainInOrder("", "Line 3");
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesRapidConsecutiveChanges()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var allNewLines = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//
//         watcher.OnContentChanged(line =>
//         {
//             allNewLines.Add(line);
//             if (allNewLines.Count >= 5) // Expecting 5 new lines total
//                 tcs.TrySetResult(true);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100);
//
//         // Make multiple rapid changes
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//         await Task.Delay(150);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);
//         await Task.Delay(150);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4"]);
//         await Task.Delay(150);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3", "Line 4", "Line 5", "Line 6"]);
//
//         await Task.WhenAny(tcs.Task, Task.Delay(5000));
//
//         allNewLines.Should().Contain("Line 2");
//         allNewLines.Should().Contain("Line 3");
//         allNewLines.Should().Contain("Line 4");
//         allNewLines.Should().Contain("Line 5");
//         allNewLines.Should().Contain("Line 6");
//     }
//
//     [Test]
//     public async Task LineByLine_OnChange_HandlesSpecialCharacters()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line with \"quotes\" and 'apostrophes'", "Line with émojis 🚀", "Line with tabs\t\there"]);
//         await Task.Delay(600); // 200ms debounce + 250ms buffer
//
//         newLines.Should().HaveCount(3);
//         newLines.Should().Contain("Line with \"quotes\" and 'apostrophes'");
//         newLines.Should().Contain("Line with émojis 🚀");
//         newLines.Should().Contain("Line with tabs\t\there");
//     }
//
//     [Test]
//     public async Task EntireFile_OnChange_HandlesMultipleConsecutiveChanges()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllTextAsync(testFile.FullName, "Initial");
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.EntireFile);
//         var allChanges = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//
//         watcher.OnContentChanged(content =>
//         {
//             allChanges.Add(content);
//             if (allChanges.Count >= 3)
//                 tcs.TrySetResult(true);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//         await File.WriteAllTextAsync(testFile.FullName, "First");
//         await Task.Delay(600); // 200ms debounce + 250ms buffer
//         await File.WriteAllTextAsync(testFile.FullName, "Second");
//         await Task.Delay(600); // 200ms debounce + 250ms buffer
//         await File.WriteAllTextAsync(testFile.FullName, "Third");
//
//         await Task.WhenAny(tcs.Task, Task.Delay(3000));
//
//         allChanges.Should().Contain("First");
//         allChanges.Should().Contain("Second");
//         allChanges.Should().Contain("Third");
//     }
//
//     [Test]
//     public async Task LineByLine_CallbackException_DoesNotCrashWatcher()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var successfulLines = new List<string>();
//         var callCount = 0;
//
//         watcher.OnContentChanged(line =>
//         {
//             callCount++;
//             if (line.Contains("2"))
//                 throw new InvalidOperationException("Test exception");
//             successfulLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//         // Add lines - Line 2 will throw, but Line 3 should still be processed
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2", "Line 3"]);
//         await Task.Delay(600); // 200ms debounce + 250ms buffer
//
//         // Line 2 threw exception, but Line 3 should still have been processed
//         callCount.Should().Be(2);
//         successfulLines.Should().ContainSingle();
//         successfulLines.Should().Contain("Line 3");
//     }
//
//     [Test]
//     public async Task LineByLine_CreateWithDirectory_HandlesMultipleNewFiles()
//     {
//         var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(file1.FullName, ["File 1 Line 1"]);
//         File.SetLastWriteTimeUtc(file1.FullName, DateTime.UtcNow.AddHours(-2));
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//         var allLines = new List<string>();
//         var fileChanges = new List<string>();
//
//         watcher.OnContentChanged(line => allLines.Add(line));
//         watcher.OnFileChanged(file => fileChanges.Add(file.Name));
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//
//         // Create second file (newer timestamp)
//         var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
//         await File.WriteAllLinesAsync(file2.FullName, ["File 2 Line 1"]);
//         File.SetLastWriteTimeUtc(file2.FullName, DateTime.UtcNow.AddHours(-1));
//         await Task.Delay(600);
//
//         // Add line to second file
//         await File.WriteAllLinesAsync(file2.FullName, ["File 2 Line 1", "File 2 Line 2"]);
//         File.SetLastWriteTimeUtc(file2.FullName, DateTime.UtcNow.AddHours(-1));
//         await Task.Delay(600);
//
//         // Create third file (newest timestamp)
//         var file3 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T120000.01.log"));
//         await File.WriteAllLinesAsync(file3.FullName, ["File 3 Line 1"]);
//         File.SetLastWriteTimeUtc(file3.FullName, DateTime.UtcNow);
//         await Task.Delay(600);
//
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T120000.01.log");
//         fileChanges.Should().Contain("Journal.2025-11-22T110000.01.log");
//         fileChanges.Should().Contain("Journal.2025-11-22T120000.01.log");
//         allLines.Should().Contain("File 2 Line 2");
//     }
//
//     [Test]
//     public async Task LineByLine_CreateWithDirectory_IgnoresOlderFiles()
//     {
//         var file1 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.log"));
//         await File.WriteAllLinesAsync(file1.FullName, ["Current file line 1"]);
//         // Set file1 to a newer timestamp
//         File.SetLastWriteTimeUtc(file1.FullName, DateTime.UtcNow);
//         await Task.Delay(100);
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//         var fileChanges = new List<string>();
//
//         watcher.OnContentChanged(line => { /* Do nothing */ });
//         watcher.OnFileChanged(file => fileChanges.Add(file.Name));
//         watcher.StartWatching();
//
//         await Task.Delay(100);
//
//         // Create file with older timestamp - should be ignored
//         var file2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(file2.FullName, ["Old file line 1"]);
//         // Set file2 to an older timestamp
//         File.SetLastWriteTimeUtc(file2.FullName, DateTime.UtcNow.AddHours(-1));
//         await Task.Delay(300);
//
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T110000.01.log");
//         fileChanges.Should().BeEmpty();
//     }
//
//     [Test]
//     public async Task LineByLine_CreateWithDirectory_PatternMatching()
//     {
//         var journalFile = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T100000.01.log"));
//         await File.WriteAllLinesAsync(journalFile.FullName, ["Journal line"]);
//
//         var watcher = FileWatcher.Create(_testDirectory, "Journal.*.log", FileWatchMode.LineByLine);
//         var allLines = new List<string>();
//
//         watcher.OnContentChanged(line => allLines.Add(line));
//         watcher.StartWatching();
//
//         await Task.Delay(300);
//
//         // Should NOT match - different prefix
//         var notMatching1 = new FileInfo(Path.Combine(_testDirectory.FullName, "NotJournal.2025-11-22T110000.01.log"));
//         await File.WriteAllLinesAsync(notMatching1.FullName, ["Should not appear"]);
//         await Task.Delay(600);
//
//         // Should NOT match - different extension
//         var notMatching2 = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T110000.01.txt"));
//         await File.WriteAllLinesAsync(notMatching2.FullName, ["Should not appear either"]);
//         await Task.Delay(600);
//
//         // SHOULD match
//         var matching = new FileInfo(Path.Combine(_testDirectory.FullName, "Journal.2025-11-22T120000.01.log"));
//         await File.WriteAllLinesAsync(matching.FullName, ["Should appear"]);
//         await Task.Delay(600);
//
//         watcher.CurrentFile.Name.Should().Be("Journal.2025-11-22T120000.01.log");
//         allLines.Should().NotContain("Should not appear");
//         allLines.Should().NotContain("Should not appear either");
//     }
//
//     [Test]
//     public async Task EntireFile_Create_HandlesEmptyFile()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllTextAsync(testFile.FullName, "");
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.EntireFile);
//         watcher.OnContentChanged(content => { /* No-op for this test */ });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().BeEmpty();
//         watcher.Should().NotBeNull();
//     }
//
//     [Test]
//     public async Task LineByLine_VeryLongLine_HandlesCorrectly()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1"]);
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//         });
//         watcher.StartWatching();
//
//         await Task.Delay(100);
//         var longLine = new string('x', 10000); // 10,000 character line
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", longLine]);
//         await Task.Delay(300);
//
//         newLines.Should().ContainSingle();
//         newLines[0].Should().HaveLength(10000);
//     }
//
//     [Test]
//     public async Task Create_NonExistentFile_ReturnsEmptyInitialContent()
//     {
//         var nonExistentFile = new FileInfo(Path.Combine(_testDirectory.FullName, "does-not-exist.txt"));
//
//         var watcher = FileWatcher.Create(nonExistentFile, FileWatchMode.LineByLine);
//         watcher.OnContentChanged(line => { /* No-op */ });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().BeEmpty();
//         watcher.Should().NotBeNull();
//     }
//
//     [Test]
//     public async Task CreateWithDirectory_NoMatchingFiles_ReturnsEmptyInitialContent()
//     {
//         var watcher = FileWatcher.Create(_testDirectory, "NonExistent.*.log", FileWatchMode.LineByLine);
//         watcher.OnContentChanged(line => { /* No-op */ });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().BeEmpty();
//         watcher.Should().NotBeNull();
//     }
//
//     [Test]
//     public async Task Create_FileDeletedBeforeStartWatching_ReturnsEmptyInitialContent()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "test.txt"));
//         await File.WriteAllTextAsync(testFile.FullName, "Content");
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         watcher.OnContentChanged(line => { /* No-op */ });
//
//         // Delete the file before starting to watch
//         File.Delete(testFile.FullName);
//
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().BeEmpty();
//     }
//
//     [Test]
//     public async Task NonExistentFile_CreatedLater_StartsEmittingEvents()
//     {
//         var testFile = new FileInfo(Path.Combine(_testDirectory.FullName, "created-later.txt"));
//
//         var watcher = FileWatcher.Create(testFile, FileWatchMode.LineByLine);
//         var newLines = new List<string>();
//         var tcs = new TaskCompletionSource<bool>();
//
//         watcher.OnContentChanged(line =>
//         {
//             newLines.Add(line);
//             if (newLines.Count >= 2)
//                 tcs.TrySetResult(true);
//         });
//         var initialContent = watcher.StartWatching();
//
//         initialContent.Should().BeEmpty();
//
//         await Task.Delay(300);
//
//         // Now create the file and add content
//         await File.WriteAllLinesAsync(testFile.FullName, ["Line 1", "Line 2"]);
//
//         await Task.WhenAny(tcs.Task, Task.Delay(3000));
//
//         newLines.Should().Contain("Line 1");
//         newLines.Should().Contain("Line 2");
//     }
// }
