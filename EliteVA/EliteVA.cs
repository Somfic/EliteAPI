using System;
using System.Threading.Tasks;
using EliteApi;
using EliteVA.Abstractions;
using EliteVA.Logging;

namespace EliteVA;

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
