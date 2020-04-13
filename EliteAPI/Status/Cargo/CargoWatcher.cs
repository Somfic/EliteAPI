    using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Somfic.Logging;

namespace EliteAPI.Status.Cargo
{
    public class CargoWatcher
    {
        private EliteDangerousAPI api;
        private FileSystemWatcher CargoFileWatcher;

        internal CargoWatcher(EliteDangerousAPI api)
        {
            this.api = api;
            CargoFileWatcher = new FileSystemWatcher(api.JournalDirectory.FullName, "Cargo.json") {EnableRaisingEvents = true};
            CargoFileWatcher.Changed += (sender, e) => Update();
            Update();
        }

        private void Update()
        {
            var oldCargo = api.Cargo ?? new ShipCargo();

            var newCargo = ShipCargo.FromFile(new FileInfo(api.JournalDirectory + "//Cargo.json"), api);

            api.Cargo = newCargo;

            if (oldCargo == null)
            {
                return;
            }

            TriggerIfDifferent(oldCargo, newCargo);
        }

        private void TriggerIfDifferent(ShipCargo oldCargo, ShipCargo newCargo)
        {
            foreach (PropertyInfo propA in oldCargo.GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                PropertyInfo propB = newCargo.GetType().GetProperty(propA.Name);
                bool A = (bool) propA.GetValue(oldCargo);
                bool B = (bool) propB.GetValue(newCargo);

                if (A != B)
                {
                    api.Events.InvokeAllEvent(new CargoEvent("Cargo." + propA.Name, B));

                    try
                    {
                        api.Events.GetType().GetMethod("InvokeCargo" + propA.Name)?.Invoke(api.Events, new object[] {B});
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(Severity.Error, $"Could not invoke Cargo event {propA.Name}, it might not have been added yet.", ex);
                    }
                }
            }
        }
    }
}