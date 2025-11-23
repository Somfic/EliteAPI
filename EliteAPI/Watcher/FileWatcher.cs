using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace EliteAPI.Watcher;

public class FileWatcher
{
    private FileInfo _file;
    private readonly FileWatchMode _mode;
    public readonly DirectoryInfo? Directory;
    private readonly string? _filePattern;
    private FileSystemWatcher? _fileWatcher;
    private FileSystemWatcher? _directoryWatcher;
    private Action<string>? _onContentChanged;
    private Action<FileInfo>? _onFileChanged;
    private int _lastLineCount;
    private Timer? _debounceTimer;
    private readonly object _debounceLock = new object();
    private const int DebounceDelayMs = 200;

    public FileInfo CurrentFile => _file;

    private FileWatcher(FileInfo file, FileWatchMode mode, int initialLineCount = 0, DirectoryInfo? directory = null, string? filePattern = null)
    {
        _file = file;
        _mode = mode;
        _lastLineCount = initialLineCount;
        Directory = directory;
        _filePattern = filePattern;

        if (Directory != null && _filePattern != null)
            SetupDirectoryWatcher();
    }

    public static FileWatcher Create(FileInfo file, FileWatchMode mode = FileWatchMode.EntireFile)
    {
        var watcher = new FileWatcher(file, mode, 0, null, null);
        return watcher;
    }

    public static FileWatcher Create(DirectoryInfo directory, string filePattern, FileWatchMode mode = FileWatchMode.EntireFile)
    {
        var file = directory.GetFiles(filePattern)
            .OrderByDescending(f => f.LastWriteTimeUtc)
            .FirstOrDefault();

        // If no file exists yet, create a placeholder FileInfo - watcher will activate when file is created
        if (file == null)
        {
            file = new FileInfo(Path.Combine(directory.FullName, "__placeholder__"));
        }

        var watcher = new FileWatcher(file, mode, 0, directory, filePattern);
        return watcher;
    }

    public void OnContentChanged(Action<string> onContentChanged)
    {
        _onContentChanged = onContentChanged;
    }

    public void OnFileChanged(Action<FileInfo> onFileChanged)
    {
        _onFileChanged = onFileChanged;
    }

    public string StartWatching()
    {
        if (_onContentChanged == null) return string.Empty;

        // Read initial content and set line count (handle non-existent files gracefully)
        var initialContent = string.Empty;
        _file.Refresh(); // Refresh cached FileInfo properties
        if (_file.Exists)
        {
            initialContent = ReadFileContent(_file.FullName);
            _lastLineCount = _mode == FileWatchMode.LineByLine ? ReadFileLines(_file.FullName).Length : 0;
        }
        else
        {
            _lastLineCount = 0;
        }

        // If we're in directory watching mode, enable the directory watcher
        // Don't create a separate file watcher to avoid conflicts
        if (Directory != null && _filePattern != null)
        {
            if (_directoryWatcher != null)
            {
                _directoryWatcher.EnableRaisingEvents = true;
            }
            return initialContent;
        }

        // Create file watcher for single-file mode
        _fileWatcher = new FileSystemWatcher(_file.DirectoryName ?? string.Empty, _file.Name)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
            InternalBufferSize = 65536 // Increase buffer size to handle rapid changes
        };

        _fileWatcher.Changed += (sender, args) => DebounceFileChange();
        _fileWatcher.Created += (sender, args) => DebounceFileChange();

