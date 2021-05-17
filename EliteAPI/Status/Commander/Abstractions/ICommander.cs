using EliteAPI.Status.Abstractions;
using EliteAPI.Status.Ship;

namespace EliteAPI.Status.Commander.Abstractions
{
    public interface ICommander : IStatus
    {
        /// <summary>
        /// Overview of all ship flags
        /// </summary>
        StatusProperty<CommanderFlags> Flags { get; }
        
        /// <summary>
        /// Whether the commander is on foot
        /// </summary>
        StatusProperty<bool> OnFoot { get; }
        
        /// <summary>
        /// Whether the commander is in a taxi
        /// </summary>
        StatusProperty<bool> InTaxi { get; }
        
        /// <summary>
        /// Whether the commander is multicrewing
        /// </summary>
        StatusProperty<bool> InMultiCrew { get; }
        
        /// <summary>
        /// Whether the commander is on foot in a station
        /// </summary>
        StatusProperty<bool> OnFootInStation { get; }
        
        /// <summary>
        /// Whether the commander is on foot on a planet
        /// </summary>
        StatusProperty<bool> OnFootOnPlanet { get; }
        
        /// <summary>
        /// Whether the commander is aiming down the sight of their weapon
        /// </summary>
        StatusProperty<bool> AimDownSight { get; }
        
        /// <summary>
        /// Whether the commander is low on oxygen
        /// </summary>
        StatusProperty<bool> LowOxygen { get; }
        
        /// <summary>
        /// Whether the commander is low on health
        /// </summary>
        StatusProperty<bool> LowHealth { get; }
        
        /// <summary>
        /// Whether the commander is cold
        /// </summary>
        StatusProperty<bool> Cold { get; }
        
        /// <summary>
        /// Whether the commander is hot
        /// </summary>
        StatusProperty<bool> Hot { get; }
        
        /// <summary>
        /// Whether the commander is very cold 
        /// </summary>
        StatusProperty<bool> VeryCold { get; }
        
        /// <summary>
        /// Whether the commander is very hot
        /// </summary>
        StatusProperty<bool> VeryHot { get; }
        
        /// <summary>
        /// The percentage of oxygen available
        /// </summary>
        StatusProperty<float> Oxygen { get; }
        
        /// <summary>
        /// The percentage of health
        /// </summary>
        StatusProperty<float> Health { get; }
        
        /// <summary>
        /// The temperature in Kelvin
        /// </summary>
        StatusProperty<float> Temperature { get; }
        
        /// <summary>
        /// The selected weapon
        /// </summary>
        StatusProperty<string> SelectedWeapon { get; }
        
        /// <summary>
        /// The gravity relative to Earth's
        /// </summary>
        StatusProperty<float> Gravity { get; }
    }
}