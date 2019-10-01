using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EliteAPI.Status
{
    internal class CargoWatcher
    {
        private EliteDangerousAPI api;
        private FileSystemWatcher CargoFileWatcher;

        internal CargoWatcher(EliteDangerousAPI api)
        {
            this.api = api;

            CargoFileWatcher = new FileSystemWatcher(api.JournalDirectory.FullName, "Cargo.json") { EnableRaisingEvents = true };
            CargoFileWatcher.Changed += (sender, e) => Update();

            Update();
        }

        private void Update()
        {
            //Save the old Cargo.
            ShipCargo oldCargo = api.Cargo;
            if(oldCargo == null) { oldCargo = new ShipCargo(); }

            ShipCargo newCargo = ShipCargo.FromFile(new FileInfo(api.JournalDirectory + "//Cargo.json"), api);

            //Set the new Cargo.
            api.Cargo = newCargo;

            if(oldCargo == null) { return; }

            TriggerIfDifferent(oldCargo, newCargo);
        }

        private void TriggerIfDifferent(ShipCargo oldCargo, ShipCargo newCargo)
        {
            foreach (PropertyInfo propA in oldCargo.GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                PropertyInfo propB = newCargo.GetType().GetProperty(propA.Name);

                bool A = (bool)propA.GetValue(oldCargo);
                bool B = (bool)propB.GetValue(newCargo);

                if(A != B)
                {
                    api.Events.InvokeAllEvent(new CargoEvent("Cargo." + propA.Name, B));
                    try { api.Events.GetType().GetMethod("InvokeCargo" + propA.Name).Invoke(api.Events, new object[] { B }); }
                    catch (Exception ex) { api.Logger.Error($"Could not invoke Cargo event {propA.Name}, it might not have been added yet.", ex); }
                }
            }
        }
    }

    public class CargoEvent
    {
        public CargoEvent(string eventName, object value)
        {
            @Event = eventName;
            Value = value;
        }

        public string @Event { get; internal set; }
        public object Value { get; internal set; }
    }
}
