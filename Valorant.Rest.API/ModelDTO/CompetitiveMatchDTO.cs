using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class CompetitiveMatchDTO
    {
        public int Version { get; set; }
        public string Subject { get; set; }
        public List<Match> Matches { get; set; }
        
        public class Match
        {
            public string MatchID { get; set; }
            public long MatchStartTime { get; set; }
            public int TierAfterUpdate { get; set; }
            public string CompetitiveMovement { get; set; }
        }
    }
}
