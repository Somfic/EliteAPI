using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Status
{
    public class StatusWatcher
    {
        private EliteDangerousAPI api;

        public StatusWatcher(EliteDangerousAPI api)
        {
            this.api = api;
            FileSystemWatcher statusWatcher = new FileSystemWatcher(api.JournalDirectory.FullName, "Status.json") { EnableRaisingEvents = true };
            statusWatcher.Changed += (sender, e) => Update();

            Update();
        }

        private void Update()
        {
            //Save the old status.
            ShipStatus oldStatus = api.Status;
            ShipStatus newStatus = ShipStatus.FromFile(new FileInfo(api.JournalDirectory + "//Status.json"), api);

            //Set the new status.
            api.Status = newStatus;

            if(oldStatus == null) { return; }
            if(oldStatus.Flags == newStatus.Flags) { return; }

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
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(new StatusEvent("Status." + propA.Name, B)));
                    api.Events.InvokeAllEvent(new StatusEvent("Status." + propA.Name, B));
                    try { api.Events.GetType().GetMethod("InvokeStatus" + propA.Name).Invoke(api.Events, new object[] { B }); }
                    catch (Exception ex) { api.Logger.LogError($"Could not invoke status event {propA.Name}, it might not have been added yet. {Environment.NewLine}Error: {ex.Message}"); }
                }
            }
        }
    }

    public class StatusEvent
    {
        public StatusEvent(string eventName, object value)
        {
            this.@event = eventName;
            this.value = value;
        }

        public string @event { get; set; }
        public object value { get; set; }
    }
}
