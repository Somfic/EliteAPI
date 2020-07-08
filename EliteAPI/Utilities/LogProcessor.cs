using EliteAPI.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Somfic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EventHandler = EliteAPI.Events.EventHandler;

namespace EliteAPI.Utilities
{
    internal static class LogProcessor
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

            if (!missing.Any()) return false;

            Logger.Warning($"Event {eventName} could not populate all properties ({string.Join(", ", missing)}).", parsedFromGame);

            return true;
        }
    }
}
