using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class PlayerMMRDTO
    {
        public long Version { get; set; }
        public string Subject { get; set; }
        public bool NewPlayerExperienceFinished { get; set; }
        public Queueskills QueueSkills { get; set; }
        public Latestcompetitiveupdate LatestCompetitiveUpdate { get; set; } 

        public class Queueskills
        {
            public Competitive competitive { get; set; }
            public Custom custom { get; set; }
            public Seeding seeding { get; set; }
            public Spikerush spikerush { get; set; }
            public Unrated unrated { get; set; }
        }

        public class Competitive
        {
            public int CompetitiveTier { get; set; }
            public int TotalGamesNeededForRating { get; set; }
            public int RecentGamesNeededForRating { get; set; }
            public object SeasonalInfoBySeasonID { get; set; }
        }

        public class Custom
        {
            public int CompetitiveTier { get; set; }
            public int TotalGamesNeededForRating { get; set; }
            public int RecentGamesNeededForRating { get; set; }
            public dynamic SeasonalInfoBySeasonID { get; set; }
        }

        public class Seeding
        {
            public int CompetitiveTier { get; set; }
            public int TotalGamesNeededForRating { get; set; }
            public int RecentGamesNeededForRating { get; set; }
            public dynamic SeasonalInfoBySeasonID { get; set; }
        }

        public class Spikerush
        {
            public int CompetitiveTier { get; set; }
            public int TotalGamesNeededForRating { get; set; }
            public int RecentGamesNeededForRating { get; set; }
            public dynamic SeasonalInfoBySeasonID { get; set; }
        }

        public class Unrated
        {
            public int CompetitiveTier { get; set; }
            public int TotalGamesNeededForRating { get; set; }
            public int RecentGamesNeededForRating { get; set; }
            public dynamic SeasonalInfoBySeasonID { get; set; }
        }

        public class Latestcompetitiveupdate
        {
            public string MatchID { get; set; }
            public long MatchStartTime { get; set; }
            public int TierAfterUpdate { get; set; }
            public string CompetitiveMovement { get; set; }
        }

    }
}
