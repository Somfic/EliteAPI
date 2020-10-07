namespace EliteAPI.Status.Models
{
    /// <summary>
    /// Legal ship states
    /// </summary>
    public enum ShipLegalState
    {
        /// <summary>
        /// Clean
        /// </summary>
        Clean,

        /// <summary>
        /// Illegal cargo on-board
        /// </summary>
        IllegalCargo,

        /// <summary>
        /// Speeding at stations
        /// </summary>
        Speeding,
        
        /// <summary>
        /// Wanted
        /// </summary>
        Wanted,

        /// <summary>
        /// Hostile
        /// </summary>
        Hostile,

        /// <summary>
        /// Passenger on ship is wanted
        /// </summary>
        PassengerWanted,

        /// <summary>
        /// Warrant for arrest
        /// </summary>
        Warrant
    }
}