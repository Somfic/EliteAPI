using EliteAPI.Status.Cargo;
using EliteAPI.Status.Market;
using EliteAPI.Status.Modules;
using EliteAPI.Status.Outfitting;
using EliteAPI.Status.Shipyard;
using EliteAPI.Utilities;

namespace EliteAPI.Service.StatusExtension
{
    internal class StatusExtensionService : IService
    {
        internal StatusExtensionService(EliteDangerousAPI api)
        {
            // MusicTrack & InMainMenu logic.
            api.Events.MusicEvent += (sender, info) =>
            {
                api.Status.MusicTrack = info.MusicTrack;
                if(info.MusicTrack == "MainMenu") { api.Status.InMainMenu = true; }
            };

            // GameMode logic.
            api.Events.LoadGameEvent += (sender, info) => { api.Status.GameMode = info.GameMode; };

            // JumpRange logic
            api.Events.LoadoutEvent += (sender, info) => { api.Status.JumpRange = info.MaxJumpRange; };

            // InNoFireZone logic.
            api.Events.StartJumpEvent += (sender, info) => { api.Status.InNoFireZone = false; };
            api.Events.SupercruiseEntryEvent += (sender, info) => { api.Status.InNoFireZone = false; };
            api.Events.ReceiveTextEvent += (sender, info) =>
            {
                if (info.Message.Contains("NoFireZone_entered"))
                {
                    api.Status.InNoFireZone = true;
                }
                else if (info.Message.Contains("NoFireZone_exited"))
                {
                    api.Status.InNoFireZone = false;
                }
            };

            // Other status files.
        //    api.Events.CargoEvent += (sender, info) => { api.Cargo = StatusReader.Read(api.Config.JournalDirectory, "Cargo.json", new CargoStatus()); };
        //    api.Events.MarketEvent += (sender, info) => { api.Market = StatusReader.Read(api.Config.JournalDirectory, "Market.json", new MarketStatus()); };
        //    api.Events.ModuleInfoEvent += (sender, info) => { api.Modules = StatusReader.Read(api.Config.JournalDirectory, "ModulesInfo.json", new ModulesStatus()); };
        //    api.Events.OutfittingEvent += (sender, info) => { api.Outfitting = StatusReader.Read(api.Config.JournalDirectory, "Outfitting.json", new OutfittingStatus()); };
        //    api.Events.ShipyardEvent += (sender, info) => { api.Shipyard = StatusReader.Read(api.Config.JournalDirectory, "Shipyard.json", new ShipyardStatus()); };
        }
    }
}
