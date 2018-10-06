using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Events
{
    public class Statistics
    {
        public class cBankAccount
        {
            public int Current_Wealth { get; set; }
            public int Spent_On_Ships { get; set; }
            public long Spent_On_Outfitting { get; set; }
            public int Spent_On_Repairs { get; set; }
            public int Spent_On_Fuel { get; set; }
            public int Spent_On_Ammo_Consumables { get; set; }
            public int Insurance_Claims { get; set; }
            public int Spent_On_Insurance { get; set; }
        }

        public class cCombat
        {
            public int Bounties_Claimed { get; set; }
            public int Bounty_Hunting_Profit { get; set; }
            public int Combat_Bonds { get; set; }
            public int Combat_Bond_Profits { get; set; }
            public int Assassinations { get; set; }
            public int Assassination_Profits { get; set; }
            public int Highest_Single_Reward { get; set; }
            public int Skimmers_Killed { get; set; }
        }

        public class cCrime
        {
            public int Notoriety { get; set; }
            public int Fines { get; set; }
            public int Total_Fines { get; set; }
            public int Bounties_Received { get; set; }
            public int Total_Bounties { get; set; }
            public int Highest_Bounty { get; set; }
        }

        public class cSmuggling
        {
            public int Black_Markets_Traded_With { get; set; }
            public int Black_Markets_Profits { get; set; }
            public int Resources_Smuggled { get; set; }
            public int Average_Profit { get; set; }
            public int Highest_Single_Transaction { get; set; }
        }

        public class cTrading
        {
            public int Markets_Traded_With { get; set; }
            public int Market_Profits { get; set; }
            public int Resources_Traded { get; set; }
            public double Average_Profit { get; set; }
            public int Highest_Single_Transaction { get; set; }
        }

        public class cMining
        {
            public int Mining_Profits { get; set; }
            public int Quantity_Mined { get; set; }
            public int Materials_Collected { get; set; }
        }

        public class cExploration
        {
            public int Systems_Visited { get; set; }
            public int Exploration_Profits { get; set; }
            public int Planets_Scanned_To_Level_2 { get; set; }
            public int Planets_Scanned_To_Level_3 { get; set; }
            public int Highest_Payout { get; set; }
            public int Total_Hyperspace_Distance { get; set; }
            public int Total_Hyperspace_Jumps { get; set; }
            public double Greatest_Distance_From_Start { get; set; }
            public int Time_Played { get; set; }
        }

        public class cPassengers
        {
            public int Passengers_Missions_Accepted { get; set; }
            public int Passengers_Missions_Disgruntled { get; set; }
            public int Passengers_Missions_Bulk { get; set; }
            public int Passengers_Missions_VIP { get; set; }
            public int Passengers_Missions_Delivered { get; set; }
            public int Passengers_Missions_Ejected { get; set; }
        }

        public class cSearchAndRescue
        {
            public int SearchRescue_Traded { get; set; }
            public int SearchRescue_Profit { get; set; }
            public int SearchRescue_Count { get; set; }
        }

        public class cCrafting
        {
            public int Count_Of_Used_Engineers { get; set; }
            public int Recipes_Generated { get; set; }
            public int Recipes_Generated_Rank_1 { get; set; }
            public int Recipes_Generated_Rank_2 { get; set; }
            public int Recipes_Generated_Rank_3 { get; set; }
            public int Recipes_Generated_Rank_4 { get; set; }
            public int Recipes_Generated_Rank_5 { get; set; }
        }

        public class cCrew
        {
            public int NpcCrew_TotalWages { get; set; }
            public int NpcCrew_Hired { get; set; }
            public int NpcCrew_Fired { get; set; }
            public int NpcCrew_Died { get; set; }
        }

        public class cMulticrew
        {
            public int Multicrew_Time_Total { get; set; }
            public int Multicrew_Gunner_Time_Total { get; set; }
            public int Multicrew_Fighter_Time_Total { get; set; }
            public int Multicrew_Credits_Total { get; set; }
            public int Multicrew_Fines_Total { get; set; }
        }

        public class cMaterialTraderStats
        {
            public int Trades_Completed { get; set; }
            public int Materials_Traded { get; set; }
            public int Raw_Materials_Traded { get; set; }
            public int Grade_2_Materials_Traded { get; set; }
        }

        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public cBankAccount Bank_Account { get; set; }
        public cCombat Combat { get; set; }
        public cCrime Crime { get; set; }
        public cSmuggling Smuggling { get; set; }
        public cTrading Trading { get; set; }
        public cMining Mining { get; set; }
        public cExploration Exploration { get; set; }
        public cPassengers Passengers { get; set; }
        public cSearchAndRescue Search_And_Rescue { get; set; }
        public cCrafting Crafting { get; set; }
        public cCrew Crew { get; set; }
        public cMulticrew Multicrew { get; set; }
        public cMaterialTraderStats Material_Trader_Stats { get; set; }
    }
}
