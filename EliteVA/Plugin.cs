using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using EliteVA.Abstractions;
using EliteVA.Logging;

namespace EliteVA;

public class Plugin : VoiceAttackPlugin
{
    public override Task OnStart(IVoiceAttackProxy proxy)
    {
        _ = Task.Run(async () =>
        {
            while (true)
            {
                Log(VoiceAttackColor.Gray, "Connecting to EliteAPI...");

                try
                {
                    await Connect();
                }
                catch (Exception ex)
                {
                    Log(VoiceAttackColor.Red, "Could not connect to EliteAPI", ex);
                }

                await Task.Delay(1000);
            }
        });

        return Task.CompletedTask;
    }

    private async Task Connect()
    {
        await using var pipeClient = new NamedPipeClientStream(".", "eliteapi.sock", PipeDirection.InOut);
        await pipeClient.ConnectAsync();

        Log(VoiceAttackColor.Green, "Connected to EliteAPI");

        using var sr = new StreamReader(pipeClient, Encoding.UTF8);
        await using var sw = new StreamWriter(pipeClient, Encoding.UTF8);
        sw.AutoFlush = true;

        while (await sr.ReadLineAsync() is { } json)
        {
            if (string.IsNullOrWhiteSpace(json)) continue;

            var data = JsonSerializer.Deserialize<ServerEvent>(json);

            if (data == null)
                continue;

            if (data.VariablesEvent is { } variablesEvent)
            {
                foreach (var unsetVariable in variablesEvent.UnsetVariables)
                {
                    Proxy.Variables.ClearStartingWith(unsetVariable.Path);
                }

                foreach (var setVariable in variablesEvent.SetVariables)
                {
                    var typeCode = setVariable.ValueType switch
                    {
                        ValueType.Int32 => TypeCode.Int32,
                        ValueType.Single => TypeCode.Single,
                        ValueType.String => TypeCode.String,
                        ValueType.Boolean => TypeCode.Boolean,
                        ValueType.DateTime => TypeCode.DateTime,
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    Proxy.Variables.Set(setVariable.Path, setVariable.EncodedValue, typeCode);
                }

                var command = $"((EliteAPI.{variablesEvent.Event}))";

                if (Proxy.Commands.Exists(command))
                    Proxy.Commands.Invoke(command);
            }
        }
    }
}


