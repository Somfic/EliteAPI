namespace EliteAPI.Watcher;

public class LineByLineFileWatcher : FileWatcher<string[]>
{
    private int LastLineCount { get; set; }

    private LineByLineFileWatcher(FileInfo file, int initialLineCount) : base(file)
    {
        LastLineCount = initialLineCount;
    }

    public static (LineByLineFileWatcher watcher, string[] initialContent) Create(DirectoryInfo directory, string filePattern)
    {
        var file = directory.GetFiles(filePattern)
            .OrderByDescending(f => f.LastWriteTimeUtc)
            .FirstOrDefault() ?? throw new FileNotFoundException($"No files matching pattern '{filePattern}' were found in directory '{directory.FullName}'.");

        return Create(file);
    }

    public static (LineByLineFileWatcher watcher, string[] initialContent) Create(FileInfo file)
    {
        var initialContent = ReadFileLines(file.FullName);
        var watcher = new LineByLineFileWatcher(file, initialContent.Length);
        return (watcher, initialContent);
    }

    public void OnChange(Action<string> onChange)
    {
        StartWatching(onChange, () =>
        {
            var lines = ReadFileLines(File.FullName);

            for (int i = LastLineCount; i < lines.Length; i++)
                onChange(lines[i]);

            LastLineCount = lines.Length;
        });
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
