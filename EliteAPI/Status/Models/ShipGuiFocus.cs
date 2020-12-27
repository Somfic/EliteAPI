namespace EliteAPI.Status.Models
{
    /// <summary>
    ///     Ship GUI focus
    /// </summary>
    public enum ShipGuiFocus
    {
        /// <summary>
        ///     There is no focus
        /// </summary>
        NoFocus,

        /// <summary>
        ///     The internal (right) panel
        /// </summary>
        InternalPanel,

        /// <summary>
        ///     The external (left) panel
        /// </summary>
        ExternalPanel,

        /// <summary>
        ///     The communication panel
        /// </summary>
        CommsPanel,

        /// <summary>
        ///     The role panel
        /// </summary>
        RolePanel,

        /// <summary>
        ///     Station services
        /// </summary>
        StationServices,

        /// <summary>
        ///     The galaxy map
        /// </summary>
        GalaxyMap,

        /// <summary>
        ///     The system map
        /// </summary>
        SystemMap,

        /// <summary>
        ///     The orrery
        /// </summary>
        Orrery,

        /// <summary>
        ///     Full spectrum scanner mode
        /// </summary>
        FssMode,

        /// <summary>
        ///     Saa mode
        /// </summary>
        SaaMode,

        /// <summary>
        ///     The codex
        /// </summary>
        Codex
    }
}