        _fileWatcher.EnableRaisingEvents = true;
        return initialContent;
    }

    private void DebounceFileChange()
    {
        lock (_debounceLock)
        {
            // Reset the debounce timer - this delays processing until changes stop coming
            _debounceTimer?.Dispose();
            _debounceTimer = new Timer(_ =>
            {
                try
                {
                    HandleFileChange();
                }
                catch
                {
                    // Silently ignore exceptions to prevent crashes
                }
            }, null, DebounceDelayMs, Timeout.Infinite);
        }
    }

    private void HandleFileChange()
    {
        if (_onContentChanged == null) return;

        try
        {
            if (_mode == FileWatchMode.LineByLine)
            {
                var lines = ReadFileLines(_file.FullName);
                for (int i = _lastLineCount; i < lines.Length; i++)
                {
                    try
                    {
                        _onContentChanged(lines[i]);
                    }
                    catch
                    {
                        // Continue processing other lines even if one fails
                    }
                }
                _lastLineCount = lines.Length;
            }
            else
            {
                var content = ReadFileContent(_file.FullName);
                _onContentChanged(content);
            }
        }
        catch
        {
            // Silently ignore exceptions to prevent crashes
        }
    }

    private void SetupDirectoryWatcher()
    {
        if (Directory == null || _filePattern == null) return;

        _directoryWatcher = new FileSystemWatcher(Directory.FullName, _filePattern)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
            InternalBufferSize = 65536 // Increase buffer size to handle multiple file events
        };

        _directoryWatcher.Changed += OnFileInDirectoryChanged;
        _directoryWatcher.Created += OnFileInDirectoryChanged;
        // Don't enable events yet - wait until StartWatching() is called
    }

    private void OnFileInDirectoryChanged(object sender, FileSystemEventArgs e)
    {
        try
        {
            var changedFile = new FileInfo(e.FullPath);

            // Check if this file matches our pattern
            if (_filePattern != null && MatchesPattern(changedFile.Name, _filePattern))
            {
                if (changedFile.FullName != _file.FullName)
                {
                    // Different file - consider switching to it if it's newer
                    Thread.Sleep(100); // Brief delay for file system to settle
                    _file.Refresh(); // Refresh cached properties

                    if (changedFile.LastWriteTimeUtc >= _file.LastWriteTimeUtc)
                    {
                        SwitchToNewFile(changedFile);
                    }
                }
                else
                {
                    // Current file changed - debounce the changes
                    DebounceFileChange();
                }
            }
        }
        catch
        {
            // Silently ignore exceptions to prevent crashes
        }
    }

    private static bool MatchesPattern(string fileName, string pattern)
    {
        // Convert wildcard pattern to regex
        var regexPattern = "^" + System.Text.RegularExpressions.Regex.Escape(pattern)
            .Replace("\\*", ".*")
            .Replace("\\?", ".") + "$";
        return System.Text.RegularExpressions.Regex.IsMatch(fileName, regexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }

    private void SwitchToNewFile(FileInfo newFile)
    {
        lock (_debounceLock)
        {
            _file = newFile;
            _lastLineCount = 0;

            // Dispose debounce timer to prevent callbacks from old file
            _debounceTimer?.Dispose();
            _debounceTimer = null;

            // Dispose old file watcher (if in single-file mode)
            if (_fileWatcher != null)
            {
                _fileWatcher.EnableRaisingEvents = false;
                _fileWatcher.Dispose();
                _fileWatcher = null;
            }

            _onFileChanged?.Invoke(newFile);
        }

        // Start watching the new file
        // In directory mode, this will be a no-op since directory watcher handles everything
        StartWatching();
    }

    private static string ReadFileContent(string path)
    {
        // Retry logic to handle file locks
        for (int i = 0; i < 3; i++)
        {
            try
            {
                using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            catch (IOException) when (i < 2)
            {
                Thread.Sleep(50);
            }
        }

        // Final attempt without retry
        using var finalStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var finalReader = new StreamReader(finalStream);
        return finalReader.ReadToEnd();
    }

    private static string[] ReadFileLines(string path)
    {
        // Retry logic to handle file locks
        for (int i = 0; i < 3; i++)
        {
            try
            {
                using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = new StreamReader(stream);
                var lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                        lines.Add(line);
                }
                return [.. lines];
            }
            catch (IOException) when (i < 2)
            {
                Thread.Sleep(50);
            }
        }

        // Final attempt without retry
        using var finalStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var finalReader = new StreamReader(finalStream);
        var finalLines = new List<string>();
        while (!finalReader.EndOfStream)
        {
            var line = finalReader.ReadLine();
            if (line != null)
                finalLines.Add(line);
        }
        return [.. finalLines];
    }
}
