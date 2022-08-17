namespace EliteAPI.Abstractions.Configuration;

/// <summary>The configuration for EliteAPI.</summary>
public interface IEliteDangerousApiConfiguration
{
    /// <summary>The directory in which the journal files are located.</summary>
    public string JournalsPath { get; }
    
    /// <summary>The status files that will be processed.</summary>
    public string[] StatusFiles { get; }

    /// <summary>The file pattern used to find journal files.</summary>
    public string JournalPattern { get; }

    /// <summary>The directory in which the option files are located.</summary>
    public string OptionsPath { get; }

    /// <summary>Applies the configuration to EliteAPI.</summary>
    void Apply();
}