using EliteAPI.Events;
using EliteAPI.Status.Cargo;
using EliteAPI.Status.Market;
using EliteAPI.Status.Modules;
using EliteAPI.Status.Outfitting;
using EliteAPI.Status.Ship;
using EliteAPI.Status.Shipyard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EliteAPI.Utilities
{
    internal static class JournalProcessor
    {
        internal static EventBase TriggerEvents(string json, EliteDangerousAPI api)
        {
            try
            {
                // Get the event name.
                JObject parsedFromGame = JsonConvert.DeserializeObject<JObject>(json);
                string eventName = ((dynamic)parsedFromGame).@event;
                Logger.Debug($"Processing event {eventName}.");

                // Trigger the individual event.
                Type eventClass = GetEventClass(eventName);
                MethodInfo eventMethod = GetEventMethod(eventClass);
                EventBase eventBase = TriggerEvent(eventMethod, json, api);

                // Invoke the AllEvent
                api.Events.InvokeAllEvent(eventBase);

                // Check if the event is complete.
                CheckEvent(eventBase, json);

            }
            catch (Exception ex)
            {
                Logger.Error("Could not process JSON.", ex);
            }

            return null;
        }

        private static Type GetEventClass(string eventName)
        {
            return Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == $"{eventName}Info");
        }

        private static MethodInfo GetEventMethod(IReflect eventClass)
        {
            return eventClass.GetMethod("Process", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        }

        private static EventBase TriggerEvent(MethodBase eventMethod, string json, EliteDangerousAPI api)
        {
            return eventMethod.Invoke(null, new object[] { json, api }) as EventBase;
        }

        private static bool CheckEvent(EventBase eventBase, string json)
        {
            JObject parsedFromGame = JsonConvert.DeserializeObject<JObject>(json);
            string eventName = ((dynamic)parsedFromGame).@event;

            IEnumerable<string> gameProperties = PropertyReader.GetAllChildren(parsedFromGame, eventName);
            IEnumerable<string> apiProperties = PropertyReader.GetAllChildren(JObject.FromObject(eventBase), eventName);
            string[] missing = gameProperties.Except(apiProperties).ToArray();

            if (!missing.Any())
            {
                return false;
            }

            Logger.Warning($"Event {eventName} could not populate all properties ({string.Join(", ", missing)}).", parsedFromGame);

            return true;
        }

        internal static void TriggerSupportEvents(SupportFile file, string json, EliteDangerousAPI api)
        {
            switch (file)
            {
                case SupportFile.Status:
                    ShipStatus newStatus = JsonConvert.DeserializeObject<ShipStatus>(json);
                    ShipStatus oldStatus = api.Status;

                    api.Status = newStatus;

                    TriggerIfDifferent(api.Status, oldStatus, api);
                    break;

                case SupportFile.Cargo:
                    api.Cargo = JsonConvert.DeserializeObject<CargoStatus>(json);
                    break;
                case SupportFile.Market:
                    api.Market = JsonConvert.DeserializeObject<MarketStatus>(json);
                    break;
                case SupportFile.ModulesInfo:
                    api.Modules = JsonConvert.DeserializeObject<ModulesStatus>(json);
                    break;
                case SupportFile.Outfitting:
                    api.Outfitting = JsonConvert.DeserializeObject<OutfittingStatus>(json);
                    break;
                case SupportFile.Shipyard:
                    api.Shipyard = JsonConvert.DeserializeObject<ShipyardStatus>(json);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(file), file, null);
            }
        }

        private static void TriggerIfDifferent(ShipStatus oldStatus, ShipStatus newStatus, EliteDangerousAPI api)
        {
            foreach (PropertyInfo property in oldStatus.GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                dynamic oldValue = property.GetValue(oldStatus);
                dynamic newValue = property.GetValue(newStatus);

                if (oldValue == newValue)
                {
                    continue;
                }

                try
                {
                    // Invoke the status update event.
                    StatusEvent e = new StatusEvent("Status." + property.Name, newValue);
                    api.Events.InvokeAllEvent(new StatusEvent("Status." + property.Name, newValue));
                    try
                    {
                        api.Events.GetType()
                            .GetMethod("InvokeStatus" + property.Name,
                                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                                BindingFlags.Static)?.Invoke(api.Events, new object[] {e});
                    }
                    catch (Exception ex)
                    {
                        Logger.Debug($"Could not invoke status event '{property.Name}'.", ex);
                    }
                }
                catch (Exception ex) { Logger.Error("Could not do status.", ex); }
            }
        }


    }
}
