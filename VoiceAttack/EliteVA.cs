using System;
using System.Threading.Tasks;
using EliteApi;
using VoiceAttack.Abstractions;
using VoiceAttack.Logging;

namespace VoiceAttack;

public class Plugin : VoiceAttackPlugin
{
    private EliteDangerousApi _api;

    public override async Task OnStart(IVoiceAttackProxy proxy)
    {
        _api = new EliteDangerousApi();

        _api.OnJournalEvent(e =>
        {
            Log(VoiceAttackColor.Blue, $"Event: {e.eventName}");
        });

        Log(VoiceAttackColor.Green, $"EliteAPI loaded - watching for journal events");
    }
}
