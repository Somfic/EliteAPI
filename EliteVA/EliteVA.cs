using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteAPI;
using EliteAPI.Journals;
using EliteAPI.Options.Audio;
using EliteAPI.Options.Bindings;
using EliteAPI.Utils;
using EliteVA.Abstractions;
using EliteVA.Logging;
using EliteAPI.Events;

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

        _api.OnKeybindingsChanged(bindings =>
        {
            var validBindings = bindings.Where(x => x.IsValid).ToList();
            var invalidBindings = bindings.Where(x => !x.IsValid && (x.Primary.HasValue || x.Secondary.HasValue)).ToList();
            
            foreach (var binding in validBindings)
                Proxy.Variables.Set($"EliteAPI.{binding.Name}", binding.KeyCode, TypeCode.String);

            var directory = Path.Combine(Dir, "Variables", "Keybindings");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            FileUtils.WriteWithRetry(Path.Combine(directory, "Keybindings.txt"), validBindings.Select(b => $"{{TXT:EliteAPI.{b.Name}}}: {b.KeyCode}").Aggregate((a, b) => $"{a}\n{b}"));
            FileUtils.WriteWithRetry(Path.Combine(directory, "Invalid keybindings.txt"), validBindings.Select(b => $"{{TXT:EliteAPI.{b.Name}}}: ?").Aggregate((a, b) => $"{a}\n{b}"));
            
            proxy.Log.Write($"Applied {validBindings.Count(b => !string.IsNullOrEmpty(b.KeyCode))} keybindings", VoiceAttackColor.Blue);
            if (invalidBindings.Count > 0)
                proxy.Log.Write(
                    $"Could not apply {invalidBindings.Count} keybindings. EliteAPI can only apply keyboard-only keybindings",
                    VoiceAttackColor.Yellow);

            var command = "((EliteAPI.KeybindingsChanged))";
            if (proxy.Commands.Exists(command))
                proxy.Commands.Invoke(command);
        });

        _api.OnAudioSettingsChanged(settings =>
        {
            foreach (var setting in settings)
            {
                if (setting.IsVolume)
                {
                    Proxy.Variables.Set($"EliteAPI.Audio.{setting.Name}", setting.Value!.Value.ToString(CultureInfo.InvariantCulture), TypeCode.Decimal);
                    if (setting.IsMuted.HasValue)
                        Proxy.Variables.Set($"EliteAPI.Audio.{setting.Name}.Muted", setting.IsMuted.Value.ToString(), TypeCode.Boolean);
                }
                else if (setting.IsToggle)
                {
                    Proxy.Variables.Set($"EliteAPI.Audio.{setting.Name}", setting.IsEnabled!.Value.ToString(), TypeCode.Boolean);
                }
            }

            var directory = Path.Combine(Dir, "Variables", "Audio");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (settings.Count > 0)
            {
                var lines = settings.Select(s => s.IsVolume
                    ? $"{{DEC:EliteAPI.Audio.{s.Name}}}: {s.Value:0.##}{(s.IsMuted == true ? " (muted)" : string.Empty)}"
                    : $"{{BOOL:EliteAPI.Audio.{s.Name}}}: {(s.IsEnabled == true ? "on" : "off")}");
                FileUtils.WriteWithRetry(Path.Combine(directory, "Audio.txt"), lines.Aggregate((a, b) => $"{a}\n{b}"));
            }

            proxy.Log.Write($"Applied {settings.Count} audio settings", VoiceAttackColor.Blue);

            var command = "((EliteAPI.AudioChanged))";
            if (proxy.Commands.Exists(command))
                proxy.Commands.Invoke(command);
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
                    EventValueType.String => TypeCode.String,
                    EventValueType.Number => TypeCode.Int32,
                    EventValueType.Decimal => TypeCode.Decimal,
                    EventValueType.Boolean => TypeCode.Boolean,
                    EventValueType.DateTime => TypeCode.DateTime,
                    _ => TypeCode.String
                });
            });
            
            var command = $"((EliteAPI.{e.eventName}))";
            if (proxy.Commands.Exists(command))
                proxy.Commands.Invoke(command);

            Log.Info($"Invoking {command} with {paths.Count} variables");

            // Only write variable files for non-synthetic events (Status change events don't need variable files)
            if (!e.eventName.StartsWith("Status.") && paths.Count > 0)
            {
                var directory = Path.Combine(Dir, "Variables", "Journals");
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                FileUtils.WriteWithRetry(Path.Combine(directory, $"{e.eventName}.txt"), paths.Select(p => $"{{{p.Type.ToDisplayType()}:{p.Path}}}: {p.Value}").Aggregate((a, b) => $"{a}\n{b}"));
            }
        });

        // set version variable
        proxy.Variables.Set("EliteAPI.Version", _api.Version.ToString(), TypeCode.String);
        
        _api.Start();
        WriteToLog(VoiceAttackColor.Green, $"EliteAPI started");
    }
}
