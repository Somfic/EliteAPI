using System;
using System.IO;
using System.Threading.Tasks;
using EliteAPI.Status.Backpack.Raw;
using EliteAPI.Status.Cargo.Raw;
using EliteAPI.Status.Market.Raw;
using EliteAPI.Status.Modules.Raw;
using EliteAPI.Status.NavRoute.Raw;
using EliteAPI.Status.Outfitting.Raw;
using EliteAPI.Status.Raw;

namespace EliteAPI.Status.Processor.Abstractions
{
    /// <summary>
    /// Processes status files
    /// </summary>
    public interface IStatusProcessor
    {
        /// <summary>
        /// Triggered when the status file is updated
        /// </summary>
        [Obsolete("Use ShipUpdated instead", true)]
        event EventHandler<(string Json, RawStatus Ship)> StatusUpdated;

        /// <summary>
        /// Triggered when the status file is updated
        /// </summary>
        event EventHandler<(string Json, RawStatus Ship)> ShipUpdated;
        
        /// <summary>
        /// Triggered when the cargo file is updated
        /// </summary>
        event EventHandler<(string Json, RawCargo Cargo)> CargoUpdated;

        /// <summary>
        /// Triggered when the market file is updated
        /// </summary>
        event EventHandler<(string Json, RawMarket Market)> MarketUpdated;

        /// <summary>
        /// Triggered when the shipyard file is updated
        /// </summary>
        event EventHandler<(string Json, RawShipyard Shipyard)> ShipyardUpdated;

        /// <summary>
        /// Triggered when the modules file is updated
        /// </summary>
        event EventHandler<(string Json, RawModules Modules)> ModulesUpdated;

        /// <summary>
        /// Triggered when the outfitting file is updated
        /// </summary>
        event EventHandler<(string Json, RawOutfitting Outfitting)> OutfittingUpdated;

        /// <summary>
        /// Triggered when the navroute file is updated
        /// </summary>
        event EventHandler<(string Json, RawNavRoute NavRoute)> NavRouteUpdated;
        
        /// <summary>
        /// Triggered when the navroute file is updated
        /// </summary>
        event EventHandler<(string Json, RawBackpack Backpack)> BackpackUpdated;


        /// <summary>
        /// Hooks the specified status file to <see cref="StatusUpdated" /> and invokes <see cref="StatusUpdated" /> when
        /// needed
        /// </summary>
        Task ProcessStatusFile(FileInfo statusFile);

        /// <summary>
        /// Hooks the specified cargo file to <see cref="CargoUpdated" /> and invokes <see cref="CargoUpdated" /> when needed
        /// </summary>
        Task ProcessCargoFile(FileInfo cargoFile);

        /// <summary>
        /// Hooks the specified market file to <see cref="MarketUpdated" /> and invokes <see cref="MarketUpdated" /> when
        /// needed
        /// </summary>
        Task ProcessMarketFile(FileInfo marketFile);

        /// <summary>
        /// Hooks the specified shipyard file to <see cref="ShipyardUpdated" /> and invokes <see cref="ShipyardUpdated" /> when
        /// needed
        /// </summary>
        Task ProcessShipyardFile(FileInfo shipyardFile);

        /// <summary>
        /// Hooks the specified modules file to <see cref="ModulesUpdated" /> and invokes <see cref="ModulesUpdated" /> when
        /// needed
        /// </summary>
        Task ProcessModulesFile(FileInfo modulesFile);

        /// <summary>
        /// Hooks the specified outfitting file to <see cref="OutfittingUpdated" /> and invokes
        /// <see cref="OutfittingUpdated" /> when needed
        /// </summary>
        Task ProcessOutfittingFile(FileInfo outfittingFile);

        /// <summary>
        /// Hooks the specified navroute file to <see cref="NavRouteUpdated" /> and invokes <see cref="NavRouteUpdated" /> when
        /// needed
        /// </summary>
        Task ProcessNavRouteFile(FileInfo navRouteFile);

        /// <summary>
        /// Hooks the specified backpack file to <see cref="BackpackUpdated" /> and invokes
        /// <see cref="BackpackUpdated" /> when needed
        /// </summary>
        Task ProcessBackpackFile(FileInfo backpackFile);
    }
}