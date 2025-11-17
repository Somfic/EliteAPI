namespace EliteVA.Audio;

public enum AudioType
{
    /// <summary>
    /// The last recognized voice command audio
    /// </summary>
    LastRecognized,

    /// <summary>
    /// The previous recognized voice command audio
    /// </summary>
    PreviousRecognized,

    /// <summary>
    /// The last unrecognized voice command audio
    /// </summary>
    LastUnrecognized,

    /// <summary>
    /// The last voice command audio
    /// </summary>
    Last,

    /// <summary>
    /// The previous voice command audio
    /// </summary>
    Previous,

    /// <summary>
    /// The voice command audio from dictation mode
    /// </summary>
    Dictated
}