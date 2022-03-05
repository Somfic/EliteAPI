using System.Collections.Generic;

namespace EliteAPI.VoiceAttack.Messages.Paths;

public struct EventPaths
{
    public EventPaths(IList<EventPath> paths)
    {
        Paths = paths;
    }
        
    public IList<EventPath> Paths { get; }
}