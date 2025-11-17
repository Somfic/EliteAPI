using EliteVA.Abstractions;
using EliteVA.Audio;
using EliteVA.Commands;
using EliteVA.Logging;
using EliteVA.Options;
using EliteVA.Paths;
using EliteVA.Variables;
using EliteVA.Versions;

namespace EliteVA;

public class VoiceAttackProxy : IVoiceAttackProxy
{
    private readonly dynamic _vaProxy;

    public VoiceAttackProxy(dynamic vaProxy)
    {
        _vaProxy = vaProxy;
            
        Variables = new VoiceAttackVariables(vaProxy);
        Versions = new VoiceAttackVersions(vaProxy);
        Log = new VoiceAttackLog(vaProxy);
        Paths = new VoiceAttackPaths(vaProxy);
        Options = new VoiceAttackOptions(vaProxy);
        Speech = new VoiceAttackSpeech(vaProxy);
        Command = new VoiceAttackCommand(vaProxy);
        Commands = new VoiceAttackCommands(vaProxy);
    }

    /// <inheritdoc />
    public string Context => _vaProxy.Context;

    /// <inheritdoc />
    public bool HasStopped => _vaProxy.Stopped;

    /// <inheritdoc />
    public IReadOnlyCollection<string> Profiles => _vaProxy.ProfileNames();

    /// <inheritdoc />
    public IntPtr Handle => _vaProxy.MainWindowHandle;

    /// <inheritdoc />
    public VoiceAttackVariables Variables { get; init; }

    /// <inheritdoc />
    public VoiceAttackVersions Versions { get; init; }

    /// <inheritdoc />
    public VoiceAttackLog Log { get; init; }

    /// <inheritdoc />
    public VoiceAttackPaths Paths { get; init; }

    /// <inheritdoc />
    public VoiceAttackOptions Options { get; init; }

    /// <inheritdoc />
    public VoiceAttackSpeech Speech { get; init; }

    /// <inheritdoc />
    public VoiceAttackCommands Commands { get; init; }

    /// <inheritdoc />
    public VoiceAttackCommand Command { get; init; }

    /// <inheritdoc />
    public Task<IReadOnlyCollection<string>> GeneratePhrases(string query, bool trimSpaces = false, bool lowercase = false)
    {
        return Task.FromResult(_vaProxy.ExtractPhrases(query, trimSpaces, lowercase));
    }

    /// <inheritdoc />
    public Task Opacity(int percentage)
    {
        _vaProxy.SetOpacity(percentage);
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task ResetStopFlag()
    {
        _vaProxy.ResetStopFlag();
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task Close()
    {
        _vaProxy.Close();
        return Task.CompletedTask;
    }
}