using System.Collections.Generic;

namespace EliteAPI.VoiceAttack.Messages.Variables;

public struct Variables
{
    public Variables(IList<Variable> variables)
    {
        Members = variables;
    }
        
    public IList<Variable> Members { get; }
}