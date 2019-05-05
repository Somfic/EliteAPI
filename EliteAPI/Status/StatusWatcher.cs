using EliteAPI.Events;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EliteAPI.Status
{
    internal class StatusWatcher
    {
        private EliteDangerousAPI api;
        private FileSystemWatcher statusWatcher;

        private bool InNoFireZone = false;
        private double JumpRange = -1;
        private double MaxFuel = -1;
        private string GameMode = "";
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

            statusWatcher = new FileSystemWatcher(api.JournalDirectory.FullName, "Status.json") { EnableRaisingEvents = true };
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

            if(e.MusicTrack == "MainMenu") { InMainMenu = true; }
            else { InMainMenu = false; }

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

        private void Events_ReceiveTextEvent(object sender, Events.ReceiveTextInfo e)
        {
            if(e.Message.Contains("NoFireZone_entered")) { InNoFireZone = true; }
            else if(e.Message.Contains("NoFireZone_exited")) { InNoFireZone = false; }

            Update();
        }

        private void Update()
        {
            //Save the old status.
            GameStatus oldStatus = api.Status;
            if (oldStatus == null) { oldStatus = new GameStatus(); }

            GameStatus newStatus = GameStatus.FromFile(new FileInfo(api.JournalDirectory + "//Status.json"), api);
            if (newStatus == null || !File.Exists(api.JournalDirectory + "//Status.json")) { api.Logger.LogWarning("Could not update Status.json file."); return; }

            newStatus.InNoFireZone = InNoFireZone;
            newStatus.JumpRange = JumpRange;
            newStatus.Fuel.MaxFuel = MaxFuel;
            newStatus.GameMode = GameMode;
            newStatus.InMainMenu = InMainMenu;

            if (newStatus.Docked) { newStatus.InNoFireZone = true; }

            //Set the new status.
            api.Status = newStatus;

            if(oldStatus == null) { return; }

            TriggerIfDifferent(oldStatus, newStatus);
        }

        private void TriggerIfDifferent(GameStatus oldStatus, GameStatus newStatus)
        {
            foreach (PropertyInfo propA in oldStatus.GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                PropertyInfo propB = newStatus.GetType().GetProperty(propA.Name);

                dynamic A = (dynamic)propA.GetValue(oldStatus);
                dynamic B = (dynamic)propB.GetValue(newStatus);

                if(A != B)
                {
                    try
                    {

                        StatusEvent e = new StatusEvent("Status." + propA.Name, B);

                        api.Logger.LogDebugEvent($"Processing status event '{propA.Name}' ({B}).", e);

                        api.Events.InvokeAllEvent(new StatusEvent("Status." + propA.Name, B));

                        try { api.Events.GetType().GetMethod("InvokeStatus" + propA.Name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).Invoke(api.Events, new object[] { e }); }
                        catch (Exception ex) { api.Logger.LogError($"Could not invoke status event '{propA.Name}', it might not have been added yet.", ex); }
                    }
                    catch(Exception ex) { api.Logger.LogError("Could not do status.", ex); }
                }
            }
        }
    }
}
