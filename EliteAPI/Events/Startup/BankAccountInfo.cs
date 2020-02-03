using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Holds statistics on the commander's bank account.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class BankAccountInfo
    {
        internal BankAccountInfo() { }

        /// <summary>
        /// The total amount of wealth the commander has.
        /// </summary>
        [JsonProperty("Current_Wealth")]
        public long CurrentWealth { get; internal set; }

        /// <summary>
        /// The total amount of credits spent on ships.
        /// </summary>
        [JsonProperty("Spent_On_Ships")]
        public long SpentOnShips { get; internal set; }

        /// <summary>
        /// The total amount of credits spent on ships.
        /// </summary>
        [JsonProperty("Spent_On_Outfitting")]
        public long SpentOnOutfitting { get; internal set; }

        /// <summary>
        /// The total amount of credits spent on ship repairs.
        /// </summary>
        [JsonProperty("Spent_On_Repairs")]
        public long SpentOnRepairs { get; internal set; }

        /// <summary>
        /// The total amount of credits spent on refueling.
        /// </summary>
        [JsonProperty("Spent_On_Fuel")]
        public long SpentOnFuel { get; internal set; }       
        
        /// <summary>
        /// The total amount of credits spent on ammunition.
        /// </summary>
        [JsonProperty("Spent_On_Ammo_Consumables")]
        public long SpentOnAmmoConsumables { get; internal set; }

        /// <summary>
        /// The total amount of times insurance has been used.
        /// </summary>
        [JsonProperty("Insurance_Claims")]
        public int InsuranceClaims { get; internal set; }

        /// <summary>
        /// The total amount of credits spent on insurance.
        /// </summary>
        [JsonProperty("Spent_On_Insurance ")]
        public long SpentOnInsurance { get; internal set; }

        /// <summary>
        /// The total amount of ships the commander has owned.
        /// </summary>
        [JsonProperty("Owned_Ship_Count")]
        public int OwnedShipCount { get; internal set; }
    }
}