namespace EliteAPI.Status
{
    internal static class RankUtil
    {
        public static string Empire(long x)
        {
            switch (x)
            {
                case 0:
                    return "None";
                case 1:
                    return "Outsider";
                case 2:
                    return "Serf";
                case 3:
                    return "Master";
                case 4:
                    return "Squire";
                case 5:
                    return "Knight";
                case 6:
                    return "Lord";
                case 7:
                    return "Baron";
                case 8:
                    return "Viscount";
                case 9:
                    return "Count";
                case 10:
                    return "Earl";
                case 11:
                    return "Marquis";
                case 12:
                    return "Duke";
                case 13:
                    return "Prince";
                case 14:
                    return "King";
                default:
                    return "";
            }
        }
        public static string Federation(long x)
        {
            switch (x)
            {
                case 0:
                    return "None";
                case 1:
                    return "Recruit";
                case 2:
                    return "Cadet";
                case 3:
                    return "Midshipman";
                case 4:
                    return "Petty Officer";
                case 5:
                    return "Chief Petty Officer";
                case 6:
                    return "Warrant Officer";
                case 7:
                    return "Ensign";
                case 8:
                    return "Lieutenant";
                case 9:
                    return "Lieutenant Commander";
                case 10:
                    return "Post Commander";
                case 11:
                    return "Post Captain";
                case 12:
                    return "Rear Admiral";
                case 13:
                    return "Vice Admiral	";
                case 14:
                    return "Admiral";
                default:
                    return "";
            }
        }
        public static string Combat(long x)
        {
            switch (x)
            {
                case 0:
                    return "Harmless";
                case 1:
                    return "Mostly Harmless";
                case 2:
                    return "Novice";
                case 3:
                    return "Competent";
                case 4:
                    return "Expert";
                case 5:
                    return "Master";
                case 6:
                    return "Dangerous";
                case 7:
                    return "Deadly";
                case 8:
                    return "Elite";
                default:
                    return "";
            }
        }
        public static string Trade(long x)
        {
            switch (x)
            {
                case 0:
                    return "Penniless";
                case 1:
                    return "Mostly Penniless";
                case 2:
                    return "Peddler";
                case 3:
                    return "Dealer";
                case 4:
                    return "Merchant";
                case 5:
                    return "Broker";
                case 6:
                    return "Entrepreneur";
                case 7:
                    return "Tycoon";
                case 8:
                    return "Elite";
                default:
                    return "";
            }
        }
        public static string Exploration(long x)
        {
            switch (x)
            {
                case 0:
                    return "Aimless";
                case 1:
                    return "Mostly Aimless";
                case 2:
                    return "Scout";
                case 3:
                    return "Surveyor";
                case 4:
                    return "Trailblazer";
                case 5:
                    return "Pathfinder";
                case 6:
                    return "Ranger";
                case 7:
                    return "Pioneer";
                case 8:
                    return "Elite";
                default:
                    return "";
            }
        }
    }
}