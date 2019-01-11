using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                            vaProxy.WriteToLog($@"EliteVA - Found custom Player Journal folder: '{journalPath}' but that folder doesn't exist", "red");
                            journalPath = "";
                        }
                    }
                    catch { vaProxy.WriteToLog("EliteVA - Could not load custom Player Journal folder from .ini file", "red"); journalPath = ""; }
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
                    }
                }
                else
                {
                    vaProxy.WriteToLog($"EliteVA - Status.json file found", "green");
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
                EliteAPI.EventHandler.AllEvent += EliteAPI_AllEvent;
                EliteAPI.Start();
            }

            private static void EliteAPI_AllEvent(object sender, dynamic e)
            {
                try
                {
                    string eventName = "((EliteAPI." + e.@event + "))";

                    if (_vaProxy.CommandExists(eventName))
                    {
                        JObject attributesAsJObject = e;
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
                catch (Exception ex) { _vaProxy.WriteToLog("error: " + ex.Message, "red  "); }
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

                if (vaProxy.Context.ToString().ToLower() == "updatejournal")
                {
                    FindJournalFolder(vaProxy);
                    EliteAPI = new EliteDangerousAPI(playerJournalDirectory);
                    return;
                }

                vaProxy.SetBoolean("EliteAPI.DOCKED", EliteAPI.Status.Docked);
                vaProxy.SetBoolean("EliteAPI.LANDED", EliteAPI.Status.Landed);
                vaProxy.SetBoolean("EliteAPI.GEAR", EliteAPI.Status.Gear);
                vaProxy.SetBoolean("EliteAPI.SHIELDS", EliteAPI.Status.Shields);
                vaProxy.SetBoolean("EliteAPI.SUPERCRUISE", EliteAPI.Status.Supercruise);
                vaProxy.SetBoolean("EliteAPI.FLIGHTASSIST", EliteAPI.Status.FlightAssist);
                vaProxy.SetBoolean("EliteAPI.HARDPOINTS", EliteAPI.Status.Hardpoints);
                vaProxy.SetBoolean("EliteAPI.WINGING", EliteAPI.Status.Winging);
                vaProxy.SetBoolean("EliteAPI.LIGHTS", EliteAPI.Status.Lights);
                vaProxy.SetBoolean("EliteAPI.CARGOSCOOP", EliteAPI.Status.CargoScoop);
                vaProxy.SetBoolean("EliteAPI.SILENTRUNNING", EliteAPI.Status.SilentRunning);
                vaProxy.SetBoolean("EliteAPI.SCOOPING", EliteAPI.Status.Scooping);
                vaProxy.SetBoolean("EliteAPI.SRVHANDBREAK", EliteAPI.Status.SrvHandbreak);
                vaProxy.SetBoolean("EliteAPI.SRVTURRENT", EliteAPI.Status.SrvTurrent);
                vaProxy.SetBoolean("EliteAPI.SRVNEARSHIP", EliteAPI.Status.SrvNearShip);
                vaProxy.SetBoolean("EliteAPI.SRVDRIVEASSIST", EliteAPI.Status.SrvDriveAssist);
                vaProxy.SetBoolean("EliteAPI.MASSLOCKED", EliteAPI.Status.MassLocked);
                vaProxy.SetBoolean("EliteAPI.FSDCHARGING", EliteAPI.Status.FsdCooldown);
                vaProxy.SetBoolean("EliteAPI.FSDCOOLDOWN", EliteAPI.Status.FsdCooldown);
                vaProxy.SetBoolean("EliteAPI.LOWFUEL", EliteAPI.Status.LowFuel);
                vaProxy.SetBoolean("EliteAPI.OVERHEATING", EliteAPI.Status.Overheating);
                vaProxy.SetBoolean("EliteAPI.HASLATLONG", EliteAPI.Status.HasLatLong);
                vaProxy.SetBoolean("EliteAPI.INDANGER", EliteAPI.Status.InDanger);
                vaProxy.SetBoolean("EliteAPI.ININTERDICTION", EliteAPI.Status.InInterdiction);
                vaProxy.SetBoolean("EliteAPI.INMOTHERSHIP", EliteAPI.Status.InMothership);
                vaProxy.SetBoolean("EliteAPI.INFIGHTER", EliteAPI.Status.InFighter);
                vaProxy.SetBoolean("EliteAPI.INSRV", EliteAPI.Status.InSRV);
                vaProxy.SetBoolean("EliteAPI.ANALYSISMODE", EliteAPI.Status.AnalysisMode);
                vaProxy.SetBoolean("EliteAPI.NIGHTVISION", EliteAPI.Status.NightVision);

                try
                {
                    vaProxy.SetInt("EliteAPI.Pips.SYSTEMS", (int)EliteAPI.Status.Pips[0]);
                    vaProxy.SetInt("EliteAPI.Pips.ENGINES", (int)EliteAPI.Status.Pips[1]);
                    vaProxy.SetInt("EliteAPI.Pips.WEAPONS", (int)EliteAPI.Status.Pips[2]);
                    vaProxy.SetInt("EliteAPI.FIREGROUP", (int)EliteAPI.Status.FireGroup);
                    vaProxy.SetInt("EliteAPI.GUIFOCUS", (int)EliteAPI.Status.GuiFocus);
                    vaProxy.SetDecimal("EliteAPI.FUEL", (decimal)EliteAPI.Status.Fuel);     
                    vaProxy.SetInt("EliteAPI.CARGO", (int)EliteAPI.Status.Cargo);
                }
                catch(Exception ex) { vaProxy.WriteToLog("EliteVA - There was an error while setting some of the fields, make sure ED is running"); vaProxy.WriteToLog(ex.Message, "red"); }
            }
        }
    }
}