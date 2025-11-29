using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI;
using EliteAPI.Bindings;
using EliteAPI.Journals;
using EliteAPI.Utils;
using EliteVA.Abstractions;
using EliteVA.Logging;
using ValueType = EliteAPI.Events.ValueType;

namespace EliteVA;

public class Plugin : VoiceAttackPlugin
{
    private EliteDangerousApi _api = null!;

    public override async Task OnStart(IVoiceAttackProxy proxy)
    {
        var path = Path.Combine(Dir, "Logs", $"EliteAPI-{DateTime.Now:yyyy-MM-dd}.log");
        Log.SetLogFilePath(path);

        _api = new EliteDangerousApi();

        // logging
        Log.AddListener(log =>
        {
            if (log.Level < Log.LogLevel.Warning)
                return;

            VoiceAttackColor color = log.Level switch
            {
                Log.LogLevel.Warning => VoiceAttackColor.Yellow,
                Log.LogLevel.Error => VoiceAttackColor.Red,
                _ => VoiceAttackColor.Blank
            };

            proxy.Log.Write($"{log.Message}", color);
        });

        // journal changed
        _api.OnJournalChanged(e =>
        {
            proxy.Log.Write($"Watching {e.Name}", VoiceAttackColor.Blue);
        });

        _api.OnKeybindingsChanged(e =>
        {
            List<(string name, Binding binding)> bindings = [];

            foreach (var binding in e)
            {
                Binding keyboardBinding;

                if (binding.Primary.HasValue && binding.Primary.Value.Device == "Keyboard")
                    keyboardBinding = binding.Primary.Value;
                else if (binding.Secondary.HasValue && binding.Secondary.Value.Device == "Keyboard")
                    keyboardBinding = binding.Secondary.Value;
                else
                    continue;

                bindings.Add((binding.Name, keyboardBinding));

                Proxy.Variables.Set($"EliteAPI.{binding.Name}", binding.Primary.HasValue ? binding.Primary.Value.KeyCode : "", TypeCode.String);
            }

            if (!Directory.Exists(Path.Combine(Dir, "Variables")))
                Directory.CreateDirectory(Path.Combine(Dir, "Variables"));

            File.WriteAllText(Path.Combine(Dir, "Variables", $"Keybindings.txt"), bindings.Select(b => $"{b.name}: {b.binding.KeyCode}").Aggregate((a, b) => $"{a}\n{b}"));

            proxy.Log.Write($"Applying {bindings.Count} keybindings", VoiceAttackColor.Blue);
        });

        // json event
        _api.OnAllJson(e =>
        {
            var paths = JournalUtils.ToPaths(e.json);

            paths.ForEach(v =>
            {
                var stringValue = Convert.ToString(v.Value, CultureInfo.InvariantCulture) ?? string.Empty;
                proxy.Variables.Set(v.Path, stringValue, v.Type switch
                {
                    ValueType.String => TypeCode.String,
                    ValueType.Number => TypeCode.Int32,
                    ValueType.Decimal => TypeCode.Decimal,
                    ValueType.Boolean => TypeCode.Boolean,
                    ValueType.DateTime => TypeCode.DateTime,
                    _ => TypeCode.String
                });
            });

            // For Status field change events, use EliteAPI.Status.{Field} format
            // For regular events, use the event name as-is
            var commandName = e.eventName.StartsWith("Status.")
                ? $"EliteAPI.{e.eventName}"
                : e.eventName;

            var command = $"(({commandName}))";
            if (proxy.Commands.Exists(command))
                proxy.Commands.Invoke(command);

            Log.Info($"Invoking {command} with {paths.Count} variables");

            // Only write variable files for non-synthetic events (Status change events don't need variable files)
            if (!e.eventName.StartsWith("Status.") && paths.Count > 0)
            {
                if (!Directory.Exists(Path.Combine(Dir, "Variables")))
                    Directory.CreateDirectory(Path.Combine(Dir, "Variables"));

                File.WriteAllText(Path.Combine(Dir, "Variables", $"{e.eventName}.txt"), paths.Select(p => $"{p.Path}: {p.Value}").Aggregate((a, b) => $"{a}\n{b}"));
            }
        });

        _api.Start();
        WriteToLog(VoiceAttackColor.Green, $"EliteAPI started");
    }
}
