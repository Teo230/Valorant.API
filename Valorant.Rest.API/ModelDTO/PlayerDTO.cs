using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class PlayerDTO
    {
        public string DisplayName { get; set; }
        [JsonProperty("Subject")]
        public string PlayerId { get; set; }
        public string GameName { get; set; }
        public string TagLine { get; set; }
    }
}
