namespace EliteAPI.Watcher;

public class LineByLineFileWatcher : FileWatcher<string[]>
{
    private int LastLineCount { get; set; }

    private LineByLineFileWatcher(FileInfo file, int initialLineCount) : base(file)
    {
        LastLineCount = initialLineCount;
    }

    public static (LineByLineFileWatcher watcher, string[] initialContent) Create(FileInfo file)
    {
        var initialContent = System.IO.File.ReadAllLines(file.FullName);
        var watcher = new LineByLineFileWatcher(file, initialContent.Length);
        return (watcher, initialContent);
    }

    public void OnChange(Action<string> onChange)
    {
        StartWatching(onChange, () =>
        {
            var lines = System.IO.File.ReadAllLines(File.FullName);

            for (int i = LastLineCount; i < lines.Length; i++)
                onChange(lines[i]);

            LastLineCount = lines.Length;
        });
    }
}
