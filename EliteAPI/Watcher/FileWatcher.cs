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

    public static (FileWatcher watcher, string initialContent) Create(FileInfo file, FileWatchMode mode = FileWatchMode.EntireFile)
    {
        var initialContent = ReadFileContent(file.FullName);
        var initialLineCount = mode == FileWatchMode.LineByLine ? ReadFileLines(file.FullName).Length : 0;
        var watcher = new FileWatcher(file, mode, initialLineCount);
        return (watcher, initialContent);
    }

    public static (FileWatcher watcher, string initialContent) Create(DirectoryInfo directory, string filePattern, FileWatchMode mode = FileWatchMode.EntireFile)
    {
        var file = directory.GetFiles(filePattern)
            .OrderByDescending(f => f.LastWriteTimeUtc)
            .FirstOrDefault() ?? throw new FileNotFoundException($"No files matching pattern '{filePattern}' were found in directory '{directory.FullName}'.");

        var initialContent = ReadFileContent(file.FullName);
        var initialLineCount = mode == FileWatchMode.LineByLine ? ReadFileLines(file.FullName).Length : 0;
        var watcher = new FileWatcher(file, mode, initialLineCount, directory, filePattern);
        return (watcher, initialContent);
    }

    public void OnContentChanged(Action<string> onContentChanged)
    {
        _onContentChanged = onContentChanged;
        StartWatching();
    }

    public void OnFileChanged(Action<FileInfo> onFileChanged)
    {
        _onFileChanged = onFileChanged;
    }

    private void StartWatching()
    {
        if (_onContentChanged == null) return;

        _fileWatcher = new FileSystemWatcher(_file.DirectoryName ?? string.Empty, _file.Name)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        _fileWatcher.Changed += (sender, args) =>
        {
            try
            {
                Thread.Sleep(50);
                HandleFileChange();
            }
            catch
            {
                // Silently ignore exceptions to prevent crashes
            }
        };

        _fileWatcher.EnableRaisingEvents = true;
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
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
        };

        _directoryWatcher.Changed += OnFileInDirectoryChanged;
        _directoryWatcher.EnableRaisingEvents = true;
    }

    private void OnFileInDirectoryChanged(object sender, FileSystemEventArgs e)
    {
        try
        {
            Thread.Sleep(100);

            var changedFile = new FileInfo(e.FullPath);

            // Only switch if the changed file matches the pattern, is newer than current, and is not the current file
            if (_filePattern != null &&
                MatchesPattern(changedFile.Name, _filePattern) &&
                changedFile.FullName != _file.FullName &&
                changedFile.LastWriteTimeUtc > _file.LastWriteTimeUtc)
            {
                SwitchToNewFile(changedFile);
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
        _file = newFile;
        _lastLineCount = 0;

        // Dispose old file watcher
        if (_fileWatcher != null)
        {
            _fileWatcher.EnableRaisingEvents = false;
            _fileWatcher.Dispose();
        }

        _onFileChanged?.Invoke(newFile);

        // Start watching the new file
        StartWatching();
    }

    private static string ReadFileContent(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private static string[] ReadFileLines(string path)
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
        return lines.ToArray();
    }
}
