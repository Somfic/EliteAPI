using System;
using System.Threading.Tasks;
using EliteAPI;
using EliteAPI.Journals;
using EliteVA.Abstractions;
using EliteVA.Logging;
using ValueType = EliteAPI.Events.ValueType;

namespace EliteVA;

public class Plugin : VoiceAttackPlugin
{
    private EliteDangerousApi _api = null!;

    public override async Task OnStart(IVoiceAttackProxy proxy)
    {
        _api = new EliteDangerousApi();

        _api.OnAllJson(e =>
        {
            var paths = JournalUtils.ToPaths(e.json);

            paths.ForEach(v =>
            {
                proxy.Variables.Set(v.Path, v.Value, v.Type switch
                {
                    ValueType.String => TypeCode.String,
                    ValueType.Number => TypeCode.Int32,
                    ValueType.Decimal => TypeCode.Decimal,
                    ValueType.Boolean => TypeCode.Boolean,
                    ValueType.DateTime => TypeCode.DateTime,
                    _ => TypeCode.String
                });

                var command = $"(({e.eventName}))";
                if (proxy.Commands.Exists(command))
                    proxy.Commands.Invoke(command);
            });

            Log(VoiceAttackColor.Yellow, $"{e.eventName}");
        });

        _api.Start();
        Log(VoiceAttackColor.Green, $"EliteAPI started");
    }
}
