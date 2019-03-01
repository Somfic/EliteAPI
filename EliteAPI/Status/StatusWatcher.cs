using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EliteAPI.Status
{
    public class StatusWatcher
    {
        private EliteDangerousAPI api;
        private FileSystemWatcher statusWatcher;

        private bool InNoFireZone = false;

        internal StatusWatcher(EliteDangerousAPI api)
        {
            this.api = api;

            api.Events.ReceiveTextEvent += Events_ReceiveTextEvent;
            statusWatcher = new FileSystemWatcher(api.JournalDirectory.FullName, "Status.json") { EnableRaisingEvents = true };
            statusWatcher.Changed += (sender, e) => Update();

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
            ShipStatus oldStatus = api.Status;
            if(oldStatus == null) { oldStatus = new ShipStatus(); }

            ShipStatus newStatus = ShipStatus.FromFile(new FileInfo(api.JournalDirectory + "//Status.json"), api);
            if(newStatus == null) { api.Logger.LogWarning("Could not update Status.json file."); return; }

            newStatus.InNoFireZone = InNoFireZone;

            //Set the new status.
            api.Status = newStatus;

            if(oldStatus == null) { return; }

            TriggerIfDifferent(oldStatus, newStatus);
        }

        private void TriggerIfDifferent(ShipStatus oldStatus, ShipStatus newStatus)
        {
            foreach (PropertyInfo propA in oldStatus.GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                PropertyInfo propB = newStatus.GetType().GetProperty(propA.Name);

                bool A = (bool)propA.GetValue(oldStatus);
                bool B = (bool)propB.GetValue(newStatus);

                if(A != B)
                {
                    api.Logger.LogDebug($"Processing status event '{propA.Name}'.");
                    api.Events.InvokeAllEvent(new StatusEvent("Status." + propA.Name, B));
                    try { api.Events.GetType().GetMethod("InvokeStatus" + propA.Name).Invoke(api.Events, new object[] { B }); }
                    catch (Exception ex) { api.Logger.LogError($"Could not invoke status event '{propA.Name}', it might not have been added yet.", ex); }
                }
            }
        }
    }

    public class StatusEvent
    {
        public StatusEvent(string eventName, object value)
        {
            @Event = eventName;
            Value = value;
        }

        public string @Event { get; internal set; }
        public object Value { get; internal set; }
    }
}
