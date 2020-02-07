namespace EliteAPI.Events.Startup {
    /// <summary>
    /// Contains information about the fuel of the ship.
    /// </summary>
    /// <see cref="LoadoutInfo"/>
    public class LoadoutFuelInfo
    {
        internal LoadoutFuelInfo() { }

        /// <summary>
        /// The amount of fuel in the main tank.
        /// </summary>
        public float Main { get; internal set; }

        /// <summary>
        /// The amount of fuel in the reserve tank.
        /// </summary>
        public float Reserve { get; internal set; }
    }
}