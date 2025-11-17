using EliteVA.Audio;
using EliteVA.Commands;
using EliteVA.Logging;
using EliteVA.Options;
using EliteVA.Paths;
using EliteVA.Variables;
using EliteVA.Versions;

namespace EliteVA.Abstractions;

public interface IVoiceAttackProxy
{
    /// <summary>
    /// The context set via the 'Plugin Context' input box
    /// </summary>
    string Context { get; }

    /// <summary>
    /// Container for getting and setting variables
    /// </summary>
    VoiceAttackVariables Variables { get; }

    /// <summary>
    /// A collection of all profile names
    /// </summary>
    IReadOnlyCollection<string> Profiles { get; }

    /// <summary>
    /// Container for version information
    /// </summary>
    VoiceAttackVersions Versions { get; }

    /// <summary>
    /// Whether the 'Stop all commands' action is active
    /// </summary>
    bool HasStopped { get; }

    /// <summary>
    /// Container for logging
    /// </summary>
    VoiceAttackLog Log { get; }

    /// <summary>
    /// Container for all path information
    /// </summary>
    VoiceAttackPaths Paths { get; }

    /// <summary>
    /// Container for all options information
    /// </summary>
    VoiceAttackOptions Options { get; }

    /// <summary>
    /// Container for all speech information
    /// </summary>
    VoiceAttackSpeech Speech { get; }

    /// <summary>
    /// Container for all command information
    /// </summary>
    VoiceAttackCommands Commands { get; }

    /// <summary>
    /// Container for executing command information
    /// </summary>
    VoiceAttackCommand Command { get; }

    /// <summary>
    /// Generates a collection of phrases based on a query
    /// </summary>
    /// <param name="query">The phrases query</param>
    /// <param name="trimSpaces">Whether the phrases should be trimmed</param>
    /// <param name="lowercase">Whether the elements should be set to lowercase</param>
    /// <remarks>'good[morning;day;night]' would generate 'good morning', 'good day', 'good night'</remarks>
    Task<IReadOnlyCollection<string>>
        GeneratePhrases(string query, bool trimSpaces = false, bool lowercase = false);

    /// <summary>
    /// The VoiceAttack main window <seealso cref="IntPtr"/> handle
    /// </summary>
    IntPtr Handle { get; }

    /// <summary>
    /// Set the VoiceAttack main window opacity
    /// </summary>
    /// <param name="percentage">A value from 0-100</param>
    Task Opacity(int percentage);

    /// <summary>
    /// Clears the 'Stop all commands' action
    /// </summary>
    Task ResetStopFlag();

    /// <summary>
    /// Closes the VoiceAttack window
    /// </summary>
    Task Close();
}