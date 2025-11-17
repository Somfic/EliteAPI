using EliteVA.Abstractions;

namespace EliteVA;

public abstract class VoiceAttackService
{
    public abstract Task OnStart(IVoiceAttackProxy proxy);

    public virtual Task OnInvoke(IVoiceAttackProxy proxy, string context) { return Task.CompletedTask; }

    public virtual Task OnCommandStopped(IVoiceAttackProxy proxy) { return Task.CompletedTask; }

    public virtual Task OnStop(IVoiceAttackProxy proxy) { return Task.CompletedTask; }
}