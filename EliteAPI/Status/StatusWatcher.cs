using EliteAPI.Events;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Somfic.Logging;

namespace EliteAPI.Status
{
    public class StatusWatcher
    {
        private EliteDangerousAPI api;
        private FileSystemWatcher statusWatcher;
        private bool InNoFireZone = false;
        private float JumpRange = -1;
        private float MaxFuel = -1;
        private GameModeType GameMode = GameModeType.Solo;
        private bool InMainMenu = false;
        private string MusicTrack = "";

        internal StatusWatcher(EliteDangerousAPI api)
        {
            this.api = api;
            api.Events.ReceiveTextEvent += Events_ReceiveTextEvent;
            api.Events.FSDJumpEvent += Events_FSDJumpEvent;
            api.Events.LoadGameEvent += Events_LoadGameEvent;
            api.Events.MusicEvent += Events_MusicEvent;
            api.Events.SupercruiseEntryEvent += Events_SupercruiseEntryEvent;
            api.Events.StartJumpEvent += Events_StartJumpEvent;
            statusWatcher = new FileSystemWatcher(api.JournalDirectory.FullName, "Status.json")
            {
                EnableRaisingEvents = true
            };
            statusWatcher.Changed += (sender, e) => Update();
            Update();
        }
        private void Events_StartJumpEvent(object sender, StartJumpInfo e)
        {
            InNoFireZone = false;
            Update();
        }
        private void Events_SupercruiseEntryEvent(object sender, SupercruiseEntryInfo e)
        {
            InNoFireZone = false;
            Update();
        }
        private void Events_MusicEvent(object sender, Events.MusicInfo e)
        {
            MusicTrack = e.MusicTrack;
            InMainMenu = e.MusicTrack == "MainMenu";
            Update();
        }
        private void Events_LoadGameEvent(object sender, Events.LoadGameInfo e)
        {
            MaxFuel = e.FuelCapacity;
            GameMode = e.GameMode;
            Update();
        }
        private void Events_FSDJumpEvent(object sender, Events.FSDJumpInfo e)
        {
            InNoFireZone = false;
            if(JumpRange < e.JumpDist) { JumpRange = e.JumpDist; }
            Update();
        }

        private void Events_ReceiveTextEvent(object sender, ReceiveTextInfo e)
        {
            if (e.Message.Contains("NoFireZone_entered"))
            {
                InNoFireZone = true;
            }
            else if (e.Message.Contains("NoFireZone_exited"))
            {
                InNoFireZone = false;
            }

            Update();
        }

        private void Update()
        {
            //Save the old status.
            var oldStatus = api.Status ?? new GameStatus();
            var newStatus = GameStatus.FromFile(new FileInfo(Path.Combine(api.JournalDirectory.FullName, "Status.json")), api);

            if (newStatus == null || !File.Exists(Path.Combine(api.JournalDirectory.FullName, "Status.json")))
            {
                return;
            }

            newStatus.InNoFireZone = InNoFireZone;
            newStatus.JumpRange = JumpRange;
            newStatus.Fuel.MaxFuel = MaxFuel;
            newStatus.GameMode = GameMode;
            newStatus.InMainMenu = InMainMenu;
            newStatus.MusicTrack = MusicTrack;

            if (newStatus.Docked)
            {
                newStatus.InNoFireZone = true;
            }

            //Set the new status.
            api.Status = newStatus;
            TriggerIfDifferent(oldStatus, newStatus);
        }

        private void TriggerIfDifferent(GameStatus oldStatus, GameStatus newStatus)
        {
            foreach (var propA in oldStatus.GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                var propB = newStatus.GetType().GetProperty(propA.Name);
                dynamic A = propA.GetValue(oldStatus);
                dynamic B = propB.GetValue(newStatus);

                if (A == B)
                {
                    continue;
                }

                try
                {
                    var e = new StatusEvent($"Status.{propA.Name}", B);
                    api.Logger.Log(Severity.Debug, $"Setting status '{propA.Name}' to {Convert.ToString(B).ToLower()}.", e);
                    api.Events.InvokeAllEvent(new StatusEvent($"Status.{propA.Name}", B));

                    try
                    {
                        api.Events.GetType().GetMethod($"InvokeStatus{propA.Name}", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)?.Invoke(api.Events, new object[] {e});
                    }
                    catch (Exception ex)
                    {
                        api.Logger.Log(Severity.Debug, $"Could not invoke status event '{propA.Name}'.", ex);
                    }
                }
                catch (Exception ex)
                {
                    api.Logger.Log(Severity.Error, "Could not do status.", ex);
                }
            }
        }
    }
}
