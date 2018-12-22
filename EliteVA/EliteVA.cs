using System;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace EliteVA
{
    namespace EliteVA
    {
        public class VAPlugin
        {
            private static void FindJournalFolder(dynamic vaProxy)
            {
                string journalPath = "";
        
                if (!File.Exists("EliteVA.ini"))
                {
                    vaProxy.WriteToLog("EliteVA - Could not find EliteVA.ini, trying default Journal folder", "orange");
                }   
                else
                {
                    try
                    {
                        journalPath = File.ReadAllLines("EliteVA.ini")[0].Split(new string[] { "path=" }, StringSplitOptions.None)[1];
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

                tryagain:

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
                statusFile = new FileInfo(playerJournalDirectory.FullName + "//Status.json");

                if (!File.Exists(statusFile.FullName))
                {
                    vaProxy.WriteToLog($"EliteVA - Could not find Status.json file at {statusFile.FullName}", "red");

                    if (journalPath != "")
                    {
                        journalPath = "";
                        goto tryagain;
                    } else
                    {
                        vaProxy.WriteToLog($"EliteVA - Could not start EliteVA (cannot find Player Journals)", "red");
                    }
                } else
                {
                    vaProxy.WriteToLog($"EliteVA - Status.json file found", "green");
                }
            }

            public static DirectoryInfo playerJournalDirectory = new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");
            public static FileInfo statusFile = new FileInfo(playerJournalDirectory.FullName + "//Status.json");

            public static Status Status;

            public static string VA_DisplayName() { return "EliteAPI"; }

            public static string VA_DisplayInfo() { return "EliteAPI by Somfic"; }

            public static Guid VA_Id() { return new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}"); }

            public static void VA_Init1(dynamic vaProxy)
            {
                FindJournalFolder(vaProxy);
                Status = JsonConvert.DeserializeObject<Status>(File.ReadAllText(playerJournalDirectory.GetFiles().Where(x => x.Name == "Status.json").First().FullName));
            }

            public static void VA_Exit1(dynamic vaProxy)
            {
            }

            public static void VA_StopCommand()
            {

            }

            public static void VA_Invoke1(dynamic vaProxy)
            {
                try { if (vaProxy.Context.ToString().ToLower() == "updatejournal") { FindJournalFolder(vaProxy); return; } } catch { }

                //Update values
                try { Status = JsonConvert.DeserializeObject<Status>(File.ReadAllText(statusFile.FullName)); }
                catch(Exception ex) { vaProxy.WriteToLog(ex.Message, "red"); return; }

                vaProxy.SetBoolean("EliteAPI.DOCKED", Status.Docked);
                vaProxy.SetBoolean("EliteAPI.LANDED", Status.Landed);
                vaProxy.SetBoolean("EliteAPI.GEAR", Status.Gear);
                vaProxy.SetBoolean("EliteAPI.SHIELDS", Status.Shields);
                vaProxy.SetBoolean("EliteAPI.SUPERCRUISE", Status.Supercruise);
                vaProxy.SetBoolean("EliteAPI.FLIGHTASSIST", Status.FlightAssist);
                vaProxy.SetBoolean("EliteAPI.HARDPOINTS", Status.Hardpoints);
                vaProxy.SetBoolean("EliteAPI.WINGING", Status.Winging);
                vaProxy.SetBoolean("EliteAPI.LIGHTS", Status.Lights);
                vaProxy.SetBoolean("EliteAPI.CARGOSCOOP", Status.CargoScoop);
                vaProxy.SetBoolean("EliteAPI.SILENTRUNNING", Status.SilentRunning);
                vaProxy.SetBoolean("EliteAPI.SCOOPING", Status.Scooping);
                vaProxy.SetBoolean("EliteAPI.SRVHANDBREAK", Status.SrvHandbreak);
                vaProxy.SetBoolean("EliteAPI.SRVTURRENT", Status.SrvTurrent);
                vaProxy.SetBoolean("EliteAPI.SRVNEARSHIP", Status.SrvNearShip);
                vaProxy.SetBoolean("EliteAPI.SRVDRIVEASSIST", Status.SrvDriveAssist);
                vaProxy.SetBoolean("EliteAPI.MASSLOCKED", Status.MassLocked);
                vaProxy.SetBoolean("EliteAPI.FSDCHARGING", Status.FsdCooldown);
                vaProxy.SetBoolean("EliteAPI.FSDCOOLDOWN", Status.FsdCooldown);
                vaProxy.SetBoolean("EliteAPI.LOWFUEL", Status.LowFuel);
                vaProxy.SetBoolean("EliteAPI.OVERHEATING", Status.Overheating);
                vaProxy.SetBoolean("EliteAPI.HASLATLONG", Status.HasLatLong);
                vaProxy.SetBoolean("EliteAPI.INDANGER", Status.InDanger);
                vaProxy.SetBoolean("EliteAPI.ININTERDICTION", Status.InInterdiction);
                vaProxy.SetBoolean("EliteAPI.INMOTHERSHIP", Status.InMothership);
                vaProxy.SetBoolean("EliteAPI.INFIGHTER", Status.InFighter);
                vaProxy.SetBoolean("EliteAPI.INSRV", Status.InSRV);
                vaProxy.SetBoolean("EliteAPI.ANALYSISMODE", Status.AnalysisMode);
                vaProxy.SetBoolean("EliteAPI.NIGHTVISION", Status.NightVision);

                try
                {
                    vaProxy.SetInt("EliteAPI.Pips.SYSTEMS", Status.Pips[0]);
                    vaProxy.SetInt("EliteAPI.Pips.ENGINES", Status.Pips[1]);
                    vaProxy.SetInt("EliteAPI.Pips.WEAPONS", Status.Pips[2]);
                    vaProxy.SetInt("EliteAPI.FIREGROUP", Status.FireGroup);
                    vaProxy.SetInt("EliteAPI.GUIFOCUS", Status.GuiFocus);
                    vaProxy.SetDecimal("EliteAPI.FUEL", (decimal)Status.Fuel);
                    vaProxy.SetDecimal("EliteAPI.CARGO", (decimal)Status.Cargo);
                }
                catch { vaProxy.WriteToLog("EliteVA - There was an error while setting some of the fields, make sure ED is running", "red"); }
            }
        }
    }       
}