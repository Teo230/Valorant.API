using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class UserParametersDTO
    {
        public string type { get; set; }
        public Response response { get; set; }
        public string country { get; set; }
        
        public class Response
        {
            public string mode { get; set; }
            public Parameters parameters { get; set; }
        }

        public class Parameters
        {
            public string uri { get; set; }
        }

    }
}
