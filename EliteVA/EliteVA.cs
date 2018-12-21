using System;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

namespace EliteVA
{
    public class VAPlugin
    {
        public static DirectoryInfo playerJournalDirectory = new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous");

        public static Status Status;

        public static string VA_DisplayName() { return "EliteAPI"; }

        public static string VA_DisplayInfo() { return "EliteAPI by Somfic"; }

        public static Guid VA_Id() { return new Guid("{B16F6232-5AD2-4451-BBED-C7696B41AB67}"); }

        public static void VA_Init1(dynamic vaProxy)
        {
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
            //Update values
            Status = JsonConvert.DeserializeObject<Status>(File.ReadAllText(playerJournalDirectory.GetFiles().Where(x => x.Name == "Status.json").First().FullName));

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

            vaProxy.SetInt("EliteAPI.Pips.SYSTEMS", Status.Pips[0]);
            vaProxy.SetInt("EliteAPI.Pips.ENGINES", Status.Pips[1]);    
            vaProxy.SetInt("EliteAPI.Pips.WEAPONS", Status.Pips[2]);
            vaProxy.SetInt("EliteAPI.FIREGROUP", Status.FireGroup);
            vaProxy.SetInt("EliteAPI.GUIFOCUS", Status.GuiFocus);
            vaProxy.SetDecimal("EliteAPI.FUEL", (decimal)Status.Fuel);
            vaProxy.SetDecimal("EliteAPI.CARGO", (decimal)Status.Cargo);
            vaProxy.SetBoolean("EliteAPI.SHIELDS", Status.Shields);
        }
    }
}
