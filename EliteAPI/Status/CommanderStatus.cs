namespace EliteAPI.Status
{
    public class CommanderStatus
    {
        public CommanderStatus(EliteDangerousAPI api)
        {
            api.Events.LoadGameEvent += (sender, e) => { Commander = e.Commander; Credits = e.Credits; };
            api.Events.RankEvent += (sender, e) => { EmpireRank = e.Empire; FederationRank = e.Federation; CombatRank = e.Combat; TradeRank = e.Trade; ExplorationRank = e.Explore; CqcRank = e.Cqc; };
            api.Events.ProgressEvent += (sender, e) => { EmpireRankProgress = e.Empire; FederationRankProgress = e.Federation; CombatRankProgress = e.Combat; TradeRankProgress = e.Trade; ExplorationRankProgress = e.Explore; CqcRankProgress = e.Cqc; };
        }

        public string Commander { get; private set; }
        public long Credits { get; private set; }

        public int EmpireRank { get; private set; }
        public int FederationRank { get; private set; }
        public int CombatRank { get; private set; }
        public int TradeRank { get; private set; }
        public int ExplorationRank { get; private set; }
        public int CqcRank { get; private set; }

        public int EmpireRankProgress { get; private set; }
        public int FederationRankProgress { get; private set; }
        public int CombatRankProgress { get; private set; }
        public int TradeRankProgress { get; private set; }
        public int ExplorationRankProgress { get; private set; }
        public int CqcRankProgress { get; private set; }

        public string EmpireRankLocalised { get { return RankUtil.Empire(EmpireRank); } }
        public string FederationRankLocalised { get { return RankUtil.Federation(FederationRank); } }
        public string CombatRankLocalised { get { return RankUtil.Combat(CombatRank); } }
        public string TradeRankLocalised { get { return RankUtil.Trade(TradeRank); } }
        public string ExplorationRankLocalised { get { return RankUtil.Exploration(ExplorationRank); } }
    }

    static class RankUtil
    {
        public static string Empire(int x)
        {
            if (x == 0) { return "None"; }
            if (x == 1) { return "Outsider"; }
            if (x == 2) { return "Serf"; }
            if (x == 3) { return "Master"; }
            if (x == 4) { return "Squire"; }
            if (x == 5) { return "Knight"; }
            if (x == 6) { return "Lord"; }
            if (x == 7) { return "Baron"; }
            if (x == 8) { return "Viscount"; }
            if (x == 9) { return "Count"; }
            if (x == 10) { return "Earl"; }
            if (x == 11) { return "Marquis"; }
            if (x == 12) { return "Duke"; }
            if (x == 13) { return "Prince"; }
            if (x == 14) { return "King"; }
            return "";
        }

        public static string Federation(int x)
        {
            if (x == 0) { return "None"; }
            if (x == 1) { return "Recruit"; }
            if (x == 2) { return "Cadet"; }
            if (x == 3) { return "Midshipman"; }
            if (x == 4) { return "Petty Officer"; }
            if (x == 5) { return "Chief Petty Officer"; }
            if (x == 6) { return "Warrant Officer"; }
            if (x == 7) { return "Ensign"; }
            if (x == 8) { return "Lieutenant"; }
            if (x == 9) { return "Lieutenant Commander"; }
            if (x == 10) { return "Post Commander"; }
            if (x == 11) { return "Post Captain"; }
            if (x == 12) { return "Rear Admiral"; }
            if (x == 13) { return "Vice Admiral	"; }
            if (x == 14) { return "Admiral"; }
            return "";
        }

        public static string Combat(int x)
        {
            if (x == 0) { return "Harmless"; }
            if (x == 1) { return "Mostly Harmless"; }
            if (x == 2) { return "Novice"; }
            if (x == 3) { return "Competent"; }
            if (x == 4) { return "Expert"; }
            if (x == 5) { return "Master"; }
            if (x == 6) { return "Dangerous"; }
            if (x == 7) { return "Deadly"; }
            if (x == 8) { return "Elite"; }
            return "";
        }

        public static string Trade(int x)
        {
            if (x == 0) { return "Penniless"; }
            if (x == 1) { return "Mostly Penniless"; }
            if (x == 2) { return "Peddler"; }
            if (x == 3) { return "Dealer"; }
            if (x == 4) { return "Merchant"; }
            if (x == 5) { return "Broker"; }
            if (x == 6) { return "Entrepreneur"; }
            if (x == 7) { return "Tycoon"; }
            if (x == 8) { return "Elite"; }
            return "";
        }

        public static string Exploration(int x)
        {
            if (x == 0) { return "Aimless"; }
            if (x == 1) { return "Mostly Aimless"; }
            if (x == 2) { return "Scout"; }
            if (x == 3) { return "Surveyor"; }
            if (x == 4) { return "Trailblazer"; }
            if (x == 5) { return "Pathfinder"; }
            if (x == 6) { return "Ranger"; }
            if (x == 7) { return "Pioneer"; }
            if (x == 8) { return "Elite"; }
            return "";
        }
    }
}
