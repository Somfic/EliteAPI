namespace EliteAPI.Event.Models.Startup {
    /// <summary>
    /// Contains information about the fuel of the ship.
    /// </summary>
    /// <see cref="LoadoutInfo"/>
    public class LoadoutFuel
    {
        internal LoadoutFuel() { }

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