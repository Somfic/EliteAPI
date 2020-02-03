using EliteAPI.Events;
namespace EliteAPI.Status
{
    public class CommanderStatus
    {
        public CommanderStatus(EliteDangerousAPI api)
        {
            api.Events.LoadGameEvent += (sender, e) =>
            {
                Commander = e.Commander;
                Credits = e.Credits;
            };
            api.Events.RankEvent += (sender, e) =>
            {
                EmpireRank = e.Empire;
                FederationRank = e.Federation;
                CombatRank = e.Combat;
                TradeRank = e.Trade;
                ExplorationRank = e.Exploration;
                CqcRank = e.Cqc;
            };
            api.Events.ProgressEvent += (sender, e) =>
            {
                EmpireRankProgress = e.Empire;
                FederationRankProgress = e.Federation;
                CombatRankProgress = e.Combat;
                TradeRankProgress = e.Trade;
                ExplorationRankProgress = e.Explore;
                CqcRankProgress = e.Cqc;
            };
            api.Events.StatisticsEvent += (sender, e) => { Statistics = e; };
        }
        public string Commander { get; private set; }
        public long Credits { get; private set; }
        public long EmpireRank { get; private set; }
        public long FederationRank { get; private set; }
        public long CombatRank { get; private set; }
        public long TradeRank { get; private set; }
        public long ExplorationRank { get; private set; }
        public long CqcRank { get; private set; }
        public long EmpireRankProgress { get; private set; }
        public long FederationRankProgress { get; private set; }
        public long CombatRankProgress { get; private set; }
        public long TradeRankProgress { get; private set; }
        public long ExplorationRankProgress { get; private set; }
        public long CqcRankProgress { get; private set; }
        public string EmpireRankLocalised { get { return RankUtil.Empire(EmpireRank); } }
        public string FederationRankLocalised { get { return RankUtil.Federation(FederationRank); } }
        public string CombatRankLocalised { get { return RankUtil.Combat(CombatRank); } }
        public string TradeRankLocalised { get { return RankUtil.Trade(TradeRank); } }
        public string ExplorationRankLocalised { get { return RankUtil.Exploration(ExplorationRank); } }
        public StatisticsInfo Statistics { get; internal set; }
    }
}
