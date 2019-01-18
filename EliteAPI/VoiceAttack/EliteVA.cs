using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteAPI.VoiceAttack
{
    namespace EliteVA
    {
        public class VAPlugin
        {
            private static DirectoryInfo playerJournalDirectory;
            private static EliteDangerousAPI EliteAPI;
            private static dynamic _vaProxy;

            private static void FindJournalFolder(dynamic vaProxy)
            {
                string journalPath = "";

                if (!File.Exists("EliteVA.ini"))
                {
                    vaProxy.WriteToLog("EliteVA - Could not find EliteVA.ini, trying default Journal folder", "orange");
                    File.WriteAllText("EliteVA.ini", "//Example" + Environment.NewLine);
                    File.AppendAllText("EliteVA.ini", @"//path=D:\Saved Games\Frontier Developments");
                }
                else
                {
                    try
                    {
                        journalPath = File.ReadAllLines("EliteVA.ini").Where(x => !x.StartsWith("/")).First().Split(new string[] { "path=" }, StringSplitOptions.None)[1];

                        if (Directory.Exists(journalPath))
                        {
                            vaProxy.WriteToLog($@"EliteVA - Found custom Player Journal folder: '{journalPath}'", "blue");
                        }
                        else
                        {
                            vaProxy.WriteToLog($@"EliteVA - Found custom Player Journal folder: '{journalPath}', but that folder doesn't exist", "red");
                            journalPath = "";
                        }
                    }
                    catch { journalPath = ""; }
                }

                if (string.IsNullOrWhiteSpace(journalPath))
                {
                    if (!Directory.Exists($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"))
                    {
                        vaProxy.WriteToLog("EliteVA - Could not find Player Journal folder at default location, please set the location in EliteVA.ini", "red");
                    }
                    else
                    {
                        journalPath = $@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous";
                        vaProxy.WriteToLog($@"EliteVA - Set Player Journal folder to default 'C:\Users\{ Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous'", "blue");
                    }
                }

                playerJournalDirectory = new DirectoryInfo(journalPath);
                FileInfo statusFile = new FileInfo(playerJournalDirectory.FullName + "//Status.json");

                if (!File.Exists(statusFile.FullName))
                {
                    vaProxy.WriteToLog($"EliteVA - Could not find Status.json file at {statusFile.FullName}", "red");

                    if (journalPath != "")
                    {
                        journalPath = "";
                    }
                    else
                    {
                        vaProxy.WriteToLog($"EliteVA - Could not start EliteVA (cannot find Player Journals).", "red");
                        Environment.Exit(1);
                    }
                }
                else
                {
                    vaProxy.WriteToLog($"EliteVA - Files found.", "green");
                }
            }

            public static string VA_DisplayName() { return "EliteVA"; }

            public static string VA_DisplayInfo() { return "EliteVA by Somfic"; }

            public static Guid VA_Id() { return new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}"); }

            public static void VA_Init1(dynamic vaProxy)
            {
                _vaProxy = vaProxy;

                FindJournalFolder(vaProxy);
                EliteAPI = new EliteDangerousAPI(playerJournalDirectory, true);
                EliteAPI.Events.AllEvent += EliteAPI_AllEvent;
                EliteAPI.Start();
                EliteAPI.Logger.Log += Logger_Log;
            }

            private static void Logger_Log(object sender, Logging.LogMessage e)
            {
                switch(e.Severity)
                {
                    case Logging.Severity.Error:
                        _vaProxy.WriteToLog("EliteVA - " + e.Message, "red");
                        break;

                    case Logging.Severity.Warning:
                        _vaProxy.WriteToLog("EliteVA - " + e.Message, "yellow");
                        break;
                }
            }

            private static void EliteAPI_AllEvent(object sender, dynamic e)
            {
                try
                {
                    string eventName = "((EliteAPI." + e.@event + "))";     

                    if (_vaProxy.CommandExists(eventName))
                    {
                        JObject attributesAsJObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(e));
                        Dictionary<string, object> values = attributesAsJObject.ToObject<Dictionary<string, object>>();

                        foreach (var key in values)
                        {
                            string type = key.Value.GetType().ToString().Replace("System.", "").Replace("Collections.Generic.", "").ToLower();
                            string name = key.Key;
                            string value = key.Value.ToString();

                            if (type.Contains("int")) { _vaProxy.SetInt("EliteAPI.Event." + name, int.Parse(value)); }
                            else if (type.Contains("long")) { _vaProxy.SetInt("EliteAPI.Event." + name, int.Parse(value)); }
                            else if (type.Contains("string")) { _vaProxy.SetText("EliteAPI.Event." + name, value); }
                            else if (type.Contains("decimal")) { _vaProxy.SetDecimal("EliteAPI.Event." + name, decimal.Parse(value)); }
                            else if (type.Contains("double")) { _vaProxy.SetDecimal("EliteAPI.Event." + name, decimal.Parse(value)); }
                            else if (type.Contains("float")) { _vaProxy.SetDecimal("EliteAPI.Event." + name, decimal.Parse(value)); }
                        }
                        _vaProxy.ExecuteCommand(eventName);
                    }
                    else { }
                }
                catch (Exception ex)
                {
                    EliteAPI.Logger.LogError("There was an error while setting some of the event variables:");
                    EliteAPI.Logger.LogWarning(ex.Message);
                }
            }

            public static void VA_Exit1(dynamic vaProxy)
            {
                _vaProxy = vaProxy;
                EliteAPI.Stop();
            }

            public static void VA_StopCommand()
            {

            }

            public static void VA_Invoke1(dynamic vaProxy)
            {
                _vaProxy = vaProxy;

                string command = vaProxy.Context.ToString().ToLower();

                if (command == "updatejournal")
                {
                    FindJournalFolder(vaProxy);
                    EliteAPI = new EliteDangerousAPI(playerJournalDirectory);
                } else if (command == "drp on")
                {
                    EliteAPI.DiscordRichPresence.TurnOn();
                }
                else if (command == "drp off")
                {
                    EliteAPI.DiscordRichPresence.TurnOn();
                }

                try
                {
                    var status = EliteAPI.Status;

                    vaProxy.SetBoolean("EliteAPI.DOCKED", status.Docked);
                    vaProxy.SetBoolean("EliteAPI.LANDED", status.Landed);
                    vaProxy.SetBoolean("EliteAPI.GEAR", status.Gear);
                    vaProxy.SetBoolean("EliteAPI.SHIELDS", status.Shields);
                    vaProxy.SetBoolean("EliteAPI.SUPERCRUISE", status.Supercruise);
                    vaProxy.SetBoolean("EliteAPI.FLIGHTASSIST", status.FlightAssist);
                    vaProxy.SetBoolean("EliteAPI.HARDPOINTS", status.Hardpoints);
                    vaProxy.SetBoolean("EliteAPI.WINGING", status.Winging);
                    vaProxy.SetBoolean("EliteAPI.LIGHTS", status.Lights);
                    vaProxy.SetBoolean("EliteAPI.CARGOSCOOP", status.CargoScoop);
                    vaProxy.SetBoolean("EliteAPI.SILENTRUNNING", status.SilentRunning);
                    vaProxy.SetBoolean("EliteAPI.SCOOPING", status.Scooping);
                    vaProxy.SetBoolean("EliteAPI.SRVHANDBREAK", status.SrvHandbreak);
                    vaProxy.SetBoolean("EliteAPI.SRVTURRENT", status.SrvTurrent);
                    vaProxy.SetBoolean("EliteAPI.SRVNEARSHIP", status.SrvNearShip);
                    vaProxy.SetBoolean("EliteAPI.SRVDRIVEASSIST", status.SrvDriveAssist);
                    vaProxy.SetBoolean("EliteAPI.MASSLOCKED", status.MassLocked);
                    vaProxy.SetBoolean("EliteAPI.FSDCHARGING", status.FsdCooldown);
                    vaProxy.SetBoolean("EliteAPI.FSDCOOLDOWN", status.FsdCooldown);
                    vaProxy.SetBoolean("EliteAPI.LOWFUEL", status.LowFuel);
                    vaProxy.SetBoolean("EliteAPI.OVERHEATING", status.Overheating);
                    vaProxy.SetBoolean("EliteAPI.HASLATLONG", status.HasLatlong);
                    vaProxy.SetBoolean("EliteAPI.INDANGER", status.InDanger);
                    vaProxy.SetBoolean("EliteAPI.ININTERDICTION", status.InInterdiction);
                    vaProxy.SetBoolean("EliteAPI.INMOTHERSHIP", status.InMothership);
                    vaProxy.SetBoolean("EliteAPI.INFIGHTER", status.InFighter);
                    vaProxy.SetBoolean("EliteAPI.INSRV", status.InSRV);
                    vaProxy.SetBoolean("EliteAPI.ANALYSISMODE", status.AnalysisMode);
                    vaProxy.SetBoolean("EliteAPI.NIGHTVISION", status.NightVision);
                    vaProxy.SetInt("EliteAPI.Pips.SYSTEMS", (int)status.Pips[0]);
                    vaProxy.SetInt("EliteAPI.Pips.ENGINES", (int)status.Pips[1]);
                    vaProxy.SetInt("EliteAPI.Pips.WEAPONS", (int)status.Pips[2]);
                    vaProxy.SetInt("EliteAPI.FIREGROUP", (int)status.FireGroup);
                    vaProxy.SetInt("EliteAPI.GUIFOCUS", (int)status.GuiFocus);
                    vaProxy.SetDecimal("EliteAPI.FUEL", (decimal)status.Fuel.FuelMain);
                    vaProxy.SetDecimal("EliteAPI.FUELRESERVOIR", (decimal)status.Fuel.FuelReservoir);
                    vaProxy.SetInt("EliteAPI.CARGO", (int)status.Cargo);
                }
                catch (Exception ex) {
                    EliteAPI.Logger.LogError("There was an error while setting some of the VoiceAttack variables:");
                    EliteAPI.Logger.LogWarning(ex.Message);
                }
            }
        }
    }
}