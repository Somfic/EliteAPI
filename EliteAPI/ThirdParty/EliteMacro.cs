using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteAPI.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vmAPI;

namespace EliteAPI.ThirdParty
{
    public class EliteMacro : vmInterface
    {
        private static DirectoryInfo playerJournalDirectory;
        private static EliteDangerousAPI api;

        private static void SetJournalFolder()
        {
            if (!File.Exists("EliteMacro.ini"))
            {
                File.WriteAllText("EliteMacro.ini", "//Example" + Environment.NewLine);
                File.AppendAllText("EliteMacro.ini", @"//path=D:\Saved Games\Frontier Developments");
                playerJournalDirectory = EliteDangerousAPI.StandardDirectory;
            }
            else
            {
                try
                {
                    playerJournalDirectory = new DirectoryInfo(File.ReadAllLines("EliteMacro" +
                        ".ini").Where(x => !x.StartsWith("/")).First().Split(new string[] { "path=" }, StringSplitOptions.None)[1]);
                }
                catch { playerJournalDirectory = EliteDangerousAPI.StandardDirectory; }
            }
        }

        public string DisplayName => "EliteMacro";

        public string Description => "The EliteAPI plugin for VoiceMacro.";

        public string ID => new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}").ToString();

        public void Init()
        {
            SetJournalFolder();

            api = new EliteDangerousAPI(playerJournalDirectory, true);
            api.Logger.Log += Logger_Log;
            api.Events.AllEvent += EliteAPI_AllEvent;
            api.Start();
        }

        private void Logger_Log(object sender, LogMessage e)
        {
            switch (e.Severity)
            {
                case Logging.Severity.Error:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Red, ID);
                    break;

                case Logging.Severity.Warning:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Orange, ID);
                    break;

