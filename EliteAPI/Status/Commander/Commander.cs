using System;
using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Commander.Abstractions;
using EliteAPI.Status.Ship;

namespace EliteAPI.Status.Commander
{
    public class Commander : StatusBase, ICommander
    {
        /// <inheritdoc />
        public StatusProperty<CommanderFlags> Flags { get; } = new (CommanderFlags.None);

        /// <inheritdoc />
        public StatusProperty<bool> OnFoot { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InTaxi { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> InMultiCrew { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> OnFootInStation { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> OnFootOnPlanet { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> AimDownSight { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> LowOxygen { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> LowHealth { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Cold { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> Hot { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> VeryCold { get; } = new();

        /// <inheritdoc />
        public StatusProperty<bool> VeryHot { get; } = new();

        /// <inheritdoc />
        public StatusProperty<float> Oxygen { get; } = new();
        
        /// <inheritdoc />
        public StatusProperty<float> Health { get; } = new();
        
        /// <inheritdoc />
        public StatusProperty<float> Temperature { get; } = new();
        
        /// <inheritdoc />
        public StatusProperty<string> SelectedWeapon { get; } = new();
        
        /// <inheritdoc />
        public StatusProperty<string> SelectedWeaponLocalised { get; } = new();
        
        /// <inheritdoc />
        public StatusProperty<float> Gravity { get; } = new();
    }
}