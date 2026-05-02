using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleHost;

public class MockVoiceAttackProxy
{
    private readonly Dictionary<string, object?> _vars = new();

    public string Context => string.Empty;
    public bool Stopped => false;
    public IntPtr MainWindowHandle => IntPtr.Zero;

    public IReadOnlyCollection<string> ProfileNames() => Array.Empty<string>();

    public Version ProxyVersion => new(1, 0, 0, 0);
    public Version VAVersion => new(1, 0, 0, 0);
    public bool IsRelease => true;
    public bool IsTrial => false;

    public bool PluginsEnabled => true;
    public bool NestedTokensEnabled => true;
    public bool AutoProfileSwitchingEnabled => false;

    public string InstallDir => AppContext.BaseDirectory;
    public string SoundsDir => AppContext.BaseDirectory;
    public string AppsDir => AppContext.BaseDirectory;
    public string AssembliesDir => AppContext.BaseDirectory;

    public IReadOnlyCollection<string> ExtractPhrases(string query, bool trimSpaces, bool lowercase) => new[] { query };

    public void SetOpacity(int percentage) { }

    public void ResetStopFlag() { }

    public void Close() => Environment.Exit(0);

    public void WriteToLog(string content, string color)
    {
        var foreground = color switch
        {
            "Red" => ConsoleColor.Red,
            "Yellow" => ConsoleColor.Yellow,
            "Green" => ConsoleColor.Green,
            "Blue" => ConsoleColor.Cyan,
            "Pink" => ConsoleColor.Magenta,
            "Purple" => ConsoleColor.DarkMagenta,
            "Orange" => ConsoleColor.DarkYellow,
            "Gray" => ConsoleColor.Gray,
            _ => Console.ForegroundColor
        };

        var prev = Console.ForegroundColor;
        Console.ForegroundColor = foreground;
        Console.WriteLine($"[VA] {content}");
        Console.ForegroundColor = prev;
    }

    public void ClearLog() { }

    public void SetText(string name, string? value) => SetVar(name, value, "txt");
    public void SetInt(string name, int? value) => SetVar(name, value, "int");
    public void SetSmallInt(string name, short? value) => SetVar(name, value, "i16");
    public void SetDecimal(string name, decimal? value) => SetVar(name, value, "dec");
    public void SetBoolean(string name, bool? value) => SetVar(name, value, "bool");
    public void SetDate(string name, DateTime? value) => SetVar(name, value, "date");

    private void SetVar(string name, object? value, string type)
    {
        _vars[name] = value;
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = value is null ? ConsoleColor.DarkGray : ConsoleColor.DarkCyan;
        Console.WriteLine($"[VA] set {name} ({type}) = {value ?? "<null>"}");
        Console.ForegroundColor = prev;
    }

    public string? GetText(string name) => _vars.TryGetValue(name, out var v) ? v as string : null;
    public int? GetInt(string name) => _vars.TryGetValue(name, out var v) ? v as int? : null;
    public short? GetSmallInt(string name) => _vars.TryGetValue(name, out var v) ? v as short? : null;
    public decimal? GetDecimal(string name) => _vars.TryGetValue(name, out var v) ? v as decimal? : null;
    public bool? GetBoolean(string name) => _vars.TryGetValue(name, out var v) ? v as bool? : null;
    public DateTime? GetDate(string name) => _vars.TryGetValue(name, out var v) ? v as DateTime? : null;

    public MockCommand Command { get; } = new();
    public MockUtility Utility { get; } = new();
}

public class MockCommand
{
    public string Name() => string.Empty;
    public Guid InternalID() => Guid.Empty;
    public string Segment(int index) => string.Empty;
    public int Action() => 0;
    public int Confidence() => 100;
    public int MinConfidence() => 0;
    public bool IsSubCommand() => false;
    public string WhenISay() => string.Empty;
    public string Category() => string.Empty;
    public bool AlreadyExecuting() => false;

    public int ExecutionCount() => 0;
    public string LastSpoken() => string.Empty;
    public string PreviousSpoken() => string.Empty;

    public void SetSessionEnabled(string name, bool isEnabled) { }
    public void SetSessionEnabled(Guid id, bool isEnabled) { }
    public void SetSessionEnabledByCategory(string name, bool isEnabled) { }
    public bool GetSessionEnabled(string name) => true;
    public bool GetSessionEnabled(Guid id) => true;
    public bool GetSessionEnabledByCategory(string name) => true;

    public void Execute(string name, bool runSync, bool runAsSubCommand)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"[VA] Execute {name} (sync={runSync}, sub={runAsSubCommand})");
        Console.ForegroundColor = prev;
    }

    public void Execute(Guid id, bool runSync, bool runAsSubCommand)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"[VA] Execute {id} (sync={runSync}, sub={runAsSubCommand})");
        Console.ForegroundColor = prev;
    }

    public bool Exists(string name) => true;
    public bool Exists(Guid id) => true;
    public bool Active(string name) => false;
    public bool Active(Guid id) => false;
    public bool CategoryExists(string name) => false;
}

public class MockUtility
{
    public MemoryStream CapturedAudio(int type) => new();
    public void ResetSpeechEngine() { }
    public bool GetSpeechRecordingDeviceMute() => false;
    public void SetSpeechRecordingDeviceMute(bool isMuted) { }
}