                case Logging.Severity.Success:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Green, ID);
                    break;

                default:
                    vmCommand.AddLogEntry("EliteMacro - " + e.Message, Color.Blue, ID);
                    break;
            }
        }

        private void EliteAPI_AllEvent(object sender, dynamic e)
        {
            string eventName = "";

            try
            {
                eventName = "((EliteMarco." + e.@event + "))";

                if (vmCommand.CommandExists(eventName) == null)
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
                            if (type.Contains("int")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("long")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("string")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("decimal")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("double")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("float")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                            else if (type.Contains("bool")) { vmCommand.SetVariable("EliteAPI.Event." + name + "_p", value); }
                        }
                        catch (Exception ex)
                        {
                            api.Logger.LogError($"There was an error while trying to parse field ['{name}' ({value})] for '{eventName}'. ({ex.Message})");
                        }
                    }
                    vmCommand.ExecuteMacro(eventName);
                }
            }
            catch (Exception ex)
            {
                api.Logger.LogError($"There was an error while invoking the event '{eventName}'. ({ex.Message})");
            }
        }


        public void Dispose()
        {
            api.Logger.LogSuccess("Stopping EliteMacro.");
            api.Stop();
        }

        public void ProfileSwitched(string ProfileGUID, string ProfileName)
        {
            throw new NotImplementedException();
        }

        public void ReceiveParams(string Param1, string Param2, string Param3, bool Synchron)
        {
            try
            {
                string command = Param1.ToLower();

                if (command == "updatejournal")
                {
                    SetJournalFolder();
                    api = new EliteDangerousAPI(playerJournalDirectory);
                }
                else if (command == "drp on")
                {
                    api.DiscordRichPresence.TurnOn();
                }
                else if (command == "drp off")
                {
                    api.DiscordRichPresence.TurnOn();
                }
            }
            catch { }

            try
            {
                var status = api.Status;
                var commander = api.Commander;
                var location = api.Location;

                vmCommand.SetVariable("EliteAPI.DOCKED", status.Docked.ToString().ToString());
                vmCommand.SetVariable("EliteAPI.LANDED", status.Landed.ToString());
                vmCommand.SetVariable("EliteAPI.GEAR", status.Gear.ToString());
                vmCommand.SetVariable("EliteAPI.SHIELDS", status.Shields.ToString());
                vmCommand.SetVariable("EliteAPI.SUPERCRUISE", status.Supercruise.ToString());
                vmCommand.SetVariable("EliteAPI.FLIGHTASSIST", status.FlightAssist.ToString());
                vmCommand.SetVariable("EliteAPI.HARDPOINTS", status.Hardpoints.ToString());
                vmCommand.SetVariable("EliteAPI.WINGING", status.Winging.ToString());
                vmCommand.SetVariable("EliteAPI.LIGHTS", status.Lights.ToString());
                vmCommand.SetVariable("EliteAPI.CARGOSCOOP", status.CargoScoop.ToString());
                vmCommand.SetVariable("EliteAPI.SILENTRUNNING", status.SilentRunning.ToString());
                vmCommand.SetVariable("EliteAPI.SCOOPING", status.Scooping.ToString());
                vmCommand.SetVariable("EliteAPI.SRVHANDBREAK", status.SrvHandbreak.ToString());
                vmCommand.SetVariable("EliteAPI.SRVTURRENT", status.SrvTurrent.ToString());
                vmCommand.SetVariable("EliteAPI.SRVNEARSHIP", status.SrvNearShip.ToString());
                vmCommand.SetVariable("EliteAPI.SRVDRIVEASSIST", status.SrvDriveAssist.ToString());
                vmCommand.SetVariable("EliteAPI.MASSLOCKED", status.MassLocked.ToString());
                vmCommand.SetVariable("EliteAPI.FSDCHARGING", status.FsdCooldown.ToString());
                vmCommand.SetVariable("EliteAPI.FSDCOOLDOWN", status.FsdCooldown.ToString());
                vmCommand.SetVariable("EliteAPI.LOWFUEL", status.LowFuel.ToString());
                vmCommand.SetVariable("EliteAPI.OVERHEATING", status.Overheating.ToString());
                vmCommand.SetVariable("EliteAPI.HASLATLONG", status.HasLatlong.ToString());
                vmCommand.SetVariable("EliteAPI.INDANGER", status.InDanger.ToString());
                vmCommand.SetVariable("EliteAPI.ININTERDICTION", status.InInterdiction.ToString());
                vmCommand.SetVariable("EliteAPI.INMOTHERSHIP", status.InMothership.ToString());
                vmCommand.SetVariable("EliteAPI.INNOFIREZONE", status.InNoFireZone.ToString());
                vmCommand.SetVariable("EliteAPI.INFIGHTER", status.InFighter.ToString());
                vmCommand.SetVariable("EliteAPI.INSRV", status.InSRV.ToString());
                vmCommand.SetVariable("EliteAPI.ANALYSISMODE", status.AnalysisMode.ToString());
                vmCommand.SetVariable("EliteAPI.NIGHTVISION", status.NightVision.ToString());
                vmCommand.SetVariable("EliteAPI.Pips.SYSTEMS", status.Pips[0].ToString());
                vmCommand.SetVariable("EliteAPI.Pips.ENGINES", status.Pips[1].ToString());
                vmCommand.SetVariable("EliteAPI.Pips.WEAPONS", status.Pips[2].ToString());
                vmCommand.SetVariable("EliteAPI.FIREGROUP", status.FireGroup.ToString());
                vmCommand.SetVariable("EliteAPI.GUIFOCUS", status.GuiFocus.ToString());
                vmCommand.SetVariable("EliteAPI.FUEL", status.Fuel.FuelMain.ToString());
                vmCommand.SetVariable("EliteAPI.FUELRESERVOIR", status.Fuel.FuelReservoir.ToString());
                vmCommand.SetVariable("EliteAPI.CARGO", status.Cargo.ToString());

                vmCommand.SetVariable("EliteAPI.Commander", commander.Commander);
                vmCommand.SetVariable("EliteAPI.System", location.StarSystem);
                vmCommand.SetVariable("EliteAPI.Body", location.Body);
                vmCommand.SetVariable("EliteAPI.BodyType", location.BodyType);

                vmCommand.SetVariable("EliteAPI.Rank.Combat", commander.CombatRank.ToString());
                vmCommand.SetVariable("EliteAPI.Rank.Cqc", commander.CqcRank.ToString());
                vmCommand.SetVariable("EliteAPI.Rank.Trade", commander.TradeRank.ToString());
                vmCommand.SetVariable("EliteAPI.Rank.Exploration", commander.ExplorationRank.ToString());

                vmCommand.SetVariable("EliteAPI.Rank.Combat", commander.CombatRankLocalised);
                vmCommand.SetVariable("EliteAPI.Rank.Trade", commander.TradeRankLocalised);
                vmCommand.SetVariable("EliteAPI.Rank.Exploration", commander.ExplorationRankLocalised);
            }
            catch (Exception ex)
            {
                api.Logger.LogError($"There was an error while setting some of the status variables. ({ex.Message}) (Make sure the game is running.)");
            }
        }
    }
}
