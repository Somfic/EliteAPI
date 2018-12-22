using System;

namespace EliteAPI
{
    public class StatisticsInfo
    {
        public class BankAccountInfo
        {
            public int Current_Wealth { get; }
            public int Spent_On_Ships { get; }
            public long Spent_On_Outfitting { get; }
            public int Spent_On_Repairs { get; }
            public int Spent_On_Fuel { get; }
            public int Spent_On_Ammo_Consumables { get; }
            public int Insurance_Claims { get; }
            public int Spent_On_Insurance { get; }
        }

        public class CombatInfo
        {
            public int Bounties_Claimed { get; }
            public int Bounty_Hunting_Profit { get; }
            public int Combat_Bonds { get; }
            public int Combat_Bond_Profits { get; }
            public int Assassinations { get; }
            public int Assassination_Profits { get; }
            public int Highest_Single_Reward { get; }
            public int Skimmers_Killed { get; }
        }

        public class CrimeInfo
        {
            public int Notoriety { get; }
            public int Fines { get; }
            public int Total_Fines { get; }
            public int Bounties_Received { get; }
            public int Total_Bounties { get; }
            public int Highest_Bounty { get; }
        }

        public class SmugglingInfo
        {
            public int Black_Markets_Traded_With { get; }
            public int Black_Markets_Profits { get; }
            public int Resources_Smuggled { get; }
            public int Average_Profit { get; }
            public int Highest_Single_Transaction { get; }
        }

        public class TradingInfo
        {
            public int Markets_Traded_With { get; }
            public int Market_Profits { get; }
            public int Resources_Traded { get; }
            public double Average_Profit { get; }
            public int Highest_Single_Transaction { get; }
        }

        public class MiningInfo
        {
            public int Mining_Profits { get; }
            public int Quantity_Mined { get; }
            public int Materials_Collected { get; }
        }

        public class ExplorationInfo
        {
            public int Systems_Visited { get; }
            public int Exploration_Profits { get; }
            public int Planets_Scanned_To_Level_2 { get; }
            public int Planets_Scanned_To_Level_3 { get; }
            public int Highest_Payout { get; }
            public int Total_Hyperspace_Distance { get; }
            public int Total_Hyperspace_Jumps { get; }
            public double Greatest_Distance_From_Start { get; }
            public int Time_Played { get; }
        }

        public class PassengersInfo
        {
            public int Passengers_Missions_Accepted { get; }
            public int Passengers_Missions_Disgruntled { get; }
            public int Passengers_Missions_Bulk { get; }
            public int Passengers_Missions_VIP { get; }
            public int Passengers_Missions_Delivered { get; }
            public int Passengers_Missions_Ejected { get; }
        }

        public class SearchAndRescueInfo
        {
            public int SearchRescue_Traded { get; }
            public int SearchRescue_Profit { get; }
            public int SearchRescue_Count { get; }
        }

        public class CraftingInfo
        {
            public int Count_Of_Used_Engineers { get; }
            public int Recipes_Generated { get; }
            public int Recipes_Generated_Rank_1 { get; }
            public int Recipes_Generated_Rank_2 { get; }
            public int Recipes_Generated_Rank_3 { get; }
            public int Recipes_Generated_Rank_4 { get; }
            public int Recipes_Generated_Rank_5 { get; }
        }

        public class CrewInfo
        {
            public int NpcCrew_TotalWages { get; }
            public int NpcCrew_Hired { get; }
            public int NpcCrew_Fired { get; }
            public int NpcCrew_Died { get; }
        }

        public class MulticrewInfo
        {
            public int Multicrew_Time_Total { get; }
            public int Multicrew_Gunner_Time_Total { get; }
            public int Multicrew_Fighter_Time_Total { get; }
            public int Multicrew_Credits_Total { get; }
            public int Multicrew_Fines_Total { get; }
        }

        public class MaterialTraderStatsInfo
        {
            public int Trades_Completed { get; }
            public int Materials_Traded { get; }
            public int Raw_Materials_Traded { get; }
            public int Grade_2_Materials_Traded { get; }
        }

        public DateTime timestamp { get; }
        public BankAccountInfo Bank_Account { get; }
        public CombatInfo Combat { get; }
        public CrimeInfo Crime { get; }
        public SmugglingInfo Smuggling { get; }
        public TradingInfo Trading { get; }
        public MiningInfo Mining { get; }
        public ExplorationInfo Exploration { get; }
        public PassengersInfo Passengers { get; }
        public SearchAndRescueInfo Search_And_Rescue { get; }
        public CraftingInfo Crafting { get; }
        public CrewInfo Crew { get; }
        public MulticrewInfo Multicrew { get; }
        public MaterialTraderStatsInfo Material_Trader_Stats { get; }
    }
}
