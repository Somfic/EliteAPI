using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.Utils;
using FluentAssertions;

namespace EliteAPI.Tests;

public class FileUtilsTests
{
    private string _testDir = null!;

    [Before(Test)]
    public void Setup()
    {
        _testDir = Path.Combine(Path.GetTempPath(), $"EliteAPI.Tests.{Guid.NewGuid()}");
        Directory.CreateDirectory(_testDir);
    }

    [After(Test)]
    public void Cleanup()
    {
        if (Directory.Exists(_testDir))
            Directory.Delete(_testDir, true);
    }

    [Test]
    public void WriteWithRetry_WritesContentToFile()
    {
        var path = Path.Combine(_testDir, "test.txt");
        var content = "Hello, World!";

        FileUtils.WriteWithRetry(path, content);

        File.Exists(path).Should().BeTrue();
        File.ReadAllText(path).Should().Be(content);
    }

    [Test]
    public void WriteWithRetry_OverwritesExistingFile()
    {
        var path = Path.Combine(_testDir, "test.txt");
        File.WriteAllText(path, "Old content");

        FileUtils.WriteWithRetry(path, "New content");

        File.ReadAllText(path).Should().Be("New content");
    }

    [Test]
    public void WriteWithRetry_AllowsConcurrentReads()
    {
        var path = Path.Combine(_testDir, "test.txt");
        FileUtils.WriteWithRetry(path, "Initial content");

        // Open file for reading with share
        using var readStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(readStream);

        // Should be able to write while file is open for reading
        var writeAction = () => FileUtils.WriteWithRetry(path, "Updated content");
        writeAction.Should().NotThrow();
    }

    [Test]
    public async Task WriteWithRetry_RetriesOnTemporaryLock()
    {
        var path = Path.Combine(_testDir, "test.txt");
        FileUtils.WriteWithRetry(path, "Initial");

        // Lock the file temporarily
        var lockReleased = false;
        var writeCompleted = false;

        var lockTask = Task.Run(() =>
        {
            using var lockStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            Thread.Sleep(80); // Hold lock for 80ms (retry happens at 50ms intervals)
            lockReleased = true;
        });

        // Start write after a small delay to ensure lock is acquired
        await Task.Delay(10);

        var writeTask = Task.Run(() =>
        {
            FileUtils.WriteWithRetry(path, "After retry", maxRetries: 3, retryDelayMs: 50);
            writeCompleted = true;
        });

        await Task.WhenAll(lockTask, writeTask);

        lockReleased.Should().BeTrue();
        writeCompleted.Should().BeTrue();
        File.ReadAllText(path).Should().Be("After retry");
    }

    [Test]
    public void WriteWithRetry_ThrowsAfterMaxRetries()
    {
        var path = Path.Combine(_testDir, "test.txt");
        FileUtils.WriteWithRetry(path, "Initial");

        // Hold exclusive lock on the file
        using var lockStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

        // Should throw after retries are exhausted
        var writeAction = () => FileUtils.WriteWithRetry(path, "Should fail", maxRetries: 2, retryDelayMs: 10);
        writeAction.Should().Throw<IOException>();
    }

    [Test]
    public async Task WriteWithRetry_HandlesMultipleConcurrentWriters()
    {
        var path = Path.Combine(_testDir, "test.txt");
        var writeCount = 10;
        var tasks = new Task[writeCount];

        for (var i = 0; i < writeCount; i++)
        {
            var content = $"Content {i}";
            tasks[i] = Task.Run(() => FileUtils.WriteWithRetry(path, content));
        }

        var allTasks = () => Task.WhenAll(tasks);
        await allTasks.Should().NotThrowAsync();

        // File should exist and have content from one of the writes
        File.Exists(path).Should().BeTrue();
        File.ReadAllText(path).Should().StartWith("Content ");
    }

    [Test]
    public void AppendWithRetry_AppendsContentToFile()
    {
        var path = Path.Combine(_testDir, "test.txt");
        File.WriteAllText(path, "Line 1\n");

        FileUtils.AppendWithRetry(path, "Line 2\n");

        File.ReadAllText(path).Should().Be("Line 1\nLine 2\n");
    }

    [Test]
    public void AppendWithRetry_CreatesFileIfNotExists()
    {
        var path = Path.Combine(_testDir, "new.txt");

        FileUtils.AppendWithRetry(path, "First line");

        File.Exists(path).Should().BeTrue();
        File.ReadAllText(path).Should().Be("First line");
    }

    [Test]
    public async Task AppendWithRetry_HandlesMultipleConcurrentAppends()
    {
        var path = Path.Combine(_testDir, "test.txt");
        File.WriteAllText(path, "");
        var appendCount = 10;
        var tasks = new Task[appendCount];

        for (var i = 0; i < appendCount; i++)
        {
            var content = $"Line {i}\n";
            tasks[i] = Task.Run(() => FileUtils.AppendWithRetry(path, content));
        }

        var allTasks = () => Task.WhenAll(tasks);
        await allTasks.Should().NotThrowAsync();

        // File should have all lines (order may vary due to concurrency)
        var lines = File.ReadAllLines(path);
        lines.Should().HaveCount(appendCount);
    }
}
