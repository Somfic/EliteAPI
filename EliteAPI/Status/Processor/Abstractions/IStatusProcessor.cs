namespace EliteAPI.Status.Processor.Abstractions
{
    /// <summary>
    ///     Processes status files
    /// </summary>
    public interface IStatusProcessor
    {
        /// <summary>
        ///     Triggered when the status file is updated
        /// </summary>
        event EventHandler<string> StatusUpdated;

        /// <summary>
        ///     Triggered when the cargo file is updated
        /// </summary>
        event EventHandler<string> CargoUpdated;

        /// <summary>
        ///     Triggered when the market file is updated
        /// </summary>
        event EventHandler<string> MarketUpdated;

        /// <summary>
        ///     Triggered when the shipyard file is updated
        /// </summary>
        event EventHandler<string> ShipyardUpdated;

        /// <summary>
        ///     Triggered when the outfitting file is updated
        /// </summary>
        event EventHandler<string> OutfittingUpdated;

        /// <summary>
        ///     Hooks the specified status file to <see cref="StatusUpdated" /> and invokes <see cref="StatusUpdated" /> when
        ///     needed
        /// </summary>
        Task ProcessStatusFile(FileInfo statusFile);

        /// <summary>
        ///     Hooks the specified cargo file to <see cref="CargoUpdated" /> and invokes <see cref="CargoUpdated" /> when needed
        /// </summary>
        Task ProcessCargoFile(FileInfo cargoFile);

        /// <summary>
        ///     Hooks the specified market file to <see cref="MarketUpdated" /> and invokes <see cref="MarketUpdated" /> when
        ///     needed
        /// </summary>
        Task ProcessMarketFile(FileInfo marketFile);

        /// <summary>
        ///     Hooks the specified shipyard file to <see cref="ShipyardUpdated" /> and invokes <see cref="ShipyardUpdated" /> when
        ///     needed
        /// </summary>
        Task ProcessShipyardFile(FileInfo shipyardFile);

        /// <summary>
        ///     Hooks the specified outfitting file to <see cref="OutfittingUpdated" /> and invokes
        ///     <see cref="OutfittingUpdated" /> when needed
        /// </summary>
        Task ProcessOutfittingFile(FileInfo outfittingFile);
    }
}