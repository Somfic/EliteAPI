using Somfic.Logging.VoiceAttack;
using Somfic.VoiceAttack.Proxy;
using Somfic.VoiceAttack.Proxy.Abstractions;

using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

using EliteAPI;
using EliteAPI.Abstractions;
using EliteAPI.Event.Models.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace EliteVA
{
    public class VoiceAttackPlugin
    {
        private static IVoiceAttackProxy Proxy { get; set; }
        private static IHost Host { get; set; }
        private static IEliteDangerousApi Api { get; set; }
        private static ILogger<VoiceAttackPlugin> Log { get; set; }

        public static Guid VA_Id()
        {
            return new Guid("189a4e44-caf1-459b-b62e-fabc60a12986");
        }

        public static string VA_DisplayName()
        {
            return "EliteVA";
        }

        public static string VA_DisplayInfo()
        {
            return "EliteVA by Somfic";
        }

        public static void VA_Init1(dynamic vaProxy)
        {
            try { Initialize(vaProxy); }
            catch (Exception ex) { File.WriteAllText("eliteva.init.error", JsonConvert.SerializeObject(ex)); }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            try { Proxy = new VoiceAttackProxy(vaProxy, Host.Services); }
            catch (Exception ex) { File.WriteAllText("eliteva.exit.error", JsonConvert.SerializeObject(ex)); }
        }

        public static void VA_StopCommand()
        {
            try { Log?.LogInformation("EliteVA was stopped"); }
            catch (Exception ex) { File.WriteAllText("eliteva.stop.error", JsonConvert.SerializeObject(ex)); }
        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            try { Proxy = new VoiceAttackProxy(vaProxy, Host.Services); }
            catch (Exception ex) { File.WriteAllText("eltiva.invoke.error", JsonConvert.SerializeObject(ex)); }
        }

        private static void Initialize(dynamic vaProxy)
        {
            string pluginDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppDomain.CurrentDomain.BaseDirectory;

            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => { services.AddEliteAPI(); })
                .ConfigureLogging((context, log) =>
                {
                    log.SetMinimumLevel(LogLevel.Trace);
                    VoiceAttackLoggerExtensions.AddVoiceAttack(log, vaProxy);
                })
                .Build();

            Proxy = new VoiceAttackProxy(vaProxy, Host.Services);

            Api = Host.Services.GetService<IEliteDangerousApi>();
            Log = Host.Services.GetService<ILogger<VoiceAttackPlugin>>();

            SubscribeToEvents();

            if (Api != null)
                Api.StartAsync();
            else
                Log.LogCritical("EliteVA could not be found");
        }

        private static void SubscribeToEvents()
        {
            Api.Events.AllEvent += OnEliteDangerousEvent;

            Api.Ship.Available.OnChange += (sender, e) => SetShipVariable("Available", e);
            Api.Ship.Docked.OnChange += (sender, e) => SetShipVariable("Docked", e);
            Api.Ship.Landed.OnChange += (sender, e) => SetShipVariable("Landed", e);
            Api.Ship.Gear.OnChange += (sender, e) => SetShipVariable("Gear", e);
            Api.Ship.Shields.OnChange += (sender, e) => SetShipVariable("Shields", e);
            Api.Ship.Supercruise.OnChange += (sender, e) => SetShipVariable("Supercruise", e);
            Api.Ship.FlightAssist.OnChange += (sender, e) => SetShipVariable("FlightAssist", e);
            Api.Ship.Hardpoints.OnChange += (sender, e) => SetShipVariable("Hardpoints", e);
            Api.Ship.Winging.OnChange += (sender, e) => SetShipVariable("Winging", e);
            Api.Ship.Lights.OnChange += (sender, e) => SetShipVariable("Lights", e);
            Api.Ship.CargoScoop.OnChange += (sender, e) => SetShipVariable("CargoScoop", e);
            Api.Ship.SilentRunning.OnChange += (sender, e) => SetShipVariable("SilentRunning", e);
            Api.Ship.Scooping.OnChange += (sender, e) => SetShipVariable("Scooping", e);
            Api.Ship.SrvHandbreak.OnChange += (sender, e) => SetShipVariable("SrvHandbreak", e);
            Api.Ship.MassLocked.OnChange += (sender, e) => SetShipVariable("MassLocked", e);
            Api.Ship.FsdCharging.OnChange += (sender, e) => SetShipVariable("FsdCharging", e);
            Api.Ship.FsdCooldown.OnChange += (sender, e) => SetShipVariable("FsdCooldown", e);
            Api.Ship.LowFuel.OnChange += (sender, e) => SetShipVariable("LowFuel", e);
            Api.Ship.Overheating.OnChange += (sender, e) => SetShipVariable("Overheating", e);
            Api.Ship.HasLatLong.OnChange += (sender, e) => SetShipVariable("HasLatLong", e);
            Api.Ship.InDanger.OnChange += (sender, e) => SetShipVariable("InDanger", e);
            Api.Ship.InInterdiction.OnChange += (sender, e) => SetShipVariable("InInterdiction", e);
            Api.Ship.InMothership.OnChange += (sender, e) => SetShipVariable("InMothership", e);
            Api.Ship.InFighter.OnChange += (sender, e) => SetShipVariable("InFighter", e);
            Api.Ship.InSrv.OnChange += (sender, e) => SetShipVariable("InSrv", e);
            Api.Ship.AnalysisMode.OnChange += (sender, e) => SetShipVariable("AnalysisMode", e);
            Api.Ship.NightVision.OnChange += (sender, e) => SetShipVariable("NightVision", e);
            Api.Ship.AltitudeFromAverageRadius.OnChange +=
                (sender, e) => SetShipVariable("AltitudeFromAverageRadius", e);
            Api.Ship.FsdJump.OnChange += (sender, e) => SetShipVariable("FsdJump", e);
            Api.Ship.SrvHighBeam.OnChange += (sender, e) => SetShipVariable("SrvHighBeam", e);
            Api.Ship.Pips.OnChange += (sender, e) =>
            {
                SetShipVariable("Pips.Engines", e.Engines, false);
                SetShipVariable("Pips.System", e.System, false);
                SetShipVariable("Pips.Weapons", e.Weapons, false);
                SetShipVariable("Pips", string.Empty);
            };
            Api.Ship.FireGroup.OnChange += (sender, e) => SetShipVariable("FireGroup", e);
            Api.Ship.GuiFocus.OnChange += (sender, e) => SetShipVariable("GuiFocus", e.ToString());
            Api.Ship.Fuel.OnChange += (sender, e) =>
            {
                SetShipVariable("Fuel.Main", e.Main, false);
                SetShipVariable("Fuel.Reservoir", e.Reservoir, false);
                SetShipVariable("Fuel", string.Empty);
            };
            Api.Ship.Cargo.OnChange += (sender, e) => SetShipVariable("Cargo", e);
            Api.Ship.LegalState.OnChange += (sender, e) => SetShipVariable("LegalState", e.ToString());
            Api.Ship.Latitude.OnChange += (sender, e) => SetShipVariable("Latitude", e);
            Api.Ship.Altitude.OnChange += (sender, e) => SetShipVariable("Altitude", e);
            Api.Ship.Longitude.OnChange += (sender, e) => SetShipVariable("Longitude", e);
            Api.Ship.Heading.OnChange += (sender, e) => SetShipVariable("Heading", e);
            Api.Ship.Body.OnChange += (sender, e) => SetShipVariable("Body", e);
            Api.Ship.BodyRadius.OnChange += (sender, e) => SetShipVariable("BodyRadius", e);
        }

        private static string ToEventCommand(IEvent e) => ToEventCommand(e.Event);

        private static string ToEventCommand(string command) => $"((EliteAPI.{command}))";

        private static string ToEventVariable(string variable) => $"EliteAPI.{variable}";

        private static string ToShipCommand(string command) => $"((EliteApi.Ship.{command}))";
        private static string ToShipVariable(string variable) => $"EliteAPI.{variable}";

        private static void SetShipVariable<T>(string name, T value, bool triggerChangeCommand = true)
        {
            string variable = ToShipVariable(name);
            string command = ToShipCommand(name);

            if (value.ToString() != string.Empty) { Proxy.Variables.Set(variable, value); }

            if (Api.HasCatchedUp && triggerChangeCommand) { TriggerCommand(command, $"{name} status"); }
        }

        private static void OnEliteDangerousEvent(object sender, EventBase e)
        {
            string command = ToEventCommand(e);

            if (Api.HasCatchedUp)
            {
                if (HasBeenSubscribedTo(e)) { SetVariables(e); }

                TriggerCommand(command, $"{e.Event} event");
            }
        }

        private static bool HasBeenSubscribedTo(IEvent e) => HasBeenSubscribedTo(ToEventCommand(e));

        private static bool HasBeenSubscribedTo(string command) =>
            Proxy.Commands.Exists(command).GetAwaiter().GetResult();

        private static void SetVariables(IEvent e) => SetVariables(e, e.Event);

        private static void SetVariables(object value, string eventName)
        {
            PropertyInfo[] properties = value.GetType().GetProperties();

            foreach (PropertyInfo property in properties) { SetVariable(property, value, property.Name, eventName); }
        }

        private static void SetVariable(PropertyInfo property, object instance, string name, string eventName)
        {
            try
            {
                Type propertyType = property.PropertyType;
                TypeCode typeCode = Type.GetTypeCode(propertyType);

                switch (typeCode)
                {
                    case TypeCode.Empty:
                        Log.LogDebug("Could not set {Property} in {Name} event because the type was empty", name,
                            eventName);
                        return;

                    case TypeCode.Object:
                        SetVariables(property.GetValue(instance), $"{name}.{property.Name}");
                        return;

                    default:
                        string variable = ToEventVariable(name);
                        Type type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        object value = Convert.ChangeType(property.GetValue(instance), type);
                        Proxy.Variables.Set(variable, value);
                        break;
                }
            }
            catch (Exception ex) { Log.LogDebug(ex, "Could not set 'EliteAPI.Event.{Name}'", name); }
        }

        private static void TriggerCommand(string command, string source)
        {
            if (Proxy.Commands.Exists(command).GetAwaiter().GetResult())
            {
                Log.LogDebug("Invoking '{Command}' for {Event}", command, source);
                Proxy.Commands.Invoke(command).GetAwaiter().GetResult();
            }
            else { Log.LogDebug("Skipping '{Command}' for {Event}", command, source); }
        }
    }
}