using System;
using System.Linq;
using System.Threading.Tasks;
using EliteApi;
using EliteAPI.Json;
using EliteVA.Abstractions;
using EliteVA.Logging;

namespace EliteVA;

public class Plugin : VoiceAttackPlugin
{
    private EliteDangerousApi _api = null!;

    public override async Task OnStart(IVoiceAttackProxy proxy)
    {
        _api = new EliteDangerousApi();

        _api.OnPathsChanged(e =>
        {
            e.variables.ForEach(v =>
            {
                proxy.Variables.Set(v.Path, v.Value, v.Type switch
                {
                    JsonType.String => TypeCode.String,
                    JsonType.Number => TypeCode.Int32,
                    JsonType.Decimal => TypeCode.Decimal,
                    JsonType.Boolean => TypeCode.Boolean,
                    JsonType.DateTime => TypeCode.DateTime,
                    _ => TypeCode.String
                });

                var command = $"(({e.command}))";
                if (proxy.Commands.Exists(command))
                    proxy.Commands.Invoke(command);
            });

            Log(VoiceAttackColor.Yellow, $"{e.command}");
        });

        _api.Start();
        Log(VoiceAttackColor.Green, $"EliteAPI started");
    }

    private TypeCode FromJsonType(JsonType type)
    {
        return type switch
        {
            JsonType.String => TypeCode.String,
            JsonType.Number => TypeCode.Int32,
            JsonType.Decimal => TypeCode.Decimal,
            JsonType.Boolean => TypeCode.Boolean,
            JsonType.DateTime => TypeCode.DateTime,
            _ => TypeCode.String
        };
    }
}
