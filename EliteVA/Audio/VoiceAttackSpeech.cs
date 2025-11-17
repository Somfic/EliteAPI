namespace EliteVA.Audio;

public class VoiceAttackSpeech
{
    private readonly dynamic _proxy;

    internal VoiceAttackSpeech(dynamic proxy)
    {
        _proxy = proxy;
    }

    /// <summary>
    /// Returns the captured audio of a voice command
    /// </summary>
    /// <param name="type">Which audio to return</param>
    public Task<MemoryStream> GetCapturedAudio(AudioType type)
    {
        return Task.FromResult(_proxy.Utility.CapturedAudio((int) type));
    }

    /// <summary>
    /// Resets the current speech engine
    /// </summary>
    public Task ResetSpeechEngine()
    {
        _proxy.Utility.ResetSpeechEngine();
        return Task.CompletedTask;
    }

    /// <summary>
    /// Whether the input device is muted
    /// </summary>
    public bool IsMuted => _proxy.Utility.GetSpeechRecordingDeviceMute();

    /// <summary>
    /// Mutes or unmutes the input device
    /// </summary>
    public Task SetMuted(bool isMuted)
    {
        _proxy.Utility.SetSpeechRecordingDeviceMute(isMuted);
        return Task.CompletedTask;
    }
}