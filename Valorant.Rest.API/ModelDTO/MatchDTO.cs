using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class MatchDTO
    {
        [JsonProperty("Subject")]
        public string PlayerId { get; set; }
        public int BeginIndex { get; set; }
        public int EndIndex { get; set; }
        public int Total { get; set; }
        public List<History> history { get; set; }

        public class History
        {
            public string MatchID { get; set; }

            public long GameStartTime { get; set; }

            public string TeamID { get; set; }
        }
    }
}
