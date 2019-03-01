using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.ThirdParty.EliteVA
{
    public class VAPlugin
    {
        private static DirectoryInfo playerJournalDirectory;
        private static EliteDangerousAPI api;
        private static dynamic _vaProxy;

        private static void SetJournalFolder()
        {
            if (!File.Exists("EliteVA.ini"))
            {
                File.WriteAllText("EliteVA.ini", "//Example" + Environment.NewLine);
                File.AppendAllText("EliteVA.ini", @"//path=D:\Saved Games\Frontier Developments");
                playerJournalDirectory = EliteDangerousAPI.StandardDirectory;
            }
            else
            {
                try
                {
                    playerJournalDirectory = new DirectoryInfo(File.ReadAllLines("EliteVA.ini").Where(x => !x.StartsWith("/")).First().Split(new string[] { "path=" }, StringSplitOptions.None)[1]);
                }
                catch { playerJournalDirectory = EliteDangerousAPI.StandardDirectory; }
            }
        }

        public static string VA_DisplayName() { return "EliteVA"; }

        public static string VA_DisplayInfo() { return "EliteVA by Somfic"; }

        public static Guid VA_Id() { return new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}"); }

        public static void VA_Init1(dynamic vaProxy)
        {
            _vaProxy = vaProxy;

            SetJournalFolder();

            api = new EliteDangerousAPI(playerJournalDirectory, true);
            api.Logger.UseLogFile(new DirectoryInfo(Directory.GetCurrentDirectory()));
            api.Logger.Log += Logger_Log;
            api.Events.AllEvent += EliteAPI_AllEvent;
            api.Start();

            _vaProxy.SetText("EliteAPI.Version", api.Version);

            VA_Invoke1(vaProxy);
        }

        private static void Logger_Log(object sender, Logging.LogMessage e)
        {
            switch (e.Severity)
            {
                case Logging.Severity.Error:
                    _vaProxy.WriteToLog("EliteVA - " + e.Message, "red");
                    break;

                case Logging.Severity.Warning:
                    _vaProxy.WriteToLog("EliteVA - " + e.Message, "orange");
                    break;

                case Logging.Severity.Success:
                    _vaProxy.WriteToLog("EliteVA - " + e.Message, "green");
                    break;

                case Logging.Severity.Info:
                    _vaProxy.WriteToLog("EliteVA - " + e.Message, "blue");
                    break;
            }
        }

        private static void EliteAPI_AllEvent(object sender, dynamic e)
        {
            string eventName = "";

            try
            {
                eventName = "((EliteAPI." + e.@event + "))";

                if (eventName.Contains("Status"))
                {

                    try
                    {
                        var status = api.Status;
                        var commander = api.Commander;
                        var location = api.Location;

                        _vaProxy.SetBoolean("EliteAPI.DOCKED", status.Docked);
                        _vaProxy.SetBoolean("EliteAPI.LANDED", status.Landed);
                        _vaProxy.SetBoolean("EliteAPI.GEAR", status.Gear);
                        _vaProxy.SetBoolean("EliteAPI.SHIELDS", status.Shields);
                        _vaProxy.SetBoolean("EliteAPI.SUPERCRUISE", status.Supercruise);
                        _vaProxy.SetBoolean("EliteAPI.FLIGHTASSIST", status.FlightAssist);
                        _vaProxy.SetBoolean("EliteAPI.HARDPOINTS", status.Hardpoints);
                        _vaProxy.SetBoolean("EliteAPI.WINGING", status.Winging);
                        _vaProxy.SetBoolean("EliteAPI.LIGHTS", status.Lights);
                        _vaProxy.SetBoolean("EliteAPI.CARGOSCOOP", status.CargoScoop);
                        _vaProxy.SetBoolean("EliteAPI.SILENTRUNNING", status.SilentRunning);
                        _vaProxy.SetBoolean("EliteAPI.SCOOPING", status.Scooping);
                        _vaProxy.SetBoolean("EliteAPI.SRVHANDBREAK", status.SrvHandbreak);
                        _vaProxy.SetBoolean("EliteAPI.SRVTURRENT", status.SrvTurrent);
                        _vaProxy.SetBoolean("EliteAPI.SRVNEARSHIP", status.SrvNearShip);
                        _vaProxy.SetBoolean("EliteAPI.SRVDRIVEASSIST", status.SrvDriveAssist);
                        _vaProxy.SetBoolean("EliteAPI.MASSLOCKED", status.MassLocked);
                        _vaProxy.SetBoolean("EliteAPI.FSDCHARGING", status.FsdCharging);
                        _vaProxy.SetBoolean("EliteAPI.FSDCOOLDOWN", status.FsdCooldown);
                        _vaProxy.SetBoolean("EliteAPI.LOWFUEL", status.LowFuel);
                        _vaProxy.SetBoolean("EliteAPI.OVERHEATING", status.Overheating);
                        _vaProxy.SetBoolean("EliteAPI.HASLATLONG", status.HasLatlong);
                        _vaProxy.SetBoolean("EliteAPI.INDANGER", status.InDanger);
                        _vaProxy.SetBoolean("EliteAPI.ININTERDICTION", status.InInterdiction);
                        _vaProxy.SetBoolean("EliteAPI.INMOTHERSHIP", status.InMothership);
                        _vaProxy.SetBoolean("EliteAPI.INNOFIREZONE", status.InNoFireZone);
                        _vaProxy.SetBoolean("EliteAPI.INFIGHTER", status.InFighter);
                        _vaProxy.SetBoolean("EliteAPI.INSRV", status.InSRV);
                        _vaProxy.SetBoolean("EliteAPI.ANALYSISMODE", status.AnalysisMode);
                        _vaProxy.SetBoolean("EliteAPI.NIGHTVISION", status.NightVision);
                        _vaProxy.SetInt("EliteAPI.Pips.SYSTEMS", (int)status.Pips[0]);
                        _vaProxy.SetInt("EliteAPI.Pips.ENGINES", (int)status.Pips[1]);
                        _vaProxy.SetInt("EliteAPI.Pips.WEAPONS", (int)status.Pips[2]);
                        _vaProxy.SetInt("EliteAPI.FIREGROUP", (int)status.FireGroup);
                        _vaProxy.SetInt("EliteAPI.GUIFOCUS", (int)status.GuiFocus);
                        _vaProxy.SetDecimal("EliteAPI.FUEL", (decimal)status.Fuel.FuelMain);
                        _vaProxy.SetDecimal("EliteAPI.FUELRESERVOIR", (decimal)status.Fuel.FuelReservoir);
                        _vaProxy.SetInt("EliteAPI.CARGO", (int)status.Cargo);

                        _vaProxy.SetText("EliteAPI.Commander", commander.Commander);
                        _vaProxy.SetText("EliteAPI.System", location.StarSystem);
                        _vaProxy.SetText("EliteAPI.Body", location.Body);
                        _vaProxy.SetText("EliteAPI.BodyType", location.BodyType);

                        _vaProxy.SetInt("EliteAPI.Rank.Combat", (int)commander.CombatRank);
                        _vaProxy.SetInt("EliteAPI.Rank.Cqc", (int)commander.CqcRank);
                        _vaProxy.SetInt("EliteAPI.Rank.Trade", (int)commander.TradeRank);
                        _vaProxy.SetInt("EliteAPI.Rank.Exploration", (int)commander.ExplorationRank);

                        _vaProxy.SetText("EliteAPI.Rank.Combat", commander.CombatRankLocalised);
                        _vaProxy.SetText("EliteAPI.Rank.Trade", commander.TradeRankLocalised);
                        _vaProxy.SetText("EliteAPI.Rank.Exploration", commander.ExplorationRankLocalised);
                    }
                    catch (Exception ex)
                    {
                        api.Logger.LogError($"There was an error while setting some of the status variables. (Make sure the game is running.)", ex);
                    }
                }

                if (_vaProxy.CommandExists(eventName))
                {
                    JObject attributesAsJObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(e));
                    Dictionary<string, object> values = attributesAsJObject.ToObject<Dictionary<string, object>>();

                    foreach (var key in values)
                    {
                        string type = key.Value.GetType().ToString().Replace("System.", "").Replace("Collections.Generic.", "").ToLower();
                        string name = key.Key;
                        string value = key.Value.ToString();

                        try
                        {
                            if (type.Contains("int")) { _vaProxy.SetInt("EliteAPI.Event." + name, int.Parse(value)); }
                            else if (type.Contains("long")) { _vaProxy.SetInt("EliteAPI.Event." + name, int.Parse(value)); }
                            else if (type.Contains("string")) { _vaProxy.SetText("EliteAPI.Event." + name, value); }
                            else if (type.Contains("decimal")) { _vaProxy.SetDecimal("EliteAPI.Event." + name, decimal.Parse(value)); }
                            else if (type.Contains("double")) { _vaProxy.SetDecimal("EliteAPI.Event." + name, decimal.Parse(value)); }
                            else if (type.Contains("float")) { _vaProxy.SetDecimal("EliteAPI.Event." + name, decimal.Parse(value)); }
                            else if (type.Contains("bool")) { _vaProxy.SetBoolean("EliteAPI.Event." + name, bool.Parse(value)); }
                        }
                        catch (Exception ex)
                        {
                            api.Logger.LogError($"There was an error while trying to parse field ['{name}' ({value})] for '{eventName}'.", ex);
                        }
                    }
                    _vaProxy.ExecuteCommand(eventName);
                }
            }
            catch (Exception ex)
            {
                api.Logger.LogError($"There was an error while invoking the event '{eventName}'.", ex);
            }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            _vaProxy = vaProxy;
            api.Logger.LogSuccess("Stopping EliteVA.");
            api.Stop();
        }

        public static void VA_StopCommand()
        {

        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            _vaProxy = vaProxy;

            try
            {
                string command = vaProxy.Context.ToString().ToLower();

                if (command == "updatejournal")
                {
                    SetJournalFolder();
                    api = new EliteDangerousAPI(playerJournalDirectory);
                    return;
                }
                else if (command == "drp on")
                {
                    api.DiscordRichPresence.TurnOn();
                    return;
                }
                else if (command == "drp off")
                {
                    api.DiscordRichPresence.TurnOff();
                    return;
                }
            }
            catch { }
        }
    }
